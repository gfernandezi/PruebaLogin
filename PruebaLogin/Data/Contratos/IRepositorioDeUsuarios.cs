using PruebaLogin.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace PruebaLogin.Data.Contratos
{
    public interface IRepositorioDeUsuarios : IRepositorio<UsuarioDTO>
    {
        void AccionEspecificaDeUsuarios(UsuarioDTO usuarioDTO);
    }
}