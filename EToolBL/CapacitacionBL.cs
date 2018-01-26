using EToolADO;
using EToolBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EToolBL
{
    public class CapacitacionBL
    {
        CapacitacionADO _CapacitacionADO = new CapacitacionADO();
        public List<CapacitacionBE> ListarCapacitacionO_Act()
        {
            return _CapacitacionADO.ListarCapacitacionO_Act();
        }
        public int InsertarCapacitacion(CapacitacionBE _CapacitacionBE)
        {
            return _CapacitacionADO.InsertarCapacitacion(_CapacitacionBE);
        }
        public bool EliminarCapacitacion(int _ElementoClave_id)
        {
            return _CapacitacionADO.EliminarCapacitacion(_ElementoClave_id);
        }
        public bool ActualizarCapacitacion(CapacitacionBE _CapacitacionBE)
        {
            return _CapacitacionADO.ActualizarCapacitacion(_CapacitacionBE);
        }
        public CapacitacionBE TraerCapacitacion(int Id)
        {
            return _CapacitacionADO.TraerCapacitacion(Id);
        }
        public DataTable ListarCapacitacionFind(string Nombres, string IdEtto, DateTime FechaIni, DateTime FechaFin)
        {
            return _CapacitacionADO.ListarCapacitacionFind(Nombres, IdEtto, FechaIni, FechaFin);
        }
    }
}
