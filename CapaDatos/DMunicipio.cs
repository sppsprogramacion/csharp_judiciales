﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DMunicipio
    {
        public int id_municipio { get; set; }
        public string municipio { get; set; }
        public string departamento_id { get; set; }
        public DDepartamento departamento { get; set; }
    }
}
