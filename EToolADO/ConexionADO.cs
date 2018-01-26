using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
namespace EToolADO
{
    public class ConexionADO
    {
        public string GetCnx()
        {

            string strCnx = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;
            if (object.ReferenceEquals(strCnx, string.Empty))
            {
                return string.Empty;
            }
            else
            {
                return strCnx;
            }
        }
        
    }
}

