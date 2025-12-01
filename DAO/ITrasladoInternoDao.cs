using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface ITrasladoInternoDao
    {
        Task<(DTrasladoInterno, string error)> CrearTraslado(string trasladoInterno);        
        Task<(DTrasladoInterno, string error)> BuscarTrasladoXId(int idTraslado);
        Task<(List<DTrasladoInterno>, string error)> ListaTrasladosXIngreso(int idIngreso);
        Task<(List<DTrasladoInterno>, string error)> ListaTrasladosPendientesXOrganismo(int idOrganismo);
        Task<(List<DTrasladoInterno>, string error)> ListaTrasladosPendientesXMiOrganismo();
        Task<(bool, string error)> AnularTraslado(int idTraslado, string dataAnular);
        Task<(bool, string error)> AceptarTraslado(int idTraslado, string dataAceptar);
        Task<(bool, string error)> RechazarTraslado(int idTraslado, string dataRechazar);
    }
}
