using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;


namespace GestionAGA_WF.DataAccessLayer
{
    internal class statusDAL: DataAccessLayer.ICRUD<EntityLayer.Status>
    {

        public string strConexion { get; set; }
       

        public List<EntityLayer.Status> Select()
        {
            List<EntityLayer.Status> list = new List<EntityLayer.Status>();
            try
            {
                using (var con = new SqlConnection(strConexion))
                {
                    var query = new SqlCommand();
                    query.Connection = con;
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.CommandText = "[uspSelectStatus]";

                    con.Open();

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // estado
                            EntityLayer.Status entity = new EntityLayer.Status()
                            {
                                Clv_Status = dr["Clv_Status"] is DBNull ? "" : dr["Clv_Status"].ToString().Trim(),
                                status = dr["status"] is DBNull ? "" : dr["Clv_Status"].ToString().Trim() + "-"+ dr["status"].ToString()
                            };

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

        public bool Insert(EntityLayer.Status objeto)
        {
            throw new NotImplementedException();
        }

        public bool UpDate(EntityLayer.Status objeto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(EntityLayer.Status objeto)
        {
            throw new NotImplementedException();
        }
    }
}
