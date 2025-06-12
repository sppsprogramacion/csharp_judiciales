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
    public class NInterno
    {
        //CREAR INTERNO
        public async Task<(DInterno, string error)> CrearProhibicion(string interno)
        {
            IInternosDao internoDao = new InternoDaoImplement();

            (DInterno internoResponse, string errorResponse) = await internoDao.CrearInterno(interno);

            return (internoResponse, errorResponse);
        }
        //FIN CREAR INTERNO......................................................

        //RETORNAR X APELLIDO
        public async Task<(List<DInterno>, string error)> ListaInternosXApellido(string apellido)
        {
            IInternosDao internoDao = new InternoDaoImplement();

            (List<DInterno> listaInternos, string error) = await internoDao.ListaInternosXApellido(apellido);

            return (listaInternos, error);
        }
        //FIN RETORNAR X APELLIDO..................................
    }
}
