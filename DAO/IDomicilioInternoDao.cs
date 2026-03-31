using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IDomicilioInternoDao
    {
        Task<(DDomicilioInterno, string error)> CrearDomicilio(string domicilioInterno);
        Task<(DDomicilioInterno, string error)> BuscarDomicilioXId(int idDomicilio);
        Task<(List<DDomicilioInterno>, string error)> ListaDomiciliosXInterno(int idInterno);
        Task<(bool, string error)> EditarDomicilio(int idDomicilio, string domicilioInterno);
        Task<(bool, string error)> AnularDomicilio(int idDomicilio, string dataAnular);
    }
}
