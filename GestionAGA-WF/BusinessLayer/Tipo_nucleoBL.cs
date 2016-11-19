using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.BusinessLayer
{
    public class Tipo_nucleoBL: DataAccessLayer.ICRUD<EntityLayer.Tipo_nucleo>
    {
        public string strConexion { get; set; }
        public DataAccessLayer.Tipo_NucleoDAL dal = new DataAccessLayer.Tipo_NucleoDAL();

        public List<EntityLayer.Tipo_nucleo> Select()
        {
            dal.strConexion = strConexion;
            return dal.Select();
        }

        public bool Insert(EntityLayer.Tipo_nucleo objeto)
        {
            throw new NotImplementedException();
        }

        public bool UpDate(EntityLayer.Tipo_nucleo objeto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(EntityLayer.Tipo_nucleo objeto)
        {
            throw new NotImplementedException();
        }
    }
}
