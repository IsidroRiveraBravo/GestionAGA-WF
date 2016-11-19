using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionAGA_WF.DataAccessLayer;

namespace GestionAGA_WF.BusinessLayer
{
    public class CGCostoBL : ICRUD<EntityLayer.CGCostoE>
    {

        public string strConexion { get; set; }
        public DataAccessLayer.CGCostoDAL costoDal = new CGCostoDAL();

        public List<EntityLayer.CGCostoE> Select()
        {
            return costoDal.Select();
        }

        public bool Insert(EntityLayer.CGCostoE objeto)
        {
            throw new NotImplementedException();
        }

        public bool UpDate(EntityLayer.CGCostoE objeto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(EntityLayer.CGCostoE objeto)
        {
            throw new NotImplementedException();
        }
    }
}
