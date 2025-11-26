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
        Task<(List<DIngresoInterno>, string error)> ListaIngresosXInterno(int idInterno);
    }
}
