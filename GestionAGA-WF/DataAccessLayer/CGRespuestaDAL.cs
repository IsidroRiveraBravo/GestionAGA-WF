using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.DataAccessLayer
{
    public class CGRespuestaDAL : ICRUD<EntityLayer.CGRespuestaE>
    {

        public string strConexion { get; set; }
        

        public List<EntityLayer.CGRespuestaE> Select()
        {
            throw new NotImplementedException();
        }

        public bool Insert(EntityLayer.CGRespuestaE objeto)
        {
            throw new NotImplementedException();
        }

        public bool UpDate(EntityLayer.CGRespuestaE objeto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(EntityLayer.CGRespuestaE objeto)
        {
            throw new NotImplementedException();
        }
    }
}
