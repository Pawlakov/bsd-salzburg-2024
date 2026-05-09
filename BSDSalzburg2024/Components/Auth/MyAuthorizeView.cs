namespace BSDSalzburg2024.Components.Auth;

using System;
using System.Security.Claims;
using System.Threading.Tasks;
using BSDSalzburg2024.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

public class MyAuthorizeView
    : ComponentBase {
    private MyAuthenticationState? currentAuthenticationState;
    private bool? isAuthorized;

    [Parameter] public string? Policy { get; set; }

    [Parameter] public string? Roles { get; set; }

    [Parameter] public RenderFragment<MyAuthenticationState>? NotAuthorized { get; set; }

    [Parameter] public RenderFragment<MyAuthenticationState>? OverrideAuthorized { get; set; }

    [Parameter] public RenderFragment<MyAuthenticationState>? SimpleAuthorized { get; set; }

    [Parameter] public RenderFragment? Authorizing { get; set; }

    [Parameter] public object? Resource { get; set; }

    [CascadingParameter] private Task<MyAuthenticationState>? AuthenticationState { get; set; }

    [Inject] private IAuthorizationPolicyProvider AuthorizationPolicyProvider { get; set; }

    [Inject] private IAuthorizationService AuthorizationService { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        // We're using the same sequence number for each of the content items here
        // so that we can update existing instances if they are the same shape
        if (isAuthorized == null)
        {
            builder.AddContent(0, Authorizing);
        }
        else if (isAuthorized == true)
        {
            if (this.currentAuthenticationState.SupersededUser != null)
            {
                builder.AddContent(0, OverrideAuthorized?.Invoke(currentAuthenticationState!));
            }
            else
            {
                builder.AddContent(0, SimpleAuthorized?.Invoke(currentAuthenticationState!));
            }
        }
        else
        {
            builder.AddContent(0, NotAuthorized?.Invoke(currentAuthenticationState!));
        }
    }

    protected override async Task OnParametersSetAsync()
    {
        if (AuthenticationState == null)
        {
            throw new InvalidOperationException($"Authorization requires a cascading parameter of type Task<{nameof(MyAuthenticationState)}>.");
        }

        // Clear the previous result of authorization
        // This will cause the Authorizing state to be displayed until the authorization has been completed
        isAuthorized = null;

        currentAuthenticationState = await AuthenticationState;
        isAuthorized = await IsAuthorizedAsync(currentAuthenticationState.User);
    }

    private async Task<bool> IsAuthorizedAsync(ClaimsPrincipal user)
    {
        var authorizeData = new MyAuthorizeDataAdapter(this);

        var policy = await AuthorizationPolicy.CombineAsync(AuthorizationPolicyProvider, new[] { authorizeData });
        var result = await AuthorizationService.AuthorizeAsync(user, Resource, policy!);
        return result.Succeeded;
    }
}
