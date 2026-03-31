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
    public class NDomicilioInterno
    {
        //CREAR DOMICILIO
        public async Task<(DDomicilioInterno, string error)> CrearDomicilio(string causa)
        {
            IDomicilioInternoDao domicilioDao = new DomicilioInternoDaoImpl();

            (DDomicilioInterno domicilioResponse, string errorResponse) = await domicilioDao.CrearDomicilio(causa);

            return (domicilioResponse, errorResponse);
        }
        //FIN CREAR DOMICILIO......................................................

        //LISTA DE DOMICILIO X interno
        public async Task<(List<DDomicilioInterno>, string error)> ListaDomiciliosXInterno(int idInterno)
        {
            IDomicilioInternoDao domicilioDao = new DomicilioInternoDaoImpl();

            (List<DDomicilioInterno> listaDomicilio, string errorResponse) = await domicilioDao.ListaDomiciliosXInterno(idInterno);

            return (listaDomicilio, errorResponse);
        }
        //FIN LISTA DE CAUSAS X INGRESO..................................

        //RETORNAR  X ID DOMICILIO
        public async Task<(DDomicilioInterno, string error)> BuscarxIdDomicilio(int idDomicilio)
        {
            IDomicilioInternoDao domicilioDao = new DomicilioInternoDaoImpl();

            (DDomicilioInterno domicilioResponse, string errorResponse) = await domicilioDao.BuscarDomicilioXId(idDomicilio);

            return (domicilioResponse, errorResponse);
        }
        //FIN RETORNAR  XID DOMICILIO.......................................................................

        //MODIFICAR UN DOMICILIO
        public async Task<(bool, string error)> EditarDomicilio(int idDomicilio, string dataDomicilio)
        {
            IDomicilioInternoDao domicilioDao = new DomicilioInternoDaoImpl();

            (bool domicilioResponse, string error) = await domicilioDao.EditarDomicilio(idDomicilio, dataDomicilio);

            return (domicilioResponse, error);
        }
        //FIN MODIFICAR UN DOMICILIO........................................................................
    }
}
