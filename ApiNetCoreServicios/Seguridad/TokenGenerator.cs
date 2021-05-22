using System;
using Utilitarios;
using LogicaNC;
using System.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using DataNC;

namespace ApiNetCoreServicios.Seguridad
{ 
    /// <summary>
    /// JWT Token generator class using "secret-key"
    /// more info: https://self-issued.info/docs/draft-ietf-oauth-json-web-token.html
    /// </summary>
    internal static class TokenGenerator
    {
        public static string GenerateTokenJwt(UUsuario user,string  secretKey,string  audienceToken, string issuerToken, string expireTime, Mapeo _context)
        {
            //TODO: appsetting for Demo JWT - protect correctly this settings
          
           


            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // create a claimsIdentity 
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, user.Correo),
                new Claim(ClaimTypes.Role, user.Id_rol.ToString()),
               new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Rsa,user.Contrasenia)
            });

            // create token to the user 
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audienceToken,
                issuer: issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(user.Expiracion),
                signingCredentials: signingCredentials);

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);

            UToken_Seguridad token_seguridad= new UToken_Seguridad();
            token_seguridad.AplicacionId = user.AplicacionId;
            token_seguridad.FechaGenerado = DateTime.Now;
            token_seguridad.FechaVigencia = DateTime.Now.AddMinutes(user.Expiracion);
            token_seguridad.UserId = user.Id;
            token_seguridad.Token = jwtTokenString;
            new LUser(_context).guardarToken(token_seguridad);
            return jwtTokenString;
        }
    }
}
