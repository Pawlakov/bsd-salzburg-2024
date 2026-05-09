namespace BSDSalzburg2024.Auth;

using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

public class MyAuthenticationState
    : AuthenticationState
{
    public MyAuthenticationState(ClaimsPrincipal user, ClaimsPrincipal? supersededUser) : base(user)
    {
        this.SupersededUser = supersededUser;
    }

    public ClaimsPrincipal? SupersededUser { get; }
}
