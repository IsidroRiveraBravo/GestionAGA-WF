using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;


namespace GestionAGA_WF.DataAccessLayer
{
    internal class Grupo_DocumentalDAL: DataAccessLayer.ICRUD<EntityLayer.Grupo_Documental>
    {
        public string strConexion { get; set; }


        public List<EntityLayer.Grupo_Documental> Select()
        {
            List<EntityLayer.Grupo_Documental> list = new List<EntityLayer.Grupo_Documental>();
            try
            {
                using (SqlConnection con = new SqlConnection(strConexion))
                {
                    SqlCommand query = new SqlCommand();
                    query.Connection = con;
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.CommandText = "[uspSelectGrupo_Documental]";

                    con.Open();
                    using (SqlDataReader dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntityLayer.Grupo_Documental entity =  new EntityLayer.Grupo_Documental()
                            {
                                Clv_GpoDoc = dr["Clv_GpoDoc"] is DBNull ? 0 : Convert.ToInt32(dr["Clv_GpoDoc"].ToString()),
                                Hom_GpoDoc = dr["Hom_GpoDoc"] is DBNull ? "" : dr["Hom_GpoDoc"].ToString(),
                                Des_GpoDoc = dr["Des_GpoDoc"] is DBNull ? "" : dr["Clv_GpoDoc"].ToString() + "-" + dr["Des_GpoDoc"].ToString(),
                            } ;

                            list.Add(entity);
                        }
                        
                    }
                    
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

            return list;
            
        }

        public bool Insert(EntityLayer.Grupo_Documental objeto)
        {
            throw new NotImplementedException();
        }

        public bool UpDate(EntityLayer.Grupo_Documental objeto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(EntityLayer.Grupo_Documental objeto)
        {
            throw new NotImplementedException();
        }
    }
}
