namespace BSDSalzburg2024.Auth;

using System.Threading.Tasks;

public delegate void MyAuthenticationStateChangedHandler(Task<MyAuthenticationState> task);