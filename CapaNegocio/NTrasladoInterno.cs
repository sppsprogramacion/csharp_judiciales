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
    public class NTrasladoInterno
    {
        //CREAR TRASLADO
        public async Task<(DTrasladoInterno, string error)> CrearTraslado(string trasladoInterno)
        {
            ITrasladoInternoDao trasladoInternoDao = new TrasladoInternoDaoImplement();

            (DTrasladoInterno trasladoResponse, string errorResponse) = await trasladoInternoDao.CrearTraslado(trasladoInterno);

            return (trasladoResponse, errorResponse);
        }
        //FIN CREAR TRASLADO......................................................

        //RETORNAR  X ID TRASLADO
        public async Task<(DTrasladoInterno, string error)> BuscarxIdTraslado(int idTraslado)
        {
            ITrasladoInternoDao trasladoInternoDao = new TrasladoInternoDaoImplement();

            (DTrasladoInterno trasladoResponse, string errorResponse) = await trasladoInternoDao.BuscarTrasladoXId(idTraslado);

            return (trasladoResponse, errorResponse);
        }
        //FIN RETORNAR  XID TRASLADO..................................

        //LISTA DE TRASLADOS X INGRESO
        public async Task<(List<DTrasladoInterno>, string error)> ListaTrasladosXIngreso(int idTraslado)
        {
            ITrasladoInternoDao trasladoInternoDao = new TrasladoInternoDaoImplement();

            (List<DTrasladoInterno> listaTraslados, string errorResponse) = await trasladoInternoDao.ListaTrasladosXIngreso(idTraslado);

            return (listaTraslados, errorResponse);
        }
        //FIN LISTA DE TRASLADOS X INGRESO..................................

        //LISTA DE TRASLADOS X MI ORGANISMO
        public async Task<(List<DTrasladoInterno>, string error)> ListaTrasladosPendientesXMiOrganismo()
        {
            ITrasladoInternoDao trasladoInternoDao = new TrasladoInternoDaoImplement();

            (List<DTrasladoInterno> listaTraslados, string errorResponse) = await trasladoInternoDao.ListaTrasladosPendientesXMiOrganismo();

            return (listaTraslados, errorResponse);
        }
        //FIN LISTA DE TRASLADOS X MI ORGANISMO..................................

        //LISTA DE TRASLADOS X OTROS ORGANISMOS
        public async Task<(List<DTrasladoInterno>, string error)> ListaTrasladosPendientesXOrganismo(int idTraslado)
        {
            ITrasladoInternoDao trasladoInternoDao = new TrasladoInternoDaoImplement();

            (List<DTrasladoInterno> listaTraslados, string errorResponse) = await trasladoInternoDao.ListaTrasladosPendientesXOrganismo(idTraslado);

            return (listaTraslados, errorResponse);
        }
        //FIN LISTA DE TRASLADOS X OTROS ORGANISMOS..................................

        //LISTA DE TRASLADOS X MI ORGANISMO
        public async Task<(List<DTrasladoInterno>, string error)> ListaTrasladosXMiOrganismo()
        {
            ITrasladoInternoDao trasladoInternoDao = new TrasladoInternoDaoImplement();

            (List<DTrasladoInterno> listaTraslados, string errorResponse) = await trasladoInternoDao.ListaTrasladosXMiOrganismo();

            return (listaTraslados, errorResponse);
        }
        //FIN LISTA DE TRASLADOS X MI ORGANISMO..................................

        //ACEPTAR UN TRASLADO
        public async Task<(bool, string error)> AceptarTraslado(int idTraslado, string dataAnular)
        {
            ITrasladoInternoDao trasladoInternoDao = new TrasladoInternoDaoImplement();

            (bool trasladoResponse, string error) = await trasladoInternoDao.AceptarTraslado(idTraslado, dataAnular);

            return (trasladoResponse, error);
        }
        //FIN ACEPTAR UN TRASLADO..............................................................

        //ANULAR UN TRASLADO
        public async Task<(bool, string error)> AnularTraslado(int idTraslado, string dataAnular)
        {
            ITrasladoInternoDao trasladoInternoDao = new TrasladoInternoDaoImplement();

            (bool trasladoResponse, string error) = await trasladoInternoDao.AnularTraslado(idTraslado, dataAnular);

            return (trasladoResponse, error);
        }
        //FIN ANULAR UN TRASLADO...........................................................

        //RECHAZAR UN TRASLADO
        public async Task<(bool, string error)> RechazarTraslado(int idTraslado, string dataAnular)
        {
            ITrasladoInternoDao trasladoInternoDao = new TrasladoInternoDaoImplement();

            (bool trasladoResponse, string error) = await trasladoInternoDao.RechazarTraslado(idTraslado, dataAnular);

            return (trasladoResponse, error);
        }
        //FIN RECHAZAR UN TRASLADO..................................
    }
}
