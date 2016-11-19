using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionAGA_WF.BusinessLayer
{
    public class ControlGestionAGABL
    {
        public string strConexion { get; set; }
        public DataAccessLayer.ControlGestionAGADAL detaDal = new DataAccessLayer.ControlGestionAGADAL();

        public ControlGestionAGABL()
        { 

        }

        public ControlGestionAGABL(string strconexion)
        {
            this.strConexion = strconexion;
        }

        public bool Insert(EntityLayer.ControlGestionAGA objControlGestionAGA)
        {
            detaDal.strConexion = strConexion;
            return detaDal.Insert(objControlGestionAGA);
        }
    }
}
