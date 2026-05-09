namespace BSDSalzburg2024.Auth;

using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.JSInterop;

public class MyAuthenticationStateProvider
    : AuthenticationStateProvider, IAsyncDisposable 
{
    private const string SessionKey = "authUser";
    private const string Scheme = "MyAuth";

    private readonly ProtectedLocalStorage storage;
    private readonly IJSRuntime js;
    private readonly DotNetObjectReference<MyAuthenticationStateProvider> reference;

    private ClaimsPrincipal currentUser = new ClaimsPrincipal(new ClaimsIdentity());
    private ClaimsPrincipal? supersededUser = null;

    public event MyAuthenticationStateChangedHandler? MyAuthenticationStateChanged;

    public MyAuthenticationStateProvider(ProtectedLocalStorage storage, IJSRuntime js)
    {
        this.storage = storage;
        this.js = js;
        this.reference = DotNetObjectReference.Create(this);

        this.js.InvokeVoidAsync("authSync.register", reference);
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        return await this.GetMyAuthenticationStateAsync();
    }

    public async Task<MyAuthenticationState> GetMyAuthenticationStateAsync()
    {
        var storedUser = await this.storage.GetAsync<UserSession>(SessionKey);

        if (storedUser.Success && storedUser.Value != null)
        {
            var currentIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, storedUser.Value.Username),
                new Claim(ClaimTypes.Role, storedUser.Value.Role)
            }, Scheme);

            this.currentUser = new ClaimsPrincipal(currentIdentity);

            if (storedUser.Value.SupersededUsername != null && storedUser.Value.SupersededRole != null)
            {
                var supersededIdentity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, storedUser.Value.SupersededUsername),
                    new Claim(ClaimTypes.Role, storedUser.Value.SupersededRole)
                }, Scheme);

                this.supersededUser = new ClaimsPrincipal(supersededIdentity);
            }
            else
            {
                this.supersededUser = null;
            }
        }
        else
        {
            this.currentUser = new ClaimsPrincipal(new ClaimsIdentity());
            this.supersededUser = null;
        }

        return new MyAuthenticationState(this.currentUser, this.supersededUser);
    }

    public async Task SignIn(string username, string role)
    {
        var identity = new ClaimsIdentity(
        [
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role)
        ], Scheme);

        this.supersededUser = null;
        this.currentUser = new ClaimsPrincipal(identity);

        await this.storage.SetAsync(SessionKey, new UserSession { Username = username, Role = role, SupersededUsername = null, SupersededRole = null });

        await this.NotifyMyAuthenticationStateChanged(GetMyAuthenticationStateAsync());
    }

    public async Task OverrideSignIn(string username, string role)
    {
        var identity = new ClaimsIdentity(
        [
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role)
        ], Scheme);

        this.supersededUser = this.currentUser;
        this.currentUser = new ClaimsPrincipal(identity);

        var supersededUser = this.supersededUser.Claims.Single(x => x.Type == ClaimTypes.Name).Value;
        var supersededRole = this.supersededUser.Claims.Single(x => x.Type == ClaimTypes.Role).Value;
        await this.storage.SetAsync(SessionKey, new UserSession { Username = username, Role = role, SupersededUsername = supersededUser, SupersededRole = supersededRole });

        await this.NotifyMyAuthenticationStateChanged(GetMyAuthenticationStateAsync());
    }

    public async Task SignOut()
    {
        this.currentUser = new ClaimsPrincipal(new ClaimsIdentity());
        this.supersededUser = null;

        await this.storage.DeleteAsync(SessionKey);

        await this.NotifyMyAuthenticationStateChanged(GetMyAuthenticationStateAsync());
    }

    public async Task OverrideSignOut()
    {
        var supersededUser = this.supersededUser.Claims.Single(x => x.Type == ClaimTypes.Name).Value;
        var supersededRole = this.supersededUser.Claims.Single(x => x.Type == ClaimTypes.Role).Value;

        this.currentUser = this.supersededUser;
        this.supersededUser = null;

        await this.storage.SetAsync(SessionKey, new UserSession { Username = supersededUser, Role = supersededRole, SupersededUsername = null, SupersededRole = null });

        await this.NotifyMyAuthenticationStateChanged(GetMyAuthenticationStateAsync());
    }

    private async Task NotifyMyAuthenticationStateChanged(Task<MyAuthenticationState> task)
    {
        this.NotifyAuthenticationStateChanged(Task.FromResult<AuthenticationState>(await task));
        MyAuthenticationStateChanged?.Invoke(task);
    }

    [JSInvokable]
    public async Task OnAuthenticationChanged()
    {
        await this.NotifyMyAuthenticationStateChanged(GetMyAuthenticationStateAsync());
    }

    public async ValueTask DisposeAsync()
    {
        this.reference.Dispose();
    }
}
