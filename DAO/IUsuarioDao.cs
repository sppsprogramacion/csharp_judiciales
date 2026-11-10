using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IUsuarioDao
    {

        Task<(bool, string error)> DeshabilitarUsuario(int idUsuario);
        Task<(bool, string error)> CambiarMiPassword(string dataEditar);
        Task<(DUsuario, string error)> BuscarUsuarioMicuenta();
        Task<(DUsuario, string error)> BuscarUsuarioXId(int idUsuario);
        Task<(List<DUsuario>, string error)> ListaUsuariosActivosDelOrganismoSistema();
        Task<(List<DUsuario>, string error)> ListaUsuariosInactivosDelOrganismoSistema(int idUsuario);
        
    }
}
