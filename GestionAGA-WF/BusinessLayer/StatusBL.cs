using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.BusinessLayer
{
    internal class StatusBL: DataAccessLayer.ICRUD<EntityLayer.Status>
    {

        public string strConexion {get; set;}
        DataAccessLayer.statusDAL dal = new DataAccessLayer.statusDAL();

       
        public List<EntityLayer.Status> Select()
        {
            dal.strConexion = strConexion;
            return dal.Select();
        }

        public bool Insert(EntityLayer.Status objeto)
        {
            throw new NotImplementedException();
        }

        public bool UpDate(EntityLayer.Status objeto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(EntityLayer.Status objeto)
        {
            throw new NotImplementedException();
        }
    }
}
