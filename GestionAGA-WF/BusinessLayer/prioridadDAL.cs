using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace GestionAGA_WF.DataAccessLayer
{
    public class prioridadDAL: DataAccessLayer.ICRUD<EntityLayer.Prioridad>
    {
        // propiedades
        public string strConexion { get; set; }
        

        public List<EntityLayer.Prioridad> Select()
        {
            List<EntityLayer.Prioridad> cat_edoList = new List<EntityLayer.Prioridad>();

            try
            {
                using (var con = new SqlConnection(strConexion))
                {
                    var query = new SqlCommand();
                    query.Connection = con;
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.CommandText = "uspSelectPrioridad";                  
                    con.Open();

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // 
                            var entity = new EntityLayer.Prioridad
                            {
                                Cve_Prioridad = dr["Cve_Prioridad"] is DBNull ? "" : dr["Cve_Prioridad"].ToString(),
                                Des_Prioridad = dr["Des_Prioridad"] is DBNull ? "" : dr["Cve_Prioridad"].ToString() + "-" + dr["Des_Prioridad"].ToString(),
                                Periodo = dr["Periodo"] is DBNull ? 0 : Convert.ToInt32(dr["Periodo"].ToString())
                            };

                            cat_edoList.Add(entity);
                        }

                    }


                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return cat_edoList;
        }

        public bool Insert(EntityLayer.Prioridad objeto)
        {
            throw new NotImplementedException();
        }

        public bool UpDate(EntityLayer.Prioridad objeto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(EntityLayer.Prioridad objeto)
        {
            throw new NotImplementedException();
        }
    }
}
