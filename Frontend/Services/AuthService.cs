using Blazored.LocalStorage;
using Frontend.DTOs;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;

namespace Frontend.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _provider;

        public AuthService(
            HttpClient httpClient,
            ILocalStorageService localStorage,
            AuthenticationStateProvider provider
        )
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _provider = provider;
        }

        public async Task<bool> LoginAsync(LoginDto loginDto)
        {
            var respuesta = await _httpClient.PostAsJsonAsync("auth/login", loginDto);

            if (respuesta.IsSuccessStatusCode)
            {
                var token = await respuesta.Content.ReadAsStringAsync();
                await _localStorage.SetItemAsync("token", token);
                await _provider.GetAuthenticationStateAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
