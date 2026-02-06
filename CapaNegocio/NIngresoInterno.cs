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
    public class NIngresoInterno
    {
        //CREAR INGRESO
        public async Task<(DIngresoInterno, string error)> CrearIngreso(string ingresoInterno)
        {
            IIngresoInernoDao ingresoInernoDao = new IngresoInternoDaoImplement();

            (DIngresoInterno ingresoResponse, string errorResponse) = await ingresoInernoDao.CrearIngreso(ingresoInterno);

            return (ingresoResponse, errorResponse);
        }
        //FIN CREAR INTERNO......................................................

        //RETORNAR  X ID INTERNO
        public async Task<(DIngresoInterno, string error)> BuscarxInterno(int id_interno)
        {
            IIngresoInernoDao ingresoInernoDao = new IngresoInternoDaoImplement();

            (DIngresoInterno dIngreso, string error) = await ingresoInernoDao.BuscarIngresoXInterno(id_interno);


            return (dIngreso, error);
        }
        //FIN RETORNAR  XID..................................

        //INGRESO DESDE OTRA UNIDAD
        public async Task<(bool, string error)> InresoDesdeOtraUnidad(int idIngreso, string dataIngreso)
        {
            IIngresoInernoDao ingresoInternoDao = new IngresoInternoDaoImplement();

            (bool ingresoResponse, string error) = await ingresoInternoDao.IngresoDesdeOtraUnidad(idIngreso, dataIngreso);

            return (ingresoResponse, error);
        }
        //FIN INGRESO DESDE OTRA UNIDAD..............................................................

        //EDITAR INGRESO
        public async Task<(bool, string error)> EditarIngreso(int idIngreso, string dataIngreso)
        {
            IIngresoInernoDao ingresoInternoDao = new IngresoInternoDaoImplement();

            (bool ingresoResponse, string error) = await ingresoInternoDao.EditarIngreso(idIngreso, dataIngreso);

            return (ingresoResponse, error);
        }
        //FIN EDITAR INGRESO..............................................................

        //RETORNAR X APELLIDO
        //public async Task<(List<DInterno>, string error)> ListaInternosXApellido(string apellido)
        //{
        //    IInternosDao internoDao = new InternoDaoImplement();

        //    (List<DInterno> listaInternos, string error) = await internoDao.ListaInternosXApellido(apellido);

        //    return (listaInternos, error);
        //}
        //FIN RETORNAR X APELLIDO..................................

        //RETORNAR  X ID
        //public async Task<(DInterno, string error)> BuscarInternoXID(int id)
        //{
        //    IInternosDao internosDao = new InternoDaoImplement();

        //    (DInterno dInterno, string error) = await internosDao.BuscarInternoXId(id);


        //    return (dInterno, error);
        //}
        //FIN RETORNAR  XID..................................
    }

}
