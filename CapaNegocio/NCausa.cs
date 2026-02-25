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
    public class NCausa
    {
        //CREAR CAUSA
        public async Task<(DCausa, string error)> CrearCausa(string causa)
        {
            ICausaDao causaDao = new CausaDaoImplement();

            (DCausa causaResponse, string errorResponse) = await causaDao.CrearCausa(causa);

            return (causaResponse, errorResponse);
        }
        //FIN CREAR CAUSA......................................................

        //LISTA DE CAUSAS X INGRESO
        public async Task<(List<DCausa>, string error)> ListaCausasXIngreso(int idIngreso)
        {
            ICausaDao causaDao = new CausaDaoImplement();

            (List<DCausa> listaCausas, string errorResponse) = await causaDao.ListaCausasXIngreso(idIngreso);

            return (listaCausas, errorResponse);
        }
        //FIN LISTA DE CAUSAS X INGRESO..................................

        //RETORNAR  X ID CAUSA
        public async Task<(DCausa, string error)> BuscarxIdCausa(int idCausa)
        {
            ICausaDao causaDao = new CausaDaoImplement();

            (DCausa causaResponse, string errorResponse) = await causaDao.BuscarCausaXId(idCausa);

            return (causaResponse, errorResponse);
        }
        //FIN RETORNAR  XID CAUSA.......................................................................

        //MODIFICAR UNA CAUSA
        public async Task<(bool, string error)> EditarCausa(int idCausa, string dataCausa)
        {
            ICausaDao causaDao = new CausaDaoImplement();

            (bool causaResponse, string error) = await causaDao.EditarCausa(idCausa, dataCausa);

            return (causaResponse, error);
        }
        //FIN MODIFICAR UNA CAUSA........................................................................

        //ESTABLECER CONDENA DE UNA CAUSA
        public async Task<(bool, string error)> EstablecerCondena(int idCausa, string dataCausa)
        {
            ICausaDao causaDao = new CausaDaoImplement();

            (bool causaResponse, string error) = await causaDao.EstablecerCondena(idCausa, dataCausa);

            return (causaResponse, error);
        }
        //FIN ESTABLECER CONDENA DE UNA CAUSA........................................................................

        //QUITAR CONDENA DE UNA CAUSA
        public async Task<(bool, string error)> QuitarCondena(int idCausa, string dataCausa)
        {
            ICausaDao causaDao = new CausaDaoImplement();

            (bool causaResponse, string error) = await causaDao.QuitarCondena(idCausa, dataCausa);

            return (causaResponse, error);
        }
        //FIN QUITAR CONDENA DE UNA CAUSA....................................................................
    }
}
