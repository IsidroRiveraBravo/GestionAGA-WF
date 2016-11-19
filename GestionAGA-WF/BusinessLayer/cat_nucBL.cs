using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.BusinessLayer
{
    public class cat_nucBL: DataAccessLayer.ICRUD<EntityLayer.cat_nuc>
    {
        public string strConexion { get; set; }
        DataAccessLayer.cat_nucDAL dal = new DataAccessLayer.cat_nucDAL();

        public List<EntityLayer.cat_nuc> Select(string pSCNCve_Edo, string pSCNCve_Mun, string pSCNTipo_Nuc)
        {
            dal.strConexion = strConexion;
            return dal.Select(pSCNCve_Edo, pSCNCve_Mun, pSCNTipo_Nuc);
        }

        public List<EntityLayer.cat_nuc> Select()
        {
            throw new NotImplementedException();
        }

        public bool Insert(EntityLayer.cat_nuc objeto)
        {
            throw new NotImplementedException();
        }

        public bool UpDate(EntityLayer.cat_nuc objeto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(EntityLayer.cat_nuc objeto)
        {
            throw new NotImplementedException();
        }
    }
}
