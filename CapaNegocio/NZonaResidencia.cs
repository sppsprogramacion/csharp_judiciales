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
    public class NZonaResidencia
    {
        //RETORNAR ZONA RESIDENCIA TODOS
        public async Task<(List<DZonaResidencia>, string error)> ListaZonaResidencia()
        {
            IZonaResidencia zonaResidenciaDao = new ZonaResidenciaDaoImplement();

            (List<DZonaResidencia> listaZonaResidencia, string errorResponse) = await zonaResidenciaDao.listaZonaResidenciaTodos();



            return (listaZonaResidencia, errorResponse);
        }
        //FIN RETORNAR ZONA RESIDENCIA TODOS..................................
    }
}
