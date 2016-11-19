using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace GestionAGA_WF.DataAccessLayer
{
    public class usuarioDAL
    {
        // propiedades
        public string connectionStr { get; set; }

        public usuarioDAL()
        {
            // TODO: Complete member initialization
        }


        public bool Agregar(EntityLayer.Usuario user)
        {
            bool todok = true;
            try
            {
                using (var con = new SqlConnection(connectionStr))
                {
                    var query = new SqlCommand();
                    query.Connection = con;
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.CommandText = "uspInsertUsuario";
                    
                    query.Parameters.Add(new SqlParameter("@pClv_Usuario", user.clv_Usuario));
	                query.Parameters.Add(new SqlParameter("@pUsuario" , user.clv_Usuario));
	                query.Parameters.Add(new SqlParameter("@pPassword" , user.clv_Usuario));
	                query.Parameters.Add(new SqlParameter("@pNombre" , user.clv_Usuario));
	                query.Parameters.Add(new SqlParameter("@pClv_Area" , user.clv_Usuario));
	                query.Parameters.Add(new SqlParameter("@pClv_GpoAcc" , user.clv_Usuario));
                    query.Parameters.Add(new SqlParameter("@pestatus", user.clv_Usuario));

                    con.Open();
                    todok = Convert.ToBoolean(query.ExecuteNonQuery());

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return todok;
        }

        public  List<EntityLayer.Usuario> SelectUsuarioPwd(string usuario, string pwd)
        {
            List<EntityLayer.Usuario> cat_edoList = new List<EntityLayer.Usuario>();

            try
            {
                using (var con = new SqlConnection(connectionStr))
                {
                    var query = new SqlCommand();
                    query.Connection = con;
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.CommandText = "uspSelectUsuarioPwd";
                    query.Parameters.Add(new SqlParameter("@pUsuario", usuario));
                    query.Parameters.Add(new SqlParameter("@pPassword", pwd));

                    con.Open();

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // 
                            var edoEntity = new EntityLayer.Usuario
                            {
                                clv_Usuario = dr["clv_Usuario"] is DBNull ? 0 : Convert.ToInt32(dr["clv_Usuario"].ToString()),
                                usuario = dr["usuario"] is DBNull ? "" : dr["usuario"].ToString(),
                                password = dr["password"] is DBNull ? "" : dr["password"].ToString(),
                                nombre = dr["nombre"] is DBNull ? "" : dr["nombre"].ToString(),
                                clv_Area = dr["clv_Area"] is DBNull ? 0 : Convert.ToInt32(dr["clv_Area"].ToString()),
                                clv_GpoAcc = dr["clv_GpoAcc"] is DBNull ? 0 : Convert.ToInt32(dr["clv_GpoAcc"].ToString()),
                                estatus = dr["estatus"] is DBNull ? 0 : Convert.ToInt32(dr["estatus"].ToString()),
                                abogado = dr["abogado"] is DBNull ? "" : dr["abogado"].ToString(),
                                opcionesDeMenu = dr["opcionesDeMenu"] is DBNull ? "" : dr["opcionesDeMenu"].ToString(),

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

        public List<EntityLayer.Usuario> Select()
        {
            throw new NotImplementedException();
        }

        public List<EntityLayer.Usuario> SelectCatalogo()
        {
            List<EntityLayer.Usuario> cat_edoList = new List<EntityLayer.Usuario>();

            try
            {
                using (var con = new SqlConnection(this.connectionStr))
                {
                    var query = new SqlCommand();
                    query.Connection = con;
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.CommandText = "spSelectCatalogoUsuario";

                    con.Open();

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // 
                            var edoEntity = new EntityLayer.Usuario
                            {
                                clv_Usuario = dr["clv_Usuario"] is DBNull ? 0 : Convert.ToInt32(dr["clv_Usuario"].ToString()),
                                usuario = dr["usuario"] is DBNull ? "" : dr["usuario"].ToString(),
                                password = dr["password"] is DBNull ? "" : dr["password"].ToString(),
                                nombre = dr["nombre"] is DBNull ? "" : dr["clv_Usuario"].ToString() + "-" + dr["nombre"].ToString(),
                                clv_Area = dr["clv_Area"] is DBNull ? 0 : Convert.ToInt32(dr["clv_Area"].ToString()),
                                clv_GpoAcc = dr["clv_GpoAcc"] is DBNull ? 0 : Convert.ToInt32(dr["clv_GpoAcc"].ToString()),
                                estatus = dr["estatus"] is DBNull ? 0 : Convert.ToInt32(dr["estatus"].ToString())

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


        public List<EntityLayer.Usuario> SelectCatalogo(string connectionStr)
        {
            List<EntityLayer.Usuario> cat_edoList = new List<EntityLayer.Usuario>();

            try
            {
                using (var con = new SqlConnection(connectionStr))
                {
                    var query = new SqlCommand();
                    query.Connection = con;
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.CommandText = "spSelectCatalogoUsuario";

                    con.Open();

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // estado
                            var edoEntity = new EntityLayer.Usuario
                            {
                                clv_Usuario = dr["clv_Usuario"] is DBNull? 0: Convert.ToInt32(dr["clv_Usuario"].ToString()),
                                usuario = dr["usuario"] is DBNull ? "": dr["usuario"].ToString(),
                                password = dr["password"] is DBNull ? "":  dr["password"].ToString(),
                                nombre = dr["nombre"] is DBNull ? "": dr["nombre"].ToString(),
                                clv_Area = dr["clv_Area"] is DBNull ? 0: Convert.ToInt32(dr["clv_Area"].ToString()),
                                clv_GpoAcc = dr["clv_GpoAcc"] is DBNull ? 0: Convert.ToInt32(dr["clv_GpoAcc"].ToString()),
                                estatus = dr["estatus"] is DBNull ? 0 : Convert.ToInt32(dr["estatus"].ToString())

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

        public bool Agregar(string strConexion, EntityLayer.Usuario objeto)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(string strConexion, EntityLayer.Usuario objeto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string strConexion, EntityLayer.Usuario objeto)
        {
            throw new NotImplementedException();
        }





        
    }
}
