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
        Task<(bool, string error)> EditarDatosPersonales(int id, string datosPErsonales);
        Task<(bool, string error)> EditarCaracteristicasPersonales(int id, string caracteristicasPersonales);
        Task<(bool, string error)> EditarDatosFiliatorios(int id, string datosFiliatorios);
        Task<(DInterno, string error)> BuscarInternoXId(int idInterno);
        Task<(List<DInterno>, string error)> ListaInternosXApellido(string apellido);
        Task<(List<DInterno>, string error)> ListaInternosXApellidoGeneral(string apellido);
        Task<(List<DInterno>, string error)> ListaInternosXProntuario(int apellido);
        Task<(List<DInterno>, string error)> ListaInternosTodos();

        Task<(bool, string error)> subirImagen(int id, string rutaImagen, string tipo_foto);
        Task<(bool, string error)> quitarImagen(int id);
    }
}
