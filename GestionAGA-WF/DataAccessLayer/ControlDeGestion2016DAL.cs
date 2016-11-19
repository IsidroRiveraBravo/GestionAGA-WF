using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel;

namespace GestionAGA_WF.DataAccessLayer
{
    public class ControlDeGestion2016DAL
    {
        // propiedades
        public string strConexion { get; set; }

        internal List<EntityLayer.repProdInstitucionales> RepProdInstitucionales()
        {
            List<EntityLayer.repProdInstitucionales> list = new List<EntityLayer.repProdInstitucionales>();

            try
            {
                using (SqlConnection con =  new SqlConnection(strConexion))
                {
                    SqlCommand query = new SqlCommand();
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.Connection = con;
                    query.CommandText = "uspRepProdInstitucionales";

                    con.Open();
                    using (SqlDataReader dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntityLayer.repProdInstitucionales rep = new EntityLayer.repProdInstitucionales() {
                                abogado = dr["ABOGADO"] is DBNull ? "" : dr["ABOGADO"].ToString(),
                                concluido = dr["CONCLUIDO"] is DBNull ? 0 : Convert.ToInt32(dr["CONCLUIDO"].ToString()),
                                en_tramite = dr["EN_TRAMITE"] is DBNull ? 0 : Convert.ToInt32(dr["EN_TRAMITE"].ToString()),
                                total = dr["TOTAL"] is DBNull ? 0 : Convert.ToInt32(dr["TOTAL"].ToString())
                            };

                            list.Add(rep);
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

        internal List<EntityLayer.repProdParticulares> RepProdParticulares()
        {
            List<EntityLayer.repProdParticulares> list = new List<EntityLayer.repProdParticulares>();

            try
            {
                using (SqlConnection con = new SqlConnection(strConexion))
                {
                    SqlCommand query = new SqlCommand();
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.Connection = con;
                    query.CommandText = "uspRepProdParticulares";

                    con.Open();
                    using (SqlDataReader dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntityLayer.repProdParticulares rep = new EntityLayer.repProdParticulares()
                            {
                                abogado = dr["abogado"] is DBNull ? "" : dr["abogado"].ToString(),
                                concluido = dr["concluido"] is DBNull ? 0 : Convert.ToInt32(dr["concluido"].ToString()),
                                en_tramite = dr["en_tramite"] is DBNull ? 0 : Convert.ToInt32(dr["en_tramite"].ToString()),
                                total = dr["total"] is DBNull ? 0 : Convert.ToInt32(dr["total"].ToString())
                            };

                            list.Add(rep);
                        }

                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

            return list;
        }


        public bool UpDate(EntityLayer.ControlDeGestion2016 ctrlE)
        {
            bool todoOK = true;

            try
            {
                using (var conexion = new System.Data.SqlClient.SqlConnection(strConexion))
                {
                    SqlCommand query = new SqlCommand();
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.Connection = conexion;
                    query.CommandText = "uspUpDateControlDeGestion2016";

                    query.Parameters.Add(new SqlParameter("@pIdControlGestion", ctrlE.IdControlGestion)); // ] [int] NOT NULL,
                    query.Parameters.Add(new SqlParameter("@pCI", ctrlE.CI));
                    query.Parameters.Add(new SqlParameter("@pSIMCR", ctrlE.SIMCR));
                    query.Parameters.Add(new SqlParameter("@pCI_Institucional", ctrlE.CI_Institucional));
                    query.Parameters.Add(new SqlParameter("@pCI_AGA", ctrlE.CI_AGA));
                    //public string AreaQueRemite { get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
                    query.Parameters.Add(new SqlParameter("@pNumeroDeOficio", ctrlE.NumeroDeOficio));
                    query.Parameters.Add(new SqlParameter("@pFechaDeOficio", ctrlE.FechaDeOficio));
                    query.Parameters.Add(new SqlParameter("@pFechaRecepcionAR", ctrlE.FechaRecepcionAR));
                    query.Parameters.Add(new SqlParameter("@pFechaRecepcionAGA", ctrlE.FechaRecepcionAGA));
                    query.Parameters.Add(new SqlParameter("@pPoblado", ctrlE.Poblado));
                    query.Parameters.Add(new SqlParameter("@pMunicipio", ctrlE.Municipio));
                    query.Parameters.Add(new SqlParameter("@pEstado", ctrlE.Estado));
                    query.Parameters.Add(new SqlParameter("@pAsunto", ctrlE.Asunto));
                    query.Parameters.Add(new SqlParameter("@pTurnadoA", ctrlE.TurnadoA));
                    query.Parameters.Add(new SqlParameter("@pFirma", ctrlE.Firma));
                    query.Parameters.Add(new SqlParameter("@pTermino", ctrlE.Termino));
                    query.Parameters.Add(new SqlParameter("@pOficioRespuesta", ctrlE.OficioRespuesta));
                    query.Parameters.Add(new SqlParameter("@pFechaRespuesta", ctrlE.FechaRespuesta));
                    query.Parameters.Add(new SqlParameter("@pObservacionesRespuesta", ctrlE.ObservacionesRespuesta));
                    //public string ClasificacionArchivistica { get; set; } // ] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
                    query.Parameters.Add(new SqlParameter("@pSolicitadoPor", ctrlE.SolicitadoPor));
                    query.Parameters.Add(new SqlParameter("@pCosto", ctrlE.Costo));
                    query.Parameters.Add(new SqlParameter("@pFojas", ctrlE.Fojas));
                    query.Parameters.Add(new SqlParameter("@pPlanos", ctrlE.Planos));


                    conexion.Open();
                    query.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return todoOK;

        }


        public bool Insert(EntityLayer.ControlDeGestion2016 ctrlE)
        {
            bool todoOK = true;

            try
            {
                using (var conexion = new System.Data.SqlClient.SqlConnection(strConexion))
                {
                    SqlCommand query = new SqlCommand();
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.Connection = conexion;
                    query.CommandText = "uspInsertControlDeGestion2016";

                     //query.Parameters.Add( new SqlParameter("IdControlGestion", ctrlE.IdControlGestion)); // ] [int] NOT NULL,
	                query.Parameters.Add( new SqlParameter("@pCI", ctrlE.CI));
                    query.Parameters.Add(new SqlParameter("@pSIMCR", ctrlE.SIMCR));
                    query.Parameters.Add(new SqlParameter("@pCI_Institucional", ctrlE.CI_Institucional));
                    query.Parameters.Add(new SqlParameter("@pCI_AGA", ctrlE.CI_AGA));
                    //public string AreaQueRemite { get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
                    query.Parameters.Add(new SqlParameter("@pNumeroDeOficio", ctrlE.NumeroDeOficio));
                    query.Parameters.Add(new SqlParameter("@pFechaDeOficio", ctrlE.FechaDeOficio));
                    query.Parameters.Add(new SqlParameter("@pFechaRecepcionAR", ctrlE.FechaRecepcionAR));
                    query.Parameters.Add(new SqlParameter("@pFechaRecepcionAGA", ctrlE.FechaRecepcionAGA));
                    query.Parameters.Add(new SqlParameter("@pPoblado", ctrlE.Poblado));
                    query.Parameters.Add(new SqlParameter("@pMunicipio", ctrlE.Municipio));
                    query.Parameters.Add(new SqlParameter("@pEstado", ctrlE.Estado));
                    query.Parameters.Add(new SqlParameter("@pAsunto", ctrlE.Asunto));
                    query.Parameters.Add(new SqlParameter("@pTurnadoA", ctrlE.TurnadoA));
                    query.Parameters.Add(new SqlParameter("@pFirma", ctrlE.Firma));
                    query.Parameters.Add(new SqlParameter("@pTermino", ctrlE.Termino));
                    query.Parameters.Add(new SqlParameter("@pOficioRespuesta", ctrlE.OficioRespuesta));
                    query.Parameters.Add(new SqlParameter("@pFechaRespuesta", ctrlE.FechaRespuesta));
                    query.Parameters.Add(new SqlParameter("@pObservacionesRespuesta", ctrlE.ObservacionesRespuesta));
                    //public string ClasificacionArchivistica { get; set; } // ] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
                    query.Parameters.Add(new SqlParameter("@pSolicitadoPor", ctrlE.SolicitadoPor));
                    query.Parameters.Add(new SqlParameter("@pCosto", ctrlE.Costo));
                    query.Parameters.Add(new SqlParameter("@pFojas", ctrlE.Fojas));
                    query.Parameters.Add(new SqlParameter("@pPlanos", ctrlE.Planos));


                    conexion.Open();
                    query.ExecuteNonQuery();

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return todoOK;
        }

        public List<EntityLayer.ControlDeGestion2016> Select()
        {
            List<EntityLayer.ControlDeGestion2016> listControl = new List<EntityLayer.ControlDeGestion2016>();

            try
            {
                using (var conexion = new System.Data.SqlClient.SqlConnection(strConexion))
                {
                    SqlCommand query = new SqlCommand();
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.Connection = conexion;
                    query.CommandText = "uspSelectControlDeGestion2016";

                    conexion.Open();

                    using (SqlDataReader dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EntityLayer.ControlDeGestion2016 ctrlE = new EntityLayer.ControlDeGestion2016()
                            {
                                IdControlGestion = dr["IdControlGestion"] is DBNull ? 0 : Convert.ToInt32(dr["IdControlGestion"].ToString()), // {get; set; } // ] [int] NOT NULL,
                                CI = dr["CI"] is DBNull ? "" : dr["CI"].ToString(), // {get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NOT NULL,
                                SIMCR = dr["SIMCR"] is DBNull ? "" : dr["SIMCR"].ToString(), //{get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
                                CI_Institucional = dr["CI_Institucional"] is DBNull ? "" : dr["CI_Institucional"].ToString(), //{get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
                                CI_AGA = dr["CI_AGA"] is DBNull ? "" : dr["CI_AGA"].ToString(), //{get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
                                NumeroDeOficio = dr["NumeroDeOficio"] is DBNull ? "" : dr["NumeroDeOficio"].ToString(), //{get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
                                FechaDeOficio = dr["FechaDeOficio"] is DBNull ? "" : dr["FechaDeOficio"].ToString(), //{get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
                                FechaRecepcionAR = dr["FechaRecepcionAR"] is DBNull ? "" : dr["FechaRecepcionAR"].ToString(), //{get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
                                FechaRecepcionAGA = dr["FechaRecepcionAGA"] is DBNull ? "" : dr["FechaRecepcionAGA"].ToString(), //{get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
                                Poblado = dr["Poblado"] is DBNull ? "" : dr["Poblado"].ToString(), //{get; set; } // ] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
                                Municipio = dr["Municipio"] is DBNull ? "" : dr["Municipio"].ToString(), //{get; set; } // ] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
                                Estado = dr["Estado"] is DBNull ? "" : dr["Estado"].ToString(), // {get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
                                Asunto = dr["Asunto"] is DBNull ? "" : dr["Asunto"].ToString(), //{get; set; } // ] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
                                TurnadoA = dr["TurnadoA"] is DBNull ? "" : dr["TurnadoA"].ToString(), //{get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
                                Firma = dr["Firma"] is DBNull ? "" : dr["Firma"].ToString(), //{get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
                                Termino = dr["Termino"] is DBNull ? "" : dr["Termino"].ToString(), //{get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
                                OficioRespuesta = dr["OficioRespuesta"] is DBNull ? "" : dr["OficioRespuesta"].ToString(), //{get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
                                FechaRespuesta = dr["FechaRespuesta"] is DBNull ? "" : dr["FechaRespuesta"].ToString(), //{get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
                                ObservacionesRespuesta = dr["ObservacionesRespuesta"] is DBNull ? "" : dr["ObservacionesRespuesta"].ToString(), //{get; set; } // ] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
                                SolicitadoPor = dr["SolicitadoPor"] is DBNull ? "" : dr["SolicitadoPor"].ToString(), //{get; set; } // ] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
                                Costo = dr["Costo"] is DBNull ? "" : dr["Costo"].ToString(), //{get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
                                Fojas = dr["Fojas"] is DBNull ? "" : dr["Fojas"].ToString(), //{get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
                                Planos = dr["Planos"] is DBNull ? "" : dr["Planos"].ToString() //{ get; set; } // ] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AI NULL,
                            };

                            listControl.Add(ctrlE);
                        }
                    }

                }
            }
            catch (Exception ex )
            {
                
                throw ex;
            }
            return listControl;
        }

       
    }
}
