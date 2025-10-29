using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IDepartamentoDao
    {//inicio clased

        DDepartamento buscarDepartamentoXId(int id);

        Task<(List<DDepartamento>, string error)> retornarListaDepartamentoXProvincia(string provincia_id);
    }//fin clase
}
