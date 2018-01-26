using EToolADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EToolBL
{
    public class TBLUsuariosBL
    {
        TBLUsuariosADO _TBLUsuarioADO = new TBLUsuariosADO();
        public DataTable ListarTBLUsuario_All()
        {
            return _TBLUsuarioADO.ListarTBLUsuario_All();
        }

        public object ListarTBLUsuario_Act()
        {
            return _TBLUsuarioADO.ListarTBLUsuario_Act();
        }
    }
}
