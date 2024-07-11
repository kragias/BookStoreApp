namespace BookStoreApp.Blazor.WebAssembly.UI.Services.Authentication
{
    using BookStoreApp.Blazor.WebAssembly.UI.Services.Base;
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(LoginUserDto loginModel);
        public Task Logout();
    }
}
