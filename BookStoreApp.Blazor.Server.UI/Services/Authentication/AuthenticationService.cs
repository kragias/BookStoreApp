namespace BookStoreApp.Blazor.Server.UI.Services.Authentication
{
    using Blazored.LocalStorage;
    using BookStoreApp.Blazor.Server.UI.Providers;
    using BookStoreApp.Blazor.Server.UI.Services.Base;
    using Microsoft.AspNetCore.Components.Authorization;

    public class AuthenticationService : IAuthenticationService
    {
        private readonly IClient httpClient;
        private readonly ILocalStorageService localStorage;
        private readonly AuthenticationStateProvider authenticationStateProvider; //i inject the original AuthenticationStateProvider

        public AuthenticationService(IClient httpClient, ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider)
        {
            this.httpClient = httpClient;
            this.localStorage = localStorage;
            this.authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> AuthenticateAsync(LoginUserDto loginModel)
        {
            var response = await httpClient.LoginAsync(loginModel);

            //Store Token
            await localStorage.SetItemAsync("accessToken", response.Token);

            //Change auth state of app. I must cast to my custom ApiAuthenticationStateProvider type
            await ((ApiAuthenticationStateProvider)authenticationStateProvider).LoggedIn();

            return true;
        }

        public async Task Logout()
        {
            await ((ApiAuthenticationStateProvider)authenticationStateProvider).LoggedOut();
        }
    }
}
