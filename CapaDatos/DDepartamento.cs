﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DDepartamento
    {
        public int id_departamento { get; set; }
        public string departamento { get; set; }
        public string provincia_id { get; set; }
        public DProvincia provincia { get; set;}
    }
}
