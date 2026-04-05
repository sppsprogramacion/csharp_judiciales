using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IListasGenerales
    {
        Task<(DCaracteristicasPersonales, string error)> ListasCaracteristicasPersonales();

        Task<(DDatosFiliatorios, string error)> ListasDatosFiliatorios();
        Task<(DTablasIngresoInterno, string error)> ListasTablasUngresoInterno();
        Task<(DTablasCausa, string error)> ListasTablasCausa();
        Task<(DTablasHistorialProcesal, string error)> ListasTablasHistorialProcesal();
        Task<(DTablasDomicilioInterno, string error)> ListasTablasDomicilioInterno();
    }
}
