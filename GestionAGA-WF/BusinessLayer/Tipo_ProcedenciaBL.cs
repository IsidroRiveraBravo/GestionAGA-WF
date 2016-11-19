using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.BusinessLayer
{
    public class Tipo_ProcedenciaBL: DataAccessLayer.ICRUD<EntityLayer.Tipo_Procedencia>
    {

        public string strConexion { get; set; }
        DataAccessLayer.tipo_ProcedenciaDAL dal = new DataAccessLayer.tipo_ProcedenciaDAL();
        
        public List<EntityLayer.Tipo_Procedencia> Select()
        {
            dal.strConexion = strConexion;
            return dal.Select();
        }

        public bool Insert(EntityLayer.Tipo_Procedencia objeto)
        {
            throw new NotImplementedException();
        }

        public bool UpDate(EntityLayer.Tipo_Procedencia objeto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(EntityLayer.Tipo_Procedencia objeto)
        {
            throw new NotImplementedException();
        }
    }
}
