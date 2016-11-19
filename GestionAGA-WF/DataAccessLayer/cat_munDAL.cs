using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace GestionAGA_WF.DataAccessLayer
{
    public class cat_munDAL
    {
        // propiedades
        public string connectionStr { get; set; }


        internal List<EntityLayer.cat_mun> Select(string connectionStr, EntityLayer.cat_mun municipio)
        {
            List<EntityLayer.cat_mun> list = new List<EntityLayer.cat_mun>();

            try
            {
                using (var con = new SqlConnection(connectionStr))
                {
                    var query = new SqlCommand();
                    query.Connection = con;
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.CommandText = "uspSelectMunicipio";

                    query.Parameters.Add(new SqlParameter("@pSCMCve_Edo", municipio.SCMCve_Edo));

                    con.Open();

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // estado
                            EntityLayer.cat_mun mun = new EntityLayer.cat_mun()
                            {
                                SCMCve_Edo = dr["SCMCve_Edo"] is DBNull ? "" : dr["SCMCve_Edo"].ToString(),
                                SCMCve_Mun = dr["SCMCve_Mun"] is DBNull ? "" : dr["SCMCve_Mun"].ToString(),
                                SCMNom_Mun = dr["SCMNom_Mun"] is DBNull ? "" : dr["SCMCve_Edo"].ToString() + "-" + dr["SCMNom_Mun"].ToString(),

                            };

                            list.Add(mun);
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

        public List<EntityLayer.cat_mun> Select(string connectionStr, string SCMCve_Edo)
        {

            List<EntityLayer.cat_mun> list = new List<EntityLayer.cat_mun>();

            try
            {
                using (var con = new SqlConnection(connectionStr))
                {
                    var query = new SqlCommand();
                    query.Connection = con;
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.CommandText = "uspSelectMunicipio";

                    query.Parameters.Add(new SqlParameter("@pSCMCve_Edo", SCMCve_Edo));

                    con.Open();

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // estado
                            EntityLayer.cat_mun municipio = new EntityLayer.cat_mun()
                            {
                                SCMCve_Edo = dr["SCMCve_Edo"] is DBNull ? "" : dr["SCMCve_Edo"].ToString(),
                                SCMCve_Mun = dr["SCMCve_Mun"] is DBNull ? "" : dr["SCMCve_Mun"].ToString(),
                                SCMNom_Mun = dr["SCMNom_Mun"] is DBNull ? "" : dr["SCMCve_Mun"].ToString() + "-" + dr["SCMNom_Mun"].ToString(),

                            };

                            list.Add(municipio);
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

       
    }
}
