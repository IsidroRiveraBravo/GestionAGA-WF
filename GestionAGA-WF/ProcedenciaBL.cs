using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionAGA_WF.BusinessLayer
{
    internal class ProcedenciaBL: DataAccessLayer.ICRUD<EntityLayer.Procedencia>
    {
        public string strConexion { get; set; }
        DataAccessLayer.ProcedenciaDAL dal = new DataAccessLayer.ProcedenciaDAL();


        public List<EntityLayer.Procedencia> Select()
        {
            dal.strConexion = strConexion;
            return dal.Select();
        }

        public bool Insert(EntityLayer.Procedencia objeto)
        {
            throw new NotImplementedException();
        }

        public bool UpDate(EntityLayer.Procedencia objeto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(EntityLayer.Procedencia objeto)
        {
            throw new NotImplementedException();
        }
    }
}
