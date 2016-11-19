using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.BusinessLayer
{
    public class cat_munBL
    {
        public string connectionStr { get; set; }
        public DataAccessLayer.cat_munDAL munDal = new DataAccessLayer.cat_munDAL();

        public List<EntityLayer.cat_mun> Select(string connectionStr, string SCMCve_Edo)
        {
            munDal.connectionStr = connectionStr;
            return munDal.Select(connectionStr, SCMCve_Edo);
        }

        public List<EntityLayer.cat_mun> Select(string connectionStr, EntityLayer.cat_mun municipio)
        {
            munDal.connectionStr = connectionStr;
            return munDal.Select(connectionStr, municipio);
        }
    }
}
