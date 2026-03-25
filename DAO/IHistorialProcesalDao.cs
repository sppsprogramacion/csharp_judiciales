using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IHistorialProcesalDao
    {
        Task<(DHistorialProcesal, string error)> CrearHistorial(string historialProcesal);
        Task<(DHistorialProcesal, string error)> BuscarHistorialXId(int idHistorialProcesal);
        Task<(List<DHistorialProcesal>, string error)> ListaHistorialXIngreso(int idIgreso);
        Task<(List<DHistorialProcesal>, string error)> ListaHistorialXIngresoXTipoHistorial(int idIgreso, int idTipoHistorial);
        Task<(bool, string error)> EditarHistorial(int idCausa, string causa);
        Task<(bool, string error)> AnularHistorial(int idCausa, string dataAnular);
    }
}
