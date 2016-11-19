using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.DataAccessLayer
{
    public class CGFirmaDAL : ICRUD<EntityLayer.CGFirmaE>
    {

        public string strConexion { get; set; }
        

        public List<EntityLayer.CGFirmaE> Select()
        {
            throw new NotImplementedException();
        }

        public bool Insert(EntityLayer.CGFirmaE objeto)
        {
            throw new NotImplementedException();
        }

        public bool UpDate(EntityLayer.CGFirmaE objeto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(EntityLayer.CGFirmaE objeto)
        {
            throw new NotImplementedException();
        }
    }
}
