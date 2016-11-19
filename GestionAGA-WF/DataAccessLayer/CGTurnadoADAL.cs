using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionAGA_WF.DataAccessLayer;

namespace GestionAGA_WF.DataAccessLayer
{
    public class CGTurnadoADAL: ICRUD<EntityLayer.CGTurnadoAE>
    {

        // propiedades
        public string strConexion {get; set;}
        
        public List<EntityLayer.CGTurnadoAE> Select() 
        {
            throw new NotImplementedException();
        }

        public bool Insert(EntityLayer.CGTurnadoAE objeto)
        {
            throw new NotImplementedException();
        }

        public bool UpDate(EntityLayer.CGTurnadoAE objeto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(EntityLayer.CGTurnadoAE objeto)
        {
            throw new NotImplementedException();
        }

    }
}
