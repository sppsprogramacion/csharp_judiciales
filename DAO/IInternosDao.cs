using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IInternosDao
    {
        Task<(DInterno, string error)> CrearInterno(string interno);
        Task<(bool, string error)> EditarInterno(int id, string prohibicionVisita);
        Task<(DInterno, string error)> BuscarInternoXId(int idInterno);
        Task<(List<DInterno>, string error)> ListaInternosXApellido(string apellido);
        Task<(List<DInterno>, string error)> ListaInternosTodos();
    }
}
