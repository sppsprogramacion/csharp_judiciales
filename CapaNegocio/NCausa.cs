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
    }
}
