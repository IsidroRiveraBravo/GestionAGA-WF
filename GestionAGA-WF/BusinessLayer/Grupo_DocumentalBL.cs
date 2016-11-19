using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.BusinessLayer
{
    public class Grupo_DocumentalBL: DataAccessLayer.ICRUD<EntityLayer.Grupo_Documental>
    {

        public string strConexion { get; set; }
        DataAccessLayer.Grupo_DocumentalDAL dal = new DataAccessLayer.Grupo_DocumentalDAL();

        public List<EntityLayer.Grupo_Documental> Select()
        {
            dal.strConexion = strConexion;
            return dal.Select();
        }

        public bool Insert(EntityLayer.Grupo_Documental objeto)
        {
            throw new NotImplementedException();
        }

        public bool UpDate(EntityLayer.Grupo_Documental objeto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(EntityLayer.Grupo_Documental objeto)
        {
            throw new NotImplementedException();
        }
    }
}
