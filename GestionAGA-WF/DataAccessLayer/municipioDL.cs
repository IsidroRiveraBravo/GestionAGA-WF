using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EntityLayer;

namespace GestionAGA_WF.DataAccessLayer
{
    public class municipioDL
    {
        private string ConnectionStr { get; set; }


        public List<EntityLayer.municipio> SelectAll(string connectionStr)
        {

            List<EntityLayer.municipio> cat_edoList = new List<EntityLayer.municipio>();

            try
            {
                using (var con = new SqlConnection(connectionStr))
                {
                    var query = new SqlCommand();
                    query.Connection = con;
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.CommandText = "uspSelectCat_Edo";

                    con.Open();

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // estado
                            var edoEntity = new EntityLayer.municipio
                            {
                                SCECve_Edo = dr["SCECve_Edo"].ToString(),
                                SCENom_Edo = dr["SCECve_Edo"].ToString() + "-" + dr["SCENom_Edo"].ToString(),
                                //Activo = dr["Activo"] is DBNull ? false : Convert.ToBoolean(dr["Activo"].ToString()),
                                //FechaReg = dr["FechaReg"] is DBNull ? DateTime.MinValue: Convert.ToDateTime(dr["FechaReg"].ToString())

                            };

                            cat_edoList.Add(edoEntity);
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

        //internal bool Eliminar(string connectionStr, EntityLayer.municipio municip)
        //{
        //    bool todoOk = true;
        //    try
        //    {
        //        using (var con = new SqlConnection(connectionStr))
        //        {
        //            var query = new SqlCommand();
        //            query.Connection = con;
        //            query.CommandType = System.Data.CommandType.StoredProcedure;
        //            query.CommandText = "uspDeleteCat_Edo";
        //            query.Parameters.Add(new SqlParameter("@pSCECve_Edo", municip.SCMCve_Edo));
        //            //query.Parameters.Add(new SqlParameter("@pSCENom_Edo", edo.SCENom_Edo));
        //            con.Open();
        //            todoOk = Convert.ToBoolean(query.ExecuteNonQuery());

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //    return todoOk;
        //}

        //internal bool Modificar(string connectionStr, EntityLayer.municipio municip)
        //{
        //    bool todoOk = true;
        //    try
        //    {
        //        using (var con = new SqlConnection(connectionStr))
        //        {
        //            var query = new SqlCommand();
        //            query.Connection = con;
        //            query.CommandType = System.Data.CommandType.StoredProcedure;
        //            query.CommandText = "uspUpDateCat_Edo";
        //            query.Parameters.Add(new SqlParameter("@pSCECve_Edo", municip.SCECve_Edo));
        //            query.Parameters.Add(new SqlParameter("@pSCENom_Edo", municip.SCENom_Edo));
        //            con.Open();
        //            todoOk = Convert.ToBoolean(query.ExecuteNonQuery());

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //    return todoOk;
        //}

        //public bool Agregar(string connectionStr, EntityLayer.cat_edo edo)
        //{
        //    bool todoOk = true;
        //    try
        //    {
        //        using (var con = new SqlConnection(connectionStr))
        //        {
        //            var query = new SqlCommand();
        //            query.Connection = con;
        //            query.CommandType = System.Data.CommandType.StoredProcedure;
        //            query.CommandText = "uspInsertCat_Edo";
        //            query.Parameters.Add(new SqlParameter("@pSCECve_Edo", edo.SCECve_Edo));
        //            query.Parameters.Add(new SqlParameter("@pSCENom_Edo", edo.SCENom_Edo));
        //            con.Open();
        //            todoOk = Convert.ToBoolean(query.ExecuteNonQuery());

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //    return todoOk;
        //}

       


        //public List<EntityLayer.cat_edo> SelectCat(string connectionStr)
        //{

        //    List<EntityLayer.cat_edo> cat_edoList = new List<EntityLayer.cat_edo>();

        //    try
        //    {
        //        using (var con = new SqlConnection(connectionStr))
        //        {
        //            var query = new SqlCommand();
        //            query.Connection = con;
        //            query.CommandType = System.Data.CommandType.StoredProcedure;
        //            query.CommandText = "uspSelectCat_Edo";

        //            con.Open();

        //            using (var dr = query.ExecuteReader())
        //            {
        //                while (dr.Read())
        //                {
        //                    // estado
        //                    var edoEntity = new EntityLayer.cat_edo
        //                    {
        //                        SCECve_Edo = dr["SCECve_Edo"].ToString(),
        //                        SCENom_Edo = dr["SCENom_Edo"].ToString(),
        //                        //Activo = dr["Activo"] is DBNull ? false : Convert.ToBoolean(dr["Activo"].ToString()),
        //                        //FechaReg = dr["FechaReg"] is DBNull ? DateTime.MinValue: Convert.ToDateTime(dr["FechaReg"].ToString())

        //                    };

        //                    cat_edoList.Add(edoEntity);
        //                }

        //            }


        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }

        //    return cat_edoList;
        //}

    }
}
