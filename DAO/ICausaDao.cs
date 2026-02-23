using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface ICausaDao
    {
        Task<(DCausa, string error)> CrearCausa(string causa);
        Task<(DCausa, string error)> BuscarCausaXId(int idCausa);
        Task<(List<DCausa>, string error)> ListaCausasXIngreso(int idIgreso);
        Task<(bool, string error)> EditarCausa(int idCausa, string causa);
        Task<(bool, string error)> AnularCausa(int idCausa, string dataAnular);
        Task<(bool, string error)> EstablecerCondena(int idCausa, string dataCondena);
    }
}
