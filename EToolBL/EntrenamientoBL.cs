using EToolADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EToolBL
{
    public class EntrenamientoBL
    {
        EntrenamientoADO _EntrenamientoADO = new EntrenamientoADO();
        public DataTable ListarEntrenamiento_All()
        {
            return _EntrenamientoADO.ListarEntrenamiento_All();
        }
    }
}
