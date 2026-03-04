using CapaDatos;
using DAO;
using DAOImplement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NInterno
    {
        //CREAR INTERNO
        public async Task<(DInterno, string error)> CrearInterno(string interno)
        {
            IInternosDao internoDao = new InternoDaoImplement();

            (DInterno internoResponse, string errorResponse) = await internoDao.CrearInterno(interno);

            return (internoResponse, errorResponse);
        }
        //FIN CREAR INTERNO......................................................


        //RETORNAR X APELLIDO
        public async Task<(List<DInterno>, string error)> ListaInternosXApellido(string apellido)
        {
            IInternosDao internoDao = new InternoDaoImplement();

            (List<DInterno> listaInternos, string error) = await internoDao.ListaInternosXApellido(apellido);

            return (listaInternos, error);
        }
        //FIN RETORNAR X APELLIDO..................................

        //RETORNAR X APELLIDO GENERAL
        public async Task<(List<DInterno>, string error)> ListaInternosXApellidoGeneral(string apellido)
        {
            IInternosDao internoDao = new InternoDaoImplement();

            (List<DInterno> listaInternos, string error) = await internoDao.ListaInternosXApellidoGeneral(apellido);

            return (listaInternos, error);
        }
        //FIN RETORNAR X APELLIDO GENERAL..................................

        //RETORNAR X APELLIDO
        public async Task<(List<DInterno>, string error)> ListaInternosXProntuario(int prontuario)
        {
            IInternosDao internoDao = new InternoDaoImplement();

            (List<DInterno> listaInternos, string error) = await internoDao.ListaInternosXProntuario(prontuario);

            return (listaInternos, error);
        }
        //FIN RETORNAR X APELLIDO..................................

        //RETORNAR  X ID
        public async Task<(DInterno, string error)> BuscarInternoXID(int id)
        {
            IInternosDao internosDao = new InternoDaoImplement();

            (DInterno dInterno, string error) = await internosDao.BuscarInternoXId(id);


            return (dInterno, error);
        }
        //FIN RETORNAR  XID..................................

        //EDITAR DATOS PERSONALES
        public async Task<(bool, string error)> EditarDatosPersonales(int idInterno, string dataEdicion)
        {
            IInternosDao internosDao = new InternoDaoImplement();

            (bool internosResponse, string error) = await internosDao.EditarDatosPersonales(idInterno, dataEdicion);

            return (internosResponse, error);
        }
        //FIN EDITAR DATOS PERSONALES..............................................................

        //EDITAR CARACTERISTICAS PERSONALES
        public async Task<(bool, string error)> EditarCaracteristicasPersonales(int idInterno, string dataEdicion)
        {
            IInternosDao internosDao = new InternoDaoImplement();

            (bool internosResponse, string error) = await internosDao.EditarCaracteristicasPersonales(idInterno, dataEdicion);

            return (internosResponse, error);
        }
        //FIN EDITAR CARACTERISTICAS PERSONALES..............................................................

        //EDITAR DATOS FILIATORIOS
        public async Task<(bool, string error)> EditarDatosFiliatorios(int idInterno, string dataEdicion)
        {
            IInternosDao internosDao = new InternoDaoImplement();

            (bool internosResponse, string error) = await internosDao.EditarDatosFiliatorios(idInterno, dataEdicion);

            return (internosResponse, error);
        }
        //FIN EDITAR DATOS FILIATORIOS..............................................................

        //SUBIR IMAGEN
        public async Task<(bool, string error)> subirImagen(int id, string rutaImagen, string tipo_foto)
        {
            IInternosDao internosDao = new InternoDaoImplement();

            (bool internoResponse, string error) = await internosDao.subirImagen(id, rutaImagen, tipo_foto);

            return (internoResponse, error);
        }
        //FIN SUBIR IMAGEN..................................
    }
}
