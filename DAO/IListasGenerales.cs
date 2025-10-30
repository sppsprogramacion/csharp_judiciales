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
    }
}
