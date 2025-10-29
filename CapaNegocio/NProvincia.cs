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
    public class NProvincia
    {
        //RETORNAR PROVINCIAS X PAIS TODOS
        public async Task<(List<DProvincia>, string error)> RetornarListaProvinciasXPais(string id_pais)
        {
            IProvinciaDao provinciaDao = new ProvinciaDaoImpl();

            (List<DProvincia> listaProvincia, string errorResponse) = await provinciaDao.retornarListaProvinciasXPais(id_pais);


            return (listaProvincia, errorResponse);
        }
        //FIN RETORNAR PROVINCIAS X PAIS TODOS..................................
    }
}
