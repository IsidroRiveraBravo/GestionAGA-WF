using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.DataAccessLayer
{
    public class CGPagosDAL : ICRUD<EntityLayer.CGPagosE>
    {

        public string strConexion { get; set; }
       

        public List<EntityLayer.CGPagosE> Select()
        {
            throw new NotImplementedException();
        }

        public bool Insert(EntityLayer.CGPagosE objeto)
        {
            throw new NotImplementedException();
        }

        public bool UpDate(EntityLayer.CGPagosE objeto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(EntityLayer.CGPagosE objeto)
        {
            throw new NotImplementedException();
        }
    }
}
