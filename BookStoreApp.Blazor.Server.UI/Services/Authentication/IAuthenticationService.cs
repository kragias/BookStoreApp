namespace BookStoreApp.Blazor.Server.UI.Services.Authentication
{
    using BookStoreApp.Blazor.Server.UI.Services.Base;
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(LoginUserDto loginModel);
        public Task Logout();
    }
}
