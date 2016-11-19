using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace GestionAGA_WF.DataAccessLayer
{
    public class Tipo_NucleoDAL: DataAccessLayer.ICRUD<EntityLayer.Tipo_nucleo>
    {

        public string strConexion { get; set; }
       

        public List<EntityLayer.Tipo_nucleo> Select()
        {
            List<EntityLayer.Tipo_nucleo> list = new List<EntityLayer.Tipo_nucleo>();
            try
            {
                using (var con = new SqlConnection(strConexion))
                {
                    var query = new SqlCommand();
                    query.Connection = con;
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.CommandText = "[uspSelectTipoNucleo]";

                    con.Open();

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // estado
                            EntityLayer.Tipo_nucleo tipo = new EntityLayer.Tipo_nucleo()
                            {
                                Clv_Tipo = dr["Clv_Tipo"] is DBNull ? "" : dr["Clv_Tipo"].ToString(),
                                Tipo = dr["Tipo"] is DBNull ? "" : dr["Clv_Tipo"].ToString() + "-" + dr["Tipo"].ToString(),
                            };

                            list.Add(tipo);
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

        public bool Insert(EntityLayer.Tipo_nucleo objeto)
        {
            throw new NotImplementedException();
        }

        public bool UpDate(EntityLayer.Tipo_nucleo objeto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(EntityLayer.Tipo_nucleo objeto)
        {
            throw new NotImplementedException();
        }
    }
}
