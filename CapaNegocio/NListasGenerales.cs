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

        //RETORNAR TABLAS PARA CAUSA
        public async Task<(DTablasCausa, string error)> ListasTablasCausa()
        {
            IListasGenerales listasGeneralesDao = new ListasGeneralesDaoImplement();

            (DTablasCausa tablasCausa, string errorResponse) = await listasGeneralesDao.ListasTablasCausa();


            return (tablasCausa, errorResponse);
        }
        //FIN RETORNAR TABLAS PARA CAUSA

        //RETORNAR TABLAS PARA DOMICILIO INTERNO
        public async Task<(DTablasDomicilioInterno, string error)> ListasTablasDomicilioInterno()
        {
            IListasGenerales listasGeneralesDao = new ListasGeneralesDaoImplement();

            (DTablasDomicilioInterno dTablasDomicilioInterno, string errorResponse) = await listasGeneralesDao.ListasTablasDomicilioInterno();


            return (dTablasDomicilioInterno, errorResponse);
        }
        //FIN RETORNAR TABLAS PARA DOMICILIO INTERNO..................................

        //RETORNAR TABLAS PARA EGRESO
        public async Task<(DTablasEgreso, string error)> ListasTablasEgreso()
        {
            IListasGenerales listasGeneralesDao = new ListasGeneralesDaoImplement();

            (DTablasEgreso dTablasEgreso, string errorResponse) = await listasGeneralesDao.ListasTablasEgreso();


            return (dTablasEgreso, errorResponse);
        }
        //FIN RETORNAR TABLAS PARA EGRESO..................................


        //RETORNAR TABLAS PARA HISTORIAL PROCESAL
        public async Task<(DTablasHistorialProcesal, string error)> ListasTablasHistorialProcesal()
        {
            IListasGenerales listasGeneralesDao = new ListasGeneralesDaoImplement();

            (DTablasHistorialProcesal tablasHistorialProcesal, string errorResponse) = await listasGeneralesDao.ListasTablasHistorialProcesal();


            return (tablasHistorialProcesal, errorResponse);
        }
        //FIN RETORNAR TABLAS PARA HISTORIAL PROCESAL..................................

        //RETORNAR TABLAS PARA INGRESO DE INTERNO
        public async Task<(DTablasIngresoInterno, string error)> ListasTablasIngresoInterno()
        {
            IListasGenerales listasGeneralesDao = new ListasGeneralesDaoImplement();

            (DTablasIngresoInterno tablasIngresoInterno, string errorResponse) = await listasGeneralesDao.ListasTablasUngresoInterno();


            return (tablasIngresoInterno, errorResponse);
        }
        //FIN RETORNAR TABLAS PARA INGRESO DE INTERNO..................................

        //RETORNAR TABLAS PARA PROGRESIVIDAD
        public async Task<(DTablasProgresividad, string error)> ListasTablasProgresividad()
        {
            IListasGenerales listasGeneralesDao = new ListasGeneralesDaoImplement();

            (DTablasProgresividad dTablasProgresividad, string errorResponse) = await listasGeneralesDao.ListasTablasProgresividad();


            return (dTablasProgresividad, errorResponse);
        }
        //FIN RETORNAR TABLAS PARA PROGRESIVIDAD..................................

    }
}
