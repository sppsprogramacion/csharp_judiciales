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
    public class NHistorialPRocesal
    {
        //CREAR 
        public async Task<(DHistorialProcesal, string error)> CrearHistorial(string historialProcesal)
        {
            IHistorialProcesalDao historialProcesalDao = new HistorialProcesalDaoImplement();

            (DHistorialProcesal historialProcesalResponse, string errorResponse) = await historialProcesalDao.CrearHistorial(historialProcesal);

            return (historialProcesalResponse, errorResponse);
        }
        //FIN CREAR ......................................................

        //LISTA DE HISTORIA X INGRESO
        public async Task<(List<DHistorialProcesal>, string error)> ListaXIngreso(int idIngreso)
        {
            IHistorialProcesalDao historialProcesalDao = new HistorialProcesalDaoImplement();

            (List<DHistorialProcesal> listahistorialProcesalResponse, string errorResponse) = await historialProcesalDao.ListaHistorialXIngreso(idIngreso);

            return (listahistorialProcesalResponse, errorResponse);
        }
        //FIN LISTA DE HISTORIAL X INGRESO..................................

        //LISTA DE HISTORIA X INGRESO X IDTIPO_HISTORIAL
        public async Task<(List<DHistorialProcesal>, string error)> ListaXIngresoXTipoHistorial(int idIngreso, int idTipoHistorial)
        {
            IHistorialProcesalDao historialProcesalDao = new HistorialProcesalDaoImplement();

            (List<DHistorialProcesal> listahistorialProcesalResponse, string errorResponse) = await historialProcesalDao.ListaHistorialXIngresoXTipoHistorial(idIngreso, idTipoHistorial);

            return (listahistorialProcesalResponse, errorResponse);
        }
        //FIN LISTA DE HISTORIAL X INGRESO X IDTIPO_HISTORIAL..................................

        //RETORNAR  X ID HISTORIAL
        public async Task<(DHistorialProcesal, string error)> BuscarxIdHistorial(int idHistorial)
        {
            IHistorialProcesalDao historialProcesalDao = new HistorialProcesalDaoImplement();

            (DHistorialProcesal historialProcesalResponse, string errorResponse) = await historialProcesalDao.BuscarHistorialXId(idHistorial);

            return (historialProcesalResponse, errorResponse);
        }
        //FIN RETORNAR  XID HISTORIAL.......................................................................

        //MODIFICAR HISTORIAL
        public async Task<(bool, string error)> EditarHistorial(int idHistorial, string dataHistorial)
        {
            IHistorialProcesalDao historialProcesalDao = new HistorialProcesalDaoImplement();

            (bool historialResponse, string error) = await historialProcesalDao.EditarHistorial(idHistorial, dataHistorial);

            return (historialResponse, error);
        }
        //FIN MODIFICAR HISTORIAL........................................................................

    }
}
