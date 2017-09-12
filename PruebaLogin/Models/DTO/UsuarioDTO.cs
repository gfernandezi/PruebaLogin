using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaLogin.Models.DTO
{
    public class UsuarioDTO : Entidad
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }

    }
}