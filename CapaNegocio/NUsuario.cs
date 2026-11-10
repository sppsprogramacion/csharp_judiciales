using CapaDatos;
using DAO;
using DAOImplement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NUsuario
    {
        //CAMBIAR MI PASSWORD
        public async Task<(bool, string error)> CambiarMiPassword(string dataEditar)
        {
            IUsuarioDao usuarioDao = new UsuarioDaoImplement();

            (bool edicionResponse, string error) = await usuarioDao.CambiarMiPassword(dataEditar);

            return (edicionResponse, error);
        }
        //FIN CAMBIAR MI PASSWORD
        //..........................................................................................

        //QUITAR USUARIO DEL SISTEMA
        public async Task<(bool, string error)> DeshabilitarUsuarioDelSistema(int idUsuario)
        {
            IUsuarioDao usuarioDao = new UsuarioDaoImplement();

            (bool edicionResponse, string error) = await usuarioDao.DeshabilitarUsuario(idUsuario);

            return (edicionResponse, error);
        }
        //FIN QUITAR USUARIO DEL SISTEMA
        //..........................................................................................


        //BUSCAR USUARIO MI CUENTA
        public async Task<(DUsuario, string error)> BuscarUsuarioMiCuenta()
        {
            IUsuarioDao usuarioDao = new UsuarioDaoImplement();

            (DUsuario usuarioResponse, string error) = await usuarioDao.BuscarUsuarioMicuenta();


            return (usuarioResponse, error);
        }
        //FIN BUSCAR USUARIO MI CUENTA
        //........................................................................................


        //BUSCAR USUARIO X ID
        public async Task<(DUsuario, string error)> BuscarUsuarioXID(int idUsuario)
        {
            IUsuarioDao usuarioDao = new UsuarioDaoImplement();

            (DUsuario usuarioResponse, string error) = await usuarioDao.BuscarUsuarioXId(idUsuario);


            return (usuarioResponse, error);
        }
        //FIN BUSCAR USUARIO XID
        //........................................................................................


        public async Task<(List<DUsuario>, string error)> ListaUsuariosActivos()
        {
            IUsuarioDao usuarioDao = new UsuarioDaoImplement();

            (List<DUsuario> listaUsuarios, string errorResponse) = await usuarioDao.ListaUsuariosActivosDelOrganismoSistema();


            return (listaUsuarios, errorResponse);
        }
        //FIN RETORNAR LISTA PROHIBICIONES VISITA POR CIUDADANO
        //...........................................................................


    }
}
