using CapaDatos;
using DAO;
using DAOImplement;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NListasGenerales
    {
        //RETORNAR LISTA CARACTERISTICAS GENERALES
        public async Task<(DCaracteristicasPersonales, string error)> ListaCaracteristicasGenerales()
        {
            IListasGenerales listasGeneralesDao = new ListasGeneralesDaoImplement();

            (DCaracteristicasPersonales caracteristicasPersonales, string errorResponse) = await listasGeneralesDao.ListaCaracteristicasPersonales();


            return (caracteristicasPersonales, errorResponse);
        }
        //FIN RETORNAR LISTA CARACTERISTICAS GENERALES..................................

    }
}
