namespace BookStoreApp.Blazor.WebAssembly.UI.Services.Authentication
{
    using Blazored.LocalStorage;
    using BookStoreApp.Blazor.WebAssembly.UI.Providers;
    using BookStoreApp.Blazor.WebAssembly.UI.Services.Base;
    using Microsoft.AspNetCore.Components.Authorization;

    public class AuthenticationService : BaseHttpService, IAuthenticationService
    {
        private readonly IClient httpClient;
        private readonly ILocalStorageService localStorage;
        private readonly AuthenticationStateProvider authenticationStateProvider; //i inject the original AuthenticationStateProvider

        public AuthenticationService(IClient httpClient, ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider)
            :base(httpClient, localStorage)
        {
            this.httpClient = httpClient;
            this.localStorage = localStorage;
            this.authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<Response<AuthResponse>> AuthenticateAsync(LoginUserDto loginModel)
        {
            Response<AuthResponse> response;
            try
            {
                var result = await httpClient.LoginAsync(loginModel);
                response = new Response<AuthResponse>
                {
                    Data = result,
                    Success = true,
                };
                //Store Token
                await localStorage.SetItemAsync("accessToken", result.Token);

                //Change auth state of app. I must cast to my custom ApiAuthenticationStateProvider type
                await ((ApiAuthenticationStateProvider)authenticationStateProvider).LoggedIn();
            }
            catch (ApiException exception)
            { 
             response = ConvertApiExceptions<AuthResponse>(exception);
            }
            
            return response;
        }

        public async Task Logout()
        {
            await ((ApiAuthenticationStateProvider)authenticationStateProvider).LoggedOut();
        }
    }
}
