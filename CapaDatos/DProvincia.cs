﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DProvincia
    {
        public string id_provincia { get; set; }
        public string provincia { get; set; }
        public string pais_id { get; set; }
        public DPais pasis { get; set; }
    }
}
