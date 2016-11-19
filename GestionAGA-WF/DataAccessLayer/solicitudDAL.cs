using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace GestionAGA_WF.DataAccessLayer
{
    public static class solicitudDAL
    {
        private static string ConnectionStr { get; set; }

        internal static bool Delete(string connectionStr, string folioCI, int clv_usuarioDelete)
        {
            bool todoOk = true;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionStr))
                {
                    SqlCommand query = new SqlCommand();
                    query.Connection = con;
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.CommandText = "[uspDeleteSolicitud]";

                    query.Parameters.Add(new SqlParameter("@pFolio_CI", folioCI));
                    query.Parameters.Add(new SqlParameter("@pclv_usuarioDelete", clv_usuarioDelete));

                    con.Open();
                    query.ExecuteNonQuery();

                }

            }
            catch (Exception ex)
            {
                todoOk = false;
                throw ex;
            }

            return todoOk;
        }

        public static bool UpDate(string connectionStr, EntityLayer.Solicitud solicitud)
        {
            bool todoOk = true;
            try
            {
                using (var con = new SqlConnection(connectionStr))
                {
                    var query = new SqlCommand();
                    query.Connection = con;
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.CommandText = "uspInsertSolicitud";
                    query.Parameters.Add(new SqlParameter("@pFolio_CI", solicitud.Folio_CI));
                    query.Parameters.Add(new SqlParameter("@pClv_Turnado", solicitud.Clv_Turnado));
                    query.Parameters.Add(new SqlParameter("@pClv_Edo", solicitud.Clv_Edo));
                    query.Parameters.Add(new SqlParameter("@pEstado", solicitud.Estado));
                    query.Parameters.Add(new SqlParameter("@pClv_Mpo", solicitud.Clv_Mpo));
                    query.Parameters.Add(new SqlParameter("@pMunicipio", solicitud.Municipio));
                    query.Parameters.Add(new SqlParameter("@pObsMpo", solicitud.ObsMpo));
                    query.Parameters.Add(new SqlParameter("@pClv_Tipo", solicitud.Clv_Tipo));
                    query.Parameters.Add(new SqlParameter("@pClv_Nuc", solicitud.Clv_Nuc));
                    query.Parameters.Add(new SqlParameter("@pNucleo", solicitud.Nucleo));
                    query.Parameters.Add(new SqlParameter("@pObsNuc", solicitud.ObsNuc));
                    query.Parameters.Add(new SqlParameter("@pClv_GpoDoc1", solicitud.Clv_GpoDoc1));
                    query.Parameters.Add(new SqlParameter("@pClv_GpoDoc2", solicitud.Clv_GpoDoc2));
                    query.Parameters.Add(new SqlParameter("@pClv_TipoProc", solicitud.Clv_TipoProc));
                    query.Parameters.Add(new SqlParameter("@pClv_Proc", solicitud.Clv_Proc));
                    query.Parameters.Add(new SqlParameter("@pClv_Responsable", solicitud.Clv_Responsable));
                    query.Parameters.Add(new SqlParameter("@pFecha_Oficio", solicitud.Fecha_Oficio));
                    query.Parameters.Add(new SqlParameter("@pSolicitado_por", solicitud.Solicitado_por));
                    query.Parameters.Add(new SqlParameter("@pOficio_Solicitud", solicitud.Oficio_Solicitud));
                    query.Parameters.Add(new SqlParameter("@pFecha_Solicitud", solicitud.Fecha_Solicitud));
                    query.Parameters.Add(new SqlParameter("@pDoc_Solicitados", solicitud.Doc_Solicitados));
                    query.Parameters.Add(new SqlParameter("@pObs_Solicitud", solicitud.Obs_Solicitud));
                    query.Parameters.Add(new SqlParameter("@pObs_PreTurnado", solicitud.Obs_PreTurnado));
                    query.Parameters.Add(new SqlParameter("@pObsExt", solicitud.ObsExt));
                    query.Parameters.Add(new SqlParameter("@pOficio_Salida", solicitud.Oficio_Salida));
                    query.Parameters.Add(new SqlParameter("@pOficio_Salida2", solicitud.Oficio_Salida2));
                    query.Parameters.Add(new SqlParameter("@pFecha_OfSalida", solicitud.Fecha_OfSalida));
                    query.Parameters.Add(new SqlParameter("@pFecha_OfSalida2", solicitud.Fecha_OfSalida2));
                    query.Parameters.Add(new SqlParameter("@pClv_Status", solicitud.Clv_Status));
                    query.Parameters.Add(new SqlParameter("@pFechaReg", solicitud.FechaReg));

                    con.Open();

                    todoOk = Convert.ToBoolean(query.ExecuteNonQuery().ToString());


                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return todoOk;
        }


        public static bool Insert(string connectionStr, EntityLayer.Solicitud solicitud)
        { 
            bool todoOk =  true;
            try 
	        {
                using (var con = new SqlConnection(connectionStr))
                {
                    var query = new SqlCommand();
                    query.Connection = con;
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.CommandText = "uspInsertSolicitud";
                    query.Parameters.Add(new SqlParameter("@pFolio_CI", solicitud.Folio_CI ));
                    query.Parameters.Add(new SqlParameter("@pNo_Expediente", solicitud.No_Expediente));
                    query.Parameters.Add(new SqlParameter("@pOficio_Solicitud", solicitud.Oficio_Solicitud));
                    query.Parameters.Add(new SqlParameter("@pFecha_Solicitud", solicitud.Fecha_Solicitud));
                    query.Parameters.Add(new SqlParameter("@pFecha_Venc", solicitud.Fecha_Venc));

                    // cuerpo de registro
                    query.Parameters.Add(new SqlParameter("@pSolicitado_por", solicitud.Solicitado_por));
                    query.Parameters.Add(new SqlParameter("@pFecha_Oficio", solicitud.Fecha_Oficio));
                    query.Parameters.Add(new SqlParameter("@pFolioOfPartes", solicitud.FolioOfPartes));
                    query.Parameters.Add(new SqlParameter("@pFecOfPartes", solicitud.FecOfPartes));
                    query.Parameters.Add(new SqlParameter("@pCGI", solicitud.CGI));
                    query.Parameters.Add(new SqlParameter("@pfechaCGI", solicitud.fechaCGI));
                    query.Parameters.Add(new SqlParameter("@pSIMCR", solicitud.SIMCR));
                    query.Parameters.Add(new SqlParameter("@pfechaSIMCR", solicitud.fechaSIMCR));
                    query.Parameters.Add(new SqlParameter("@pClv_TipoProc", solicitud.Clv_TipoProc));
                    query.Parameters.Add(new SqlParameter("@pClv_Proc", solicitud.Clv_Proc));
                    query.Parameters.Add(new SqlParameter("@pCve_Prioridad", solicitud.Cve_Prioridad));
                    query.Parameters.Add(new SqlParameter("@pClv_Status", solicitud.Clv_Status));

                    //query.Parameters.Add(new SqlParameter("@pClv_Turnado", solicitud.Clv_Turnado));
                    //query.Parameters.Add(new SqlParameter("@pClv_Edo", solicitud.Clv_Edo));
                    //query.Parameters.Add(new SqlParameter("@pEstado", solicitud.Estado));
                    //query.Parameters.Add(new SqlParameter("@pClv_Mpo", solicitud.Clv_Mpo));
                    //query.Parameters.Add(new SqlParameter("@pMunicipio", solicitud.Municipio));
                    //query.Parameters.Add(new SqlParameter("@pObsMpo", solicitud.ObsMpo));
                    //query.Parameters.Add(new SqlParameter("@pClv_Tipo", solicitud.Clv_Tipo));
                    //query.Parameters.Add(new SqlParameter("@pClv_Nuc", solicitud.Clv_Nuc));
                    //query.Parameters.Add(new SqlParameter("@pNucleo", solicitud.Nucleo));
                    //query.Parameters.Add(new SqlParameter("@pObsNuc", solicitud.ObsNuc));
                    //query.Parameters.Add(new SqlParameter("@pClv_GpoDoc1", solicitud.Clv_GpoDoc1));
                    //query.Parameters.Add(new SqlParameter("@pClv_GpoDoc2", solicitud.Clv_GpoDoc2));                 
                    
                    //query.Parameters.Add(new SqlParameter("@pClv_Responsable", solicitud.Clv_Responsable));
                    
                    //query.Parameters.Add(new SqlParameter("@pDoc_Solicitados", solicitud.Doc_Solicitados));
                    //query.Parameters.Add(new SqlParameter("@pObs_Solicitud", solicitud.Obs_Solicitud));
                    //query.Parameters.Add(new SqlParameter("@pObs_PreTurnado", solicitud.Obs_PreTurnado));
                    //query.Parameters.Add(new SqlParameter("@pObsExt", solicitud.ObsExt));
                    //query.Parameters.Add(new SqlParameter("@pOficio_Salida", solicitud.Oficio_Salida));
                    //query.Parameters.Add(new SqlParameter("@pOficio_Salida2", solicitud.Oficio_Salida2));
                    //query.Parameters.Add(new SqlParameter("@pFecha_OfSalida", solicitud.Fecha_OfSalida));
                    //query.Parameters.Add(new SqlParameter("@pFecha_OfSalida2", solicitud.Fecha_OfSalida2));
                    //query.Parameters.Add(new SqlParameter("@pClv_Status", solicitud.Clv_Status));
                    //query.Parameters.Add(new SqlParameter("@pFechaReg", solicitud.FechaReg));

                    con.Open();
                    query.ExecuteNonQuery().ToString();


                }
	        }
	        catch (Exception ex)
	        {
                todoOk = false;
		        throw ex;
	        }


            return todoOk;
        }


        public static List<EntityLayer.Solicitud> SelectFolio_CI(string connectionStr, string Folio_CI)
        {

            List<EntityLayer.Solicitud> cat_edoList = new List<EntityLayer.Solicitud>();

            try
            {
                using (var con = new SqlConnection(connectionStr))
                {
                    var query = new SqlCommand();
                    query.Connection = con;
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.CommandText = "uspSelectSolicitudFolio_CI";
                    query.Parameters.Add(new SqlParameter("@pFolio_CI", Folio_CI));

                    con.Open();

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // usuario
                            var edoEntity = new EntityLayer.Solicitud()
                            {
                                //SCECve_Edo = dr["SCECve_Edo"].ToString(),
                                //SCENom_Edo = dr["SCECve_Edo"].ToString() + "-" + dr["SCENom_Edo"].ToString()


                                Clv_Solicitud = Convert.ToInt32(dr["Clv_Solicitud"].ToString()),
                                Folio_CI = dr["Folio_CI"] is DBNull ? "" : dr["Folio_CI"].ToString(),
                                //Clv_Turnado = dr["Clv_Turnado"] is DBNull ? "" : dr["Folio_CI"].ToString(),
                                Clv_Edo = dr["Clv_Edo"] is DBNull ? "" : dr["Clv_Edo"].ToString(),
                                Estado = dr["Estado"] is DBNull ? "" : dr["Estado"].ToString(),
                                Clv_Mpo = dr["Clv_Mpo"] is DBNull ? "" : dr["Clv_Mpo"].ToString(),
                                Municipio = dr["Municipio"] is DBNull ? "" : dr["Municipio"].ToString(),
                                ObsMpo = dr["ObsMpo"] is DBNull ? "" : dr["ObsMpo"].ToString(),
                                Clv_Tipo = dr["Clv_Tipo"] is DBNull ? "" : dr["Clv_Tipo"].ToString(),
                                Clv_Nuc = dr["Clv_Nuc"] is DBNull ? "" : dr["Clv_Nuc"].ToString(),
                                Nucleo = dr["Nucleo"] is DBNull ? "" : dr["Nucleo"].ToString(),
                                ObsNuc = dr["ObsNuc"] is DBNull ? "" : dr["ObsNuc"].ToString(),
                                Clv_GpoDoc1 = dr["Clv_GpoDoc1"] is DBNull ? 0 : Convert.ToInt32(dr["Clv_GpoDoc1"].ToString()),
                                Clv_GpoDoc2 = dr["Clv_GpoDoc2"] is DBNull ? 0 : Convert.ToInt32(dr["Clv_GpoDoc2"].ToString()),
                                Clv_TipoProc = dr["Clv_TipoProc"] is DBNull ? 0 : Convert.ToInt32(dr["Clv_TipoProc"].ToString()),
                                Clv_Proc = dr["Clv_Proc"] is DBNull ? 0 : Convert.ToInt32(dr["Clv_Proc"].ToString()),
                                Clv_Responsable = dr["Clv_Responsable"] is DBNull ? 0 : Convert.ToInt32(dr["Clv_Responsable"].ToString()),
                                Fecha_Oficio = dr["Fecha_Oficio"] is DBNull ? "" : dr["Fecha_Oficio"].ToString(),
                                Solicitado_por = dr["Solicitado_por"] is DBNull ? "" : dr["Solicitado_por"].ToString(),
                                Oficio_Solicitud = dr["Oficio_Solicitud"] is DBNull ? "" : dr["Oficio_Solicitud"].ToString(),
                                Fecha_Solicitud = dr["Fecha_Solicitud"] is DBNull ? "" : dr["Fecha_Solicitud"].ToString(),
                                Doc_Solicitados = dr["Doc_Solicitados"] is DBNull ? "" : dr["Doc_Solicitados"].ToString(),
                                Obs_Solicitud = dr["Obs_Solicitud"] is DBNull ? "" : dr["Obs_Solicitud"].ToString(),
                                Obs_PreTurnado = dr["Obs_PreTurnado"] is DBNull ? "" : dr["Obs_PreTurnado"].ToString(),
                                ObsExt = dr["ObsExt"] is DBNull ? "" : dr["ObsExt"].ToString(),
                                Oficio_Salida = dr["Oficio_Salida"] is DBNull ? "" : dr["Oficio_Salida"].ToString(),
                                Oficio_Salida2 = dr["Oficio_Salida2"] is DBNull ? "" : dr["Oficio_Salida2"].ToString(),
                                Fecha_OfSalida = dr["Fecha_OfSalida"] is DBNull ? "" : dr["Fecha_OfSalida"].ToString(),
                                Fecha_OfSalida2 = dr["Fecha_OfSalida2"] is DBNull ? "" : dr["Fecha_OfSalida2"].ToString(),
                                Clv_Status = dr["Clv_Status"] is DBNull ? "" : dr["Clv_Status"].ToString(),
                                FechaReg = dr["FechaReg"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(dr["Clv_Status"].ToString())

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



        public static List<EntityLayer.Solicitud> Select(string connectionStr)
        {

            List<EntityLayer.Solicitud> cat_edoList = new List<EntityLayer.Solicitud>();

            try
            {
                using (var con = new SqlConnection(connectionStr))
                {
                    var query = new SqlCommand();
                    query.Connection = con;
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.CommandText = "uspSelectSolicitud";

                    con.Open();

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // usuario
                            var edoEntity = new EntityLayer.Solicitud()
                            {
                                //SCECve_Edo = dr["SCECve_Edo"].ToString(),
                                //SCENom_Edo = dr["SCECve_Edo"].ToString() + "-" + dr["SCENom_Edo"].ToString()


                                Clv_Solicitud = Convert.ToInt32(dr["Clv_Solicitud"].ToString()),
                                Folio_CI = dr["Folio_CI"] is DBNull ? "" : dr["Folio_CI"].ToString(),
                                No_Expediente = dr["No_Expediente"] is DBNull ? "" : dr["No_Expediente"].ToString(),
                                //Clv_Turnado = dr["Clv_Turnado"] is DBNull ? 0: Convert.ToInt32(dr["Clv_Turnado"].ToString()),
                                //NombreTurnado = dr["NombreTurnado"] is DBNull ? "" : dr["NombreTurnado"].ToString(),
                                Fecha_Solicitud = dr["Fecha_Solicitud"] is DBNull ? "" : dr["Fecha_Solicitud"].ToString(),
                                Fecha_Venc = dr["Fecha_Venc"] is DBNull ? "" : dr["Fecha_Venc"].ToString(),
                                Clv_Edo = dr["Clv_Edo"] is DBNull ? "": dr["Clv_Edo"].ToString(),
                                Estado = dr["Estado"] is DBNull ? "" : dr["Estado"].ToString(),
                                Clv_Mpo = dr["Clv_Mpo"] is DBNull ? "" : dr["Clv_Mpo"].ToString(),
                                Municipio = dr["Municipio"] is DBNull ? "" : dr["Municipio"].ToString(),
                                ObsMpo = dr["ObsMpo"] is DBNull ? "" : dr["ObsMpo"].ToString(),
                                Clv_Tipo = dr["Clv_Tipo"] is DBNull ? "" : dr["Clv_Tipo"].ToString(),
                                Clv_Nuc = dr["Clv_Nuc"] is DBNull ? "" : dr["Clv_Nuc"].ToString(),
                                Nucleo = dr["Nucleo"] is DBNull ? "" : dr["Nucleo"].ToString(),
                                ObsNuc = dr["ObsNuc"] is DBNull ? "" : dr["ObsNuc"].ToString(),
                                Clv_GpoDoc1 = dr["Clv_GpoDoc1"] is DBNull ? 0 : Convert.ToInt32(dr["Clv_GpoDoc1"].ToString()),
                                Clv_GpoDoc2 = dr["Clv_GpoDoc2"] is DBNull ? 0 : Convert.ToInt32(dr["Clv_GpoDoc2"].ToString()),
                                Clv_TipoProc = dr["Clv_TipoProc"] is DBNull ? 0 : Convert.ToInt32(dr["Clv_TipoProc"].ToString()),
                                Clv_Proc = dr["Clv_Proc"] is DBNull ? 0 : Convert.ToInt32(dr["Clv_Proc"].ToString()),
                                Clv_Responsable = dr["Clv_Responsable"] is DBNull ? 0 : Convert.ToInt32(dr["Clv_Responsable"].ToString()),
                                Fecha_Oficio = dr["Fecha_Oficio"] is DBNull ? "" : dr["Fecha_Oficio"].ToString(),
                                Solicitado_por = dr["Solicitado_por"] is DBNull ? "" : dr["Solicitado_por"].ToString(),
                                Oficio_Solicitud = dr["Oficio_Solicitud"] is DBNull ? "" : dr["Oficio_Solicitud"].ToString(),
                                
                                Doc_Solicitados = dr["Doc_Solicitados"] is DBNull ? "" : dr["Doc_Solicitados"].ToString(),
                                Obs_Solicitud = dr["Obs_Solicitud"] is DBNull ? "" : dr["Obs_Solicitud"].ToString(),
                                Obs_PreTurnado = dr["Obs_PreTurnado"] is DBNull ? "" : dr["Obs_PreTurnado"].ToString(),
                                ObsExt = dr["ObsExt"] is DBNull ? "" : dr["ObsExt"].ToString(),
                                Oficio_Salida = dr["Oficio_Salida"] is DBNull ? "" : dr["Oficio_Salida"].ToString(),
                                Oficio_Salida2 = dr["Oficio_Salida2"] is DBNull ? "" : dr["Oficio_Salida2"].ToString(),
                                Fecha_OfSalida = dr["Fecha_OfSalida"] is DBNull ? "" : dr["Fecha_OfSalida"].ToString(),
                                Fecha_OfSalida2 = dr["Fecha_OfSalida2"] is DBNull ? "" : dr["Fecha_OfSalida2"].ToString(),
                                Clv_Status = dr["Clv_Status"] is DBNull ? "" : dr["Clv_Status"].ToString(),
                                FechaReg = dr["FechaReg"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(dr["Clv_Status"].ToString()),
                                FecOfPartes = dr["FecOfPartes"] is DBNull ? "" : dr["FecOfPartes"].ToString(),
                                FolioOfPartes = dr["FolioOfPartes"] is DBNull ? "" : dr["FolioOfPartes"].ToString(),
                                Cve_Prioridad = dr["Cve_Prioridad"] is DBNull ? "" : dr["Cve_Prioridad"].ToString(),
                                LugarAtencion = dr["LugarAtencion"] is DBNull ? "" : dr["LugarAtencion"].ToString(),
                                CGI = dr["CGI"] is DBNull ? "" : dr["CGI"].ToString(),
                                fechaCGI = dr["fechaCGI"] is DBNull ? "" : dr["fechaCGI"].ToString(),
                                SIMCR = dr["SIMCR"] is DBNull ? "" : dr["SIMCR"].ToString(),
                                fechaSIMCR = dr["fechaSIMCR"] is DBNull ? "" : dr["fechaSIMCR"].ToString(),
                                fecRecepcion = dr["fecRecepcion"] is DBNull ? "" : dr["fecRecepcion"].ToString(),
                                //fecPago = dr["fecPago"] is DBNull ? "" : dr["fecPago"].ToString(),
                                //totalPago = dr["totalPago"] is DBNull ? "" : dr["totalPago"].ToString(),
                                //obsPago = dr["obsPago"] is DBNull ? "" : dr["obsPago"].ToString(),
                                clv_entidadSolicitante = dr["clv_entidadSolicitante"] is DBNull ? "" : dr["clv_entidadSolicitante"].ToString(),
                                entidadSolicitante = dr["entidadSolicitante"] is DBNull ? "" : dr["entidadSolicitante"].ToString(),
                                Clasificacion = dr["Clasificacion"] is DBNull ? "" : dr["Clasificacion"].ToString(),
                                RecibidoAGANET = dr["RecibidoAGANET"] is DBNull ? 0: Convert.ToInt32(dr["RecibidoAGANET"].ToString()),
                                usr_Captura = dr["usr_Captura"] is DBNull ? 0: Convert.ToInt32(dr["usr_Captura"].ToString()),
                                usr_recepcion = dr["usr_recepcion"] is DBNull ? 0 : Convert.ToInt32(dr["usr_recepcion"].ToString()),
                                status = dr["status"] is DBNull ? "" : dr["status"].ToString(),

                                // Turnado
                                //Clv_ResponsableTurnado = dr["Clv_ResponsableTurnado"] is DBNull ? 0 : Convert.ToInt32(dr["Clv_ResponsableTurnado"].ToString()),
                                //Clv_UsuarioTurnado = dr["Clv_UsuarioTurnado"] is DBNull ? 0 : Convert.ToInt32(dr["Clv_UsuarioTurnado"].ToString()),
                                //Fecha_Preturnado = dr["Fecha_Preturnado"] is DBNull ? "" : dr["Fecha_Preturnado"].ToString(),
                                //Fecha_Turnado = dr["Fecha_Turnado"] is DBNull ? "" : dr["Fecha_Turnado"].ToString(),
                                //Obs_Turnado = dr["Obs_Turnado"] is DBNull ? "" : dr["Obs_Turnado"].ToString(),
                                //Clv_StatusTurnado = dr["Clv_StatusTurnado"] is DBNull ? "" : dr["Clv_StatusTurnado"].ToString(),
                                //statusTurnado = dr["statusTurnado"] is DBNull ? "" : dr["statusTurnado"].ToString(),

                                // Investigacion
                                //Fecha_InicioInves = dr["Fecha_InicioInves"] is DBNull ? "" : dr["Fecha_InicioInves"].ToString(),
                                //Fecha_FinInves = dr["Fecha_FinInves"] is DBNull ? "" : dr["Fecha_FinInves"].ToString(),
                                //fecha_inicio_ProgInves = dr["fecha_inicio_ProgInves"] is DBNull ? "" : dr["fecha_inicio_ProgInves"].ToString(),
                                //fecha_fin_ProgInves = dr["fecha_fin_ProgInves"] is DBNull ? "" : dr["fecha_fin_ProgInves"].ToString(),
                                //clv_usrInvestigador = dr["clv_usrInvestigador"] is DBNull ? 0 : Convert.ToInt32(dr["clv_usrInvestigador"].ToString()),
                                //Clv_StatusInves = dr["Clv_StatusInves"] is DBNull ? "" : dr["Clv_StatusInves"].ToString(),
                                //statusInves = dr["statusInves"] is DBNull ? "" : dr["statusInves"].ToString(),
                                //observacionesInves = dr["observacionesInves"] is DBNull ? "" : dr["observacionesInves"].ToString(),

                                // respuesta
                                //Resp_Fecha_Inv = dr["Resp_Fecha_Inv"] is DBNull ? "" : dr["Resp_Fecha_Inv"].ToString(),
                                //Resp_Fecha_Ini = dr["Resp_Fecha_Ini"] is DBNull ? "" : dr["Resp_Fecha_Ini"].ToString(),
                                //Resp_Fecha_Fin = dr["Resp_Fecha_Fin"] is DBNull ? "" : dr["Resp_Fecha_Fin"].ToString(),
                                //Resp_Fecha_Fin2 = dr["Resp_Fecha_Fin2"] is DBNull ? "" : dr["Resp_Fecha_Fin2"].ToString(),
                                //Resp_No_FojasCarOfi = dr["Resp_No_FojasCarOfi"] is DBNull ? "" : dr["Resp_No_FojasCarOfi"].ToString(),
                                //Resp_CostoFojCarOfi = dr["Resp_CostoFojCarOfi"] is DBNull ? "" : dr["Resp_CostoFojCarOfi"].ToString(),
                                //Resp_No_FojasNoCarOfi = dr["Resp_No_FojasNoCarOfi"] is DBNull ? "" : dr["Resp_No_FojasNoCarOfi"].ToString(),
                                //Resp_CostoFojNoCarOfi = dr["Resp_CostoFojNoCarOfi"] is DBNull ? "" : dr["Resp_CostoFojNoCarOfi"].ToString(),
                                //Resp_No_Planos = dr["Resp_No_Planos"] is DBNull ? "" : dr["Resp_No_Planos"].ToString(),
                                //Resp_CostoPlanos = dr["Resp_CostoPlanos"] is DBNull ? "" : dr["Resp_CostoPlanos"].ToString(),
                                //Resp_No_HojaPlano = dr["Resp_No_HojaPlano"] is DBNull ? "" : dr["Resp_No_HojaPlano"].ToString(),
                                //Resp_CostoHojaPlano = dr["Resp_CostoHojaPlano"] is DBNull ? "" : dr["Resp_CostoHojaPlano"].ToString(),
                                //Resp_Compulsa = dr["Resp_Compulsa"] is DBNull ? "" : dr["Resp_Compulsa"].ToString(),
                                //Resp_CostoCompulsa = dr["Resp_CostoCompulsa"] is DBNull ? "" : dr["Resp_CostoCompulsa"].ToString(),
                                //Resp_CostoTotal = dr["Resp_CostoTotal"] is DBNull ? "" : dr["Resp_CostoTotal"].ToString(),
                                //Resp_Num_Doc = dr["Resp_Num_Doc"] is DBNull ? "" : dr["Resp_Num_Doc"].ToString(),
                                //Resp_Doc_Entregados = dr["Resp_Doc_Entregados"] is DBNull ? "" : dr["Resp_Doc_Entregados"].ToString(),
                                //Resp_Doc_Entregados2 = dr["Resp_Doc_Entregados2"] is DBNull ? "" : dr["Resp_Doc_Entregados2"].ToString(),
                                //Resp_Obs_Respuesta = dr["Resp_Obs_Respuesta"] is DBNull ? "" : dr["Resp_Obs_Respuesta"].ToString(),
                                //Resp_Obs_Respuesta2 = dr["Resp_Obs_Respuesta2"] is DBNull ? "" : dr["Resp_Obs_Respuesta2"].ToString(),
                                //Resp_Clv_Status = dr["Resp_Clv_Status"] is DBNull ? "" : dr["Resp_Clv_Status"].ToString(),
                                //Resp_Notificacion = dr["Resp_Notificacion"] is DBNull ? "" : dr["Resp_Notificacion"].ToString(),
                                //Resp_FecEnvio = dr["Resp_FecEnvio"] is DBNull ? "" : dr["Resp_FecEnvio"].ToString(),


                                //  Revisión
                                  //Rev_Clv_Solicitud 
                                //Rev_Fecha_Rec = dr["Rev_Fecha_Rec"] is DBNull ? "" : dr["Rev_Fecha_Rec"].ToString(),
                                //Rev_Fecha_Revision = dr["Rev_Fecha_Revision"] is DBNull ? "" : dr["Rev_Fecha_Revision"].ToString(),
                                //Rev_Obs_Revision = dr["Rev_Obs_Revision"] is DBNull ? "" : dr["Rev_Obs_Revision"].ToString(),
                                //Rev_Clv_Status = dr["Rev_Clv_Status"] is DBNull ? "" : dr["Rev_Clv_Status"].ToString(),
                                //Rev_clv_usr = dr["Rev_clv_usr"] is DBNull ? 0 : Convert.ToInt32(dr["Rev_clv_usr"].ToString()),
                                //  //Rev_status { get; set; }


                                ////Firma
                                //sf_Fecha_Rec = dr["sf_Fecha_Rec"] is DBNull ? "" : dr["sf_Fecha_Rec"].ToString(),
                                //sf_Fecha_Firma = dr["sf_Fecha_Firma"] is DBNull ? "" : dr["sf_Fecha_Firma"].ToString(),
                                //sf_Observaciones = dr["sf_Observaciones"] is DBNull ? "" : dr["sf_Observaciones"].ToString(),
                                //sf_Clv_Status = dr["sf_Clv_Status"] is DBNull ? "" : dr["sf_Clv_Status"].ToString(),
                                //sf_clv_firmadoPor = dr["sf_clv_firmadoPor"] is DBNull ? 0 : Convert.ToInt32(dr["sf_clv_firmadoPor"].ToString()),


                                ////Cierre
                                //en_Fecha_Rec = dr["en_Fecha_Rec"] is DBNull ? "" : dr["en_Fecha_Rec"].ToString(),
                                //en_Fecha_Entregado = dr["en_Fecha_Entregado"] is DBNull ? "" : dr["en_Fecha_Entregado"].ToString(),
                                //en_Observaciones = dr["en_Observaciones"] is DBNull ? "" : dr["en_Observaciones"].ToString(),
                                //en_status = dr["en_status"] is DBNull ? "" : dr["en_status"].ToString(),
                                //en_clv_usuario_entrega = dr["en_clv_usuario_entrega"] is DBNull ? "" : dr["en_clv_usuario_entrega"].ToString(),



                                //////////Facturación
                                //////////sof_Oficio_Solicitud = dr["sof_Oficio_Solicitud"] is DBNull ? "" : dr["sof_Oficio_Solicitud"].ToString(),
                                //////////sof_destino = dr["sof_destino"] is DBNull ? "" : dr["sof_destino"].ToString(),
                                //////////sof_Folio_CI = dr["sof_Folio_CI"] is DBNull ? "" : dr["sof_Folio_CI"].ToString(),



                                //sof_elaboro = dr["sof_elaboro"] is DBNull ? "" : dr["sof_elaboro"].ToString(),
                                //sof_fechaFactura = dr["sof_fechaFactura"] is DBNull ? "" : dr["sof_fechaFactura"].ToString(),
                                //sof_fechaEntrega = dr["sof_fechaEntrega"] is DBNull ? "" : dr["sof_fechaEntrega"].ToString(),
                                //sof_fechaOfPartes = dr["sof_fechaOfPartes"] is DBNull ? "" : dr["sof_fechaOfPartes"].ToString(),
                                //sof_SelloYfechaOfPartes = dr["sof_SelloYfechaOfPartes"] is DBNull ? "" : dr["sof_SelloYfechaOfPartes"].ToString(),
                                //sof_Observaciones = dr["sof_Observaciones"] is DBNull ? "" : dr["sof_Observaciones"].ToString(),
                                //////////sof_Status = dr["sof_Status"] is DBNull ? "" : dr["sof_Status"].ToString(),
                                //////////sof_Usr_Factura = dr["sof_Usr_Factura"] is DBNull ? "" : dr["sof_Usr_Factura"].ToString(),
                                

                                ////Pago
                                ////id_SolPago
                                //sp_clv_Solicitud = dr["sp_clv_Solicitud"] is DBNull ? "" : dr["sp_clv_Solicitud"].ToString(),
                                //sp_fecha_Recepcion = dr["sp_fecha_Recepcion"] is DBNull ? "" : dr["sp_fecha_Recepcion"].ToString(),
                                //sp_fecha_Pago = dr["sp_fecha_Pago"] is DBNull ? "" : dr["sp_fecha_Pago"].ToString(),
                                //sp_totalPago = dr["sp_totalPago"] is DBNull ? "" : dr["sp_totalPago"].ToString(),
                                //sp_observacionesPago = dr["sp_observacionesPago"] is DBNull ? "" : dr["sp_observacionesPago"].ToString(),
                                //sp_clv_Usuario = dr["sp_clv_Usuario"] is DBNull ? "" : dr["sp_clv_Usuario"].ToString(),
                                                                                                                          
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


       
    }
}
