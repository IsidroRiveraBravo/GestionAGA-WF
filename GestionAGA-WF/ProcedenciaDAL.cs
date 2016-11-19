using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace GestionAGA_WF.DataAccessLayer
{
    internal class ProcedenciaDAL : DataAccessLayer.ICRUD<EntityLayer.Procedencia>
    {

        public string strConexion { get; set; }
      

        public List<EntityLayer.Procedencia> Select()
        {
            List<EntityLayer.Procedencia> list = new List<EntityLayer.Procedencia>();
            try
            {
                using (SqlConnection con =  new SqlConnection(strConexion))
                {
                    var query = new SqlCommand();
                    query.Connection = con;
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.CommandText = "uspSelectProcedencia";

                    con.Open();

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // estado
                            var entity = new EntityLayer.Procedencia
                            {
                                Clv_TipoProc = dr["Clv_TipoProc"] is DBNull ? 0:  Convert.ToInt32(dr["Clv_TipoProc"].ToString()),
                                Clv_Proc = dr["Clv_Proc"] is DBNull ? 0:  Convert.ToInt32(dr["Clv_Proc"].ToString()),
                                Des_Proc = dr["Des_Proc"] is DBNull ? "": dr["Clv_Proc"].ToString() + "-" + dr["Des_Proc"].ToString(),

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

        public bool Insert(EntityLayer.Procedencia objeto)
        {
            throw new NotImplementedException();
        }

        public bool UpDate(EntityLayer.Procedencia objeto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(EntityLayer.Procedencia objeto)
        {
            throw new NotImplementedException();
        }
    }
}
