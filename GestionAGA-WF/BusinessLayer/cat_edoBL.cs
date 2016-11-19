using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionAGA_WF.DataAccessLayer;


namespace GestionAGA_WF.BusinessLayer
{
    /// <summary>
    /// Catálogo de Estado
    /// </summary>
    public class cat_edoBL 
    {
        cat_edoDAL edodal = new cat_edoDAL();

        internal bool Eliminar(string connectionStr, EntityLayer.cat_edo edo)
        {
            return edodal.Eliminar(connectionStr, edo);
        }

        public List<EntityLayer.cat_edo> Select(string connectionStr)
        {
            return edodal.Select(connectionStr);
        }

        public List<EntityLayer.cat_edo> SelectCat(string connectionStr)
        {
            return edodal.SelectCat(connectionStr);
        }

        public bool Agregar(string connectionStr, EntityLayer.cat_edo edo)
        {
            return edodal.Agregar(connectionStr, edo);
        }

        internal bool Modificar(string connectionStr, EntityLayer.cat_edo edo)
        {
            return edodal.Modificar(connectionStr, edo);
        }
    }
}
