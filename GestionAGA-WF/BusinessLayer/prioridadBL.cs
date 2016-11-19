using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.BusinessLayer
{
    public class prioridadBL: DataAccessLayer.ICRUD<EntityLayer.Prioridad>
    {

        public string strConexion { get; set; }
        DataAccessLayer.prioridadDAL dal = new DataAccessLayer.prioridadDAL();
       

        public List<EntityLayer.Prioridad> Select()
        {
            dal.strConexion = strConexion;
            return dal.Select();
        }

        public bool Insert(EntityLayer.Prioridad objeto)
        {
            throw new NotImplementedException();
        }

        public bool UpDate(EntityLayer.Prioridad objeto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(EntityLayer.Prioridad objeto)
        {
            throw new NotImplementedException();
        }
    }
}
