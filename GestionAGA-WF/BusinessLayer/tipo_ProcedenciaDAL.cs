using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace GestionAGA_WF.DataAccessLayer
{
    public class tipo_ProcedenciaDAL: DataAccessLayer.ICRUD<EntityLayer.Tipo_Procedencia>
    {

        public string strConexion { get; set; }
       
        public List<EntityLayer.Tipo_Procedencia> Select()
        {
            List<EntityLayer.Tipo_Procedencia> cat_edoList = new List<EntityLayer.Tipo_Procedencia>();

            try
            {
                using (var con = new SqlConnection(strConexion))
                {
                    var query = new SqlCommand();
                    query.Connection = con;
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.CommandText = "uspSelectTipo_Procedencia";

                    con.Open();

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // estado
                            EntityLayer.Tipo_Procedencia entity = new EntityLayer.Tipo_Procedencia
                            {
                                Clv_TipoProc = dr["Clv_TipoProc"] is DBNull ? 0: Convert.ToInt32(dr["Clv_TipoProc"].ToString()),
                                Des_TipoProc = dr["Des_TipoProc"] is DBNull ?  "": dr["Clv_TipoProc"].ToString() + "-"+  dr["Des_TipoProc"].ToString(), 
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

        public bool Insert(EntityLayer.Tipo_Procedencia objeto)
        {
            throw new NotImplementedException();
        }

        public bool UpDate(EntityLayer.Tipo_Procedencia objeto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(EntityLayer.Tipo_Procedencia objeto)
        {
            throw new NotImplementedException();
        }
    }
}
