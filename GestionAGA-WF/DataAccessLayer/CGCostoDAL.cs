using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.DataAccessLayer
{
    public class CGCostoDAL : ICRUD<EntityLayer.CGCostoE>
    {

        public string strConexion { get; set; }
       

        public List<EntityLayer.CGCostoE> Select()
        {
            List<EntityLayer.CGCostoE> list = new List<EntityLayer.CGCostoE>();



            return list;
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
