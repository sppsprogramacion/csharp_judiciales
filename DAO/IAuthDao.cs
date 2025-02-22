﻿using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IAuthDao
    {
        Task<(bool, string)> LoginUsuario(string dataLogin);
    }
}
