using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IIngresoInernoDao
    {
        Task<(DIngresoInterno, string error)> CrearIngreso(string ingresoInterno);
        Task<(bool, string error)> EditarIngreso(int id, string ingresoInterno);
        Task<(DIngresoInterno, string error)> BuscarIngresoXId(int idIngreso);
        Task<(DIngresoInterno, string error)> BuscarIngresoXInterno(int idInterno);
        Task<(List<DConteoIngresos>, string error)> ContarIngresosXOrganismo();
        Task<(List<DIngresoInterno>, string error)> ListaIngresosXInterno(int idInterno);
        Task<(bool, string error)> EgresoInterno(int idIngreso, string dataEgreso);
        Task<(bool, string error)> EstablecerAlojamiento(int idIngreso, string dataAlojamiento);
        Task<(bool, string error)> EstablecerConductaConcepto(int idIngreso, string dataConductaConcepto);
        Task<(bool, string error)> EstablecerProgresividad(int idIngreso, string dataProgresividad);
        Task<(bool, string error)> IngresoDesdeOtraUnidad(int idIngreso, string dataIngreso);
    }
}
