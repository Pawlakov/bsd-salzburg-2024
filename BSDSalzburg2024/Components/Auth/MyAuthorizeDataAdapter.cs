namespace BSDSalzburg2024.Components.Auth;

using System;
using Microsoft.AspNetCore.Authorization;

public class MyAuthorizeDataAdapter 
    : IAuthorizeData
{
    private readonly MyAuthorizeView _component;

    public MyAuthorizeDataAdapter(MyAuthorizeView component)
    {
        _component = component ?? throw new ArgumentNullException(nameof(component));
    }

    public string? Policy
    {
        get => _component.Policy;
        set => throw new NotSupportedException();
    }

    public string? Roles
    {
        get => _component.Roles;
        set => throw new NotSupportedException();
    }

    public string? AuthenticationSchemes
    {
        get => null;
        set => throw new NotSupportedException();
    }
}
