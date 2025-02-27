﻿using CapaDatos;
using DAO;
using DAOImplement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NAuth
    {
        //LOGIN
        public async Task<(bool, string)> LoginUsuario(string dataLogin)
        {
            IAuthDao authDao = new AuthDaoImpl();

            (bool acceso, string error) = await authDao.LoginUsuario(dataLogin);

            return (acceso, error);
        }
        //FIN LOGIN..................................
    }
}
