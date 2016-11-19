using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace GestionAGA_WF.BusinessLayer
{
    public class ControlDeGestion2016BL
    {
        // propiedades
        public string strConexion { get; set; }
        public DataAccessLayer.ControlDeGestion2016DAL dal = new DataAccessLayer.ControlDeGestion2016DAL();

        public ControlDeGestion2016BL()
        {
           
        }

        internal List<EntityLayer.repProdInstitucionales> RepProdInstitucionales(DateTime dateTime1, DateTime dateTime2)
        {
            dal.strConexion = strConexion;
            return dal.RepProdInstitucionales();
        }

        public List<EntityLayer.repProdParticulares> RepProdParticulares(DateTime dateTime1, DateTime dateTime2)
        {
            dal.strConexion = strConexion;
            return dal.RepProdParticulares();
        }



        public bool UpDate(EntityLayer.ControlDeGestion2016 ctrlE)
        {
            dal.strConexion = this.strConexion;
            return dal.UpDate(ctrlE);
        }

        public bool Insert(EntityLayer.ControlDeGestion2016 ctrlE)
        {
            dal.strConexion = this.strConexion;
            return dal.Insert(ctrlE);
        }


        public List<EntityLayer.ControlDeGestion2016> Select()
        {
            dal.strConexion = this.strConexion;
            return dal.Select();
        }




       
    }
}
