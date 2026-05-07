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
        Task<(DTablasCausa, string error)> ListasTablasCausa();
        Task<(DTablasConductaConcepto, string error)> ListasTablasConductaConcepto();
        Task<(DTablasDomicilioInterno, string error)> ListasTablasDomicilioInterno();
        Task<(DTablasEgreso, string error)> ListasTablasEgreso();
        Task<(DTablasHistorialProcesal, string error)> ListasTablasHistorialProcesal();
        Task<(DTablasIngresoInterno, string error)> ListasTablasUngresoInterno();
        Task<(DTablasProgresividad, string error)> ListasTablasProgresividad();
    }
}
