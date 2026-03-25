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

        //RETORNAR TABLAS PARA INGRESO DE INTERNO
        public async Task<(DTablasIngresoInterno, string error)> ListasTablasIngresoInterno()
        {
            IListasGenerales listasGeneralesDao = new ListasGeneralesDaoImplement();

            (DTablasIngresoInterno tablasIngresoInterno, string errorResponse) = await listasGeneralesDao.ListasTablasUngresoInterno();


            return (tablasIngresoInterno, errorResponse);
        }
        //FIN RETORNAR TABLAS PARA INGRESO DE INTERNO..................................

        //RETORNAR TABLAS PARA CAUSA
        public async Task<(DTablasCausa, string error)> ListasTablasCausa()
        {
            IListasGenerales listasGeneralesDao = new ListasGeneralesDaoImplement();

            (DTablasCausa tablasCausa, string errorResponse) = await listasGeneralesDao.ListasTablasCausa();


            return (tablasCausa, errorResponse);
        }
        //FIN RETORNAR TABLAS PARA CAUSA
        
        //RETORNAR TABLAS PARA HISTORIAL PROCESAL
        public async Task<(DTablasHistorialProcesal, string error)> ListasTablasHistorialProcesal()
        {
            IListasGenerales listasGeneralesDao = new ListasGeneralesDaoImplement();

            (DTablasHistorialProcesal tablasHistorialProcesal, string errorResponse) = await listasGeneralesDao.ListasTablasHistorialProcesal();


            return (tablasHistorialProcesal, errorResponse);
        }
        //FIN RETORNAR TABLAS PARA HISTORIAL PROCESAL..................................

    }
}
