using Microsoft.AspNetCore.Components.Authorization;
using Login_Gabriel.Shared              ;
using Blazored.SessionStorage;
using System.Security.Claims;
using System.ComponentModel.DataAnnotations;

namespace Login_Gabriel.Client.Extensiones
{
    public class AuthenticationExtension : AuthenticationStateProvider
    {
        //
        private readonly ISessionStorageService _sessionStorage;
        private ClaimsPrincipal _sinInformacion = new ClaimsPrincipal(new ClaimsIdentity());

        //constructor
        public AuthenticationExtension(ISessionStorageService sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        //metodo para actualizar el estado de autenticacion 

        public async Task UpdateAuthenticationstate (SesionDTO? sesionUsuario)
        {
            ClaimsPrincipal claimsPrincipal;

            if (sesionUsuario != null)
            {
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {

                    new Claim(ClaimTypes.Name, sesionUsuario.Name),
                    new Claim(ClaimTypes.Email, sesionUsuario.UserName),
                    new Claim(ClaimTypes.Role, sesionUsuario.Role),

                }, "JwtAuth"));

                await _sessionStorage.SaveStorage("sesionUsuario", sesionUsuario); //se guarda la info en el Storage
            }
            else
            {
                claimsPrincipal = _sinInformacion;
                await _sessionStorage.RemoveItemAsync("sesionUsuario");
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal))); //info del usuario guardada

        }


        //metodo que devuelve la info del usuario autenticado
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            var sesionUsuario = await _sessionStorage.ObtenerStorage<SesionDTO>("sesionUsuario");

            if (sesionUsuario == null)
                return await Task.FromResult(new AuthenticationState(_sinInformacion));
            var claimPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {

                    new Claim(ClaimTypes.Name, sesionUsuario.Name),
                    new Claim(ClaimTypes.Email, sesionUsuario.UserName),
                    new Claim(ClaimTypes.Role, sesionUsuario.Role),

                }, "JwtAuth"));

            return await Task.FromResult(new AuthenticationState(claimPrincipal));
        }
    }
}
