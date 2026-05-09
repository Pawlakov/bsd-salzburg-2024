namespace BSDSalzburg2024.Auth.Extensions;

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

public static class MyCascadingAuthenticationStateServiceCollectionExtensions
{
    public static IServiceCollection AddOriginalCascadingAuthenticationState(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddCascadingValue<Task<AuthenticationState>>(services => {
            var authenticationStateProvider = services.GetRequiredService<MyAuthenticationStateProvider>();
            return new OriginalAuthenticationStateCascadingValueSource(authenticationStateProvider);
        });
    }

    public static IServiceCollection AddMyCascadingAuthenticationState(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddCascadingValue<Task<MyAuthenticationState>>(services => {
            var authenticationStateProvider = services.GetRequiredService<MyAuthenticationStateProvider>();
            return new MyAuthenticationStateCascadingValueSource(authenticationStateProvider);
        });
    }

    private sealed class MyAuthenticationStateCascadingValueSource : CascadingValueSource<Task<MyAuthenticationState>>, IDisposable
    {
        private readonly MyAuthenticationStateProvider _authenticationStateProvider;

        public MyAuthenticationStateCascadingValueSource(MyAuthenticationStateProvider authenticationStateProvider)
            : base(authenticationStateProvider.GetMyAuthenticationStateAsync, isFixed: false)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _authenticationStateProvider.MyAuthenticationStateChanged += HandleAuthenticationStateChanged;
        }

        private void HandleAuthenticationStateChanged(Task<MyAuthenticationState> newAuthStateTask)
        {
            _ = NotifyChangedAsync(newAuthStateTask);
        }

        public void Dispose()
        {
            _authenticationStateProvider.MyAuthenticationStateChanged -= HandleAuthenticationStateChanged;
        }
    }

    private sealed class OriginalAuthenticationStateCascadingValueSource
        : CascadingValueSource<Task<AuthenticationState>>, IDisposable
    {
        private readonly MyAuthenticationStateProvider _authenticationStateProvider;

        public OriginalAuthenticationStateCascadingValueSource(MyAuthenticationStateProvider authenticationStateProvider)
            : base(authenticationStateProvider.GetAuthenticationStateAsync, isFixed: false)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _authenticationStateProvider.AuthenticationStateChanged += HandleAuthenticationStateChanged;
        }

        private void HandleAuthenticationStateChanged(Task<AuthenticationState> newAuthStateTask)
        {
            _ = NotifyChangedAsync(newAuthStateTask);
        }

        public void Dispose()
        {
            _authenticationStateProvider.AuthenticationStateChanged -= HandleAuthenticationStateChanged;
        }
    }
}
