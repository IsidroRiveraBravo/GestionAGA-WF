using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.BusinessLayer
{
    public class usuarioBL
    {
        public string connectionStr { get; set; }

        DataAccessLayer.usuarioDAL userDal = new DataAccessLayer.usuarioDAL();

        public usuarioBL()
        {

        }


        //public usuarioBL(string strconexion)
        //{
        //    this.strConexion = strconexion;
        //    userDal = new DataAccessLayer.usuarioDAL(strconexion);
        //}

        public usuarioBL(string strconexion)
        {
            this.connectionStr = strconexion;
            userDal = new DataAccessLayer.usuarioDAL();
        }


        public bool Agregar(EntityLayer.Usuario user)
        {
            this.connectionStr = connectionStr;
            return userDal.Agregar(user); 
        }


        internal List<EntityLayer.Usuario> SelectCatalogo()
        {
            userDal.connectionStr = this.connectionStr;
            return userDal.SelectCatalogo();
        }

        public List<EntityLayer.Usuario> SelectUsuarioPwd(string usuario, string pwd)
        {
            userDal.connectionStr = connectionStr;
            return userDal.SelectUsuarioPwd(usuario, pwd);
        }

        public List<EntityLayer.Usuario> SelectCatalogo(string strconexion)
        {
            return userDal.SelectCatalogo(strconexion);
        }

        public List<EntityLayer.Usuario> Select()
        {
            throw new NotImplementedException();
        }

        

        public bool Modificar(string strConexion, EntityLayer.Usuario objeto)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(string strConexion, EntityLayer.Usuario objeto)
        {
            throw new NotImplementedException();
        }

        
    }
}
