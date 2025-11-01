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
        //RETORNAR LISTA CARACTERISTICAS PERSONALES
        public async Task<(DCaracteristicasPersonales, string error)> ListaCaracteristicasPersonales()
        {
            IListasGenerales listasGeneralesDao = new ListasGeneralesDaoImplement();

            (DCaracteristicasPersonales caracteristicasPersonales, string errorResponse) = await listasGeneralesDao.ListasCaracteristicasPersonales();


            return (caracteristicasPersonales, errorResponse);
        }
        //FIN RETORNAR LISTA CARACTERISTICAS PERSONALES..................................

        //RETORNAR LISTAS DATOS FILIATORIOS
        public async Task<(DDatosFiliatorios, string error)> ListasDatosFilistorios()
        {
            IListasGenerales listasGeneralesDao = new ListasGeneralesDaoImplement();

            (DDatosFiliatorios datosFiliatorios, string errorResponse) = await listasGeneralesDao.ListasDatosFiliatorios();


            return (datosFiliatorios, errorResponse);
        }
        //FIN RETORNAR LISTAS DATOS FILIATORIOS..................................

    }
}
