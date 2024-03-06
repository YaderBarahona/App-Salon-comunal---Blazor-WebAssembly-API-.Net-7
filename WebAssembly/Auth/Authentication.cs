using Blazored.LocalStorage;
using DTO;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace WebAssembly.Auth
{
    public class Authentication : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private ClaimsPrincipal _claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());

        public Authentication(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task ActualizarEstadoAuth(SesionDTO? sesionUsuario)
        {
            ClaimsPrincipal claims;

            if (sesionUsuario != null)
            {
                claims = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, sesionUsuario.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Name, sesionUsuario.Nombre),
                    new Claim(ClaimTypes.Email, sesionUsuario.Correo),
                    new Claim(ClaimTypes.Role, sesionUsuario.Rol),
                }, "JWtAuth"));

                await _localStorage.SetItemAsync("sesionUsuario", sesionUsuario);
            }
            else
            {
                claims = _claimsPrincipal;
                await _localStorage.RemoveItemAsync("sesionUsuario");
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claims)));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var sesionUsuario = await _localStorage.GetItemAsync<SesionDTO>("sesionUsuario");

            if (sesionUsuario == null)
            {
                return await Task.FromResult(new AuthenticationState(_claimsPrincipal));
            }

            var claims = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, sesionUsuario.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Name, sesionUsuario.Nombre),
                    new Claim(ClaimTypes.Email, sesionUsuario.Correo),
                    new Claim(ClaimTypes.Role, sesionUsuario.Rol),
                }, "JWtAuth"));

            return await Task.FromResult(new AuthenticationState(claims));
        }
    }
}
