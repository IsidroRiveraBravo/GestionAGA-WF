using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace GestionAGA_WF.DataAccessLayer
{
    public class cat_nucDAL: DataAccessLayer.ICRUD<EntityLayer.cat_nuc>
    {

        public string strConexion { get; set; }


        public List<EntityLayer.cat_nuc> Select(string pSCNCve_Edo, string pSCNCve_Mun, string pSCNTipo_Nuc)
        {
            List<EntityLayer.cat_nuc> list = new List<EntityLayer.cat_nuc>();
            try
            {
                using (var con = new SqlConnection(strConexion))
                {
                    var query = new SqlCommand();
                    query.Connection = con;
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.CommandText = "[uspSelectNucleoXEdoXMun]";
                    query.Parameters.Add(new SqlParameter( "@pSCNCve_Edo", pSCNCve_Edo ));
	                query.Parameters.Add(new SqlParameter("@pSCNCve_Mun", pSCNCve_Mun));
                    query.Parameters.Add(new SqlParameter("@pSCNTipo_Nuc", pSCNTipo_Nuc));
                    
                    con.Open();

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // 
                            var nucleo = new EntityLayer.cat_nuc
                            {
                                SCNCve_Unica = dr["SCNCve_Unica"] is DBNull ? "" : dr["SCNCve_Unica"].ToString(),
                                SCNCve_Clasif = dr["SCNCve_Clasif"] is DBNull ? "" : dr["SCNCve_Clasif"].ToString(),
                                SCNCve_Edo = dr["SCNCve_Edo"] is DBNull ? "" : dr["SCNCve_Edo"].ToString(),
                                SCNCve_Mun = dr["SCNCve_Mun"] is DBNull ? "" : dr["SCNCve_Mun"].ToString(),
                                SCNTipo_Nuc = dr["SCNTipo_Nuc"] is DBNull ? "" : dr["SCNTipo_Nuc"].ToString(),
                                SCNNom_Nuc = dr["SCNNom_Nuc"] is DBNull ? "" : dr["SCNCve_Unica"].ToString() + "-" + dr["SCNNom_Nuc"].ToString(),
                                SCNNom_Ant = dr["SCNNom_Ant"] is DBNull ? "" : dr["SCNNom_Ant"].ToString(),
                                SCNFol_Mat = dr["SCNFol_Mat"] is DBNull ? "" : dr["SCNFol_Mat"].ToString(),
                                NCNSup_Parc = dr["NCNSup_Parc"] is DBNull ? 0 : Convert.ToDecimal(dr["NCNSup_Parc"].ToString()),
                                NCNSup_Uso = dr["NCNSup_Uso"] is DBNull ? 0 : Convert.ToDecimal(dr["NCNSup_Uso"].ToString()),
                                NCNSup_Asent = dr["NCNSup_Asent"] is DBNull ? 0 : Convert.ToDecimal(dr["NCNSup_Asent"].ToString()),
                                NCNSup_AsenSt = dr["NCNSup_AsenSt"] is DBNull ? 0 : Convert.ToDecimal(dr["NCNSup_AsenSt"].ToString()),
                                NCNSup_Plano = dr["NCNSup_Plano"] is DBNull ? 0 : Convert.ToDecimal(dr["NCNSup_Plano"].ToString()),
                                NCNSup_Achu = dr["NCNSup_Achu"] is DBNull ? 0 : Convert.ToDecimal(dr["NCNSup_Achu"].ToString()),
                                NCNSup_Reser = dr["NCNSup_Reser"] is DBNull ? 0 : Convert.ToDecimal(dr["NCNSup_Reser"].ToString()),
                                NCNSup_Explo = dr["NCNSup_Explo"] is DBNull ? 0 : Convert.ToDecimal(dr["NCNSup_Explo"].ToString()),
                                NCNSup_Otros = dr["NCNSup_Otros"] is DBNull ? 0 : Convert.ToDecimal(dr["NCNSup_Otros"].ToString()),
                                NCNNum_BenEji = dr["NCNNum_BenEji"] is DBNull ? 0 : Convert.ToInt32(dr["NCNNum_BenEji"].ToString()),
                                NCNNum_BenPos = dr["NCNNum_BenPos"] is DBNull ? 0 : Convert.ToInt32(dr["NCNNum_BenPos"].ToString()),
                                NCNNum_BenAve = dr["NCNNum_BenAve"] is DBNull ? 0 : Convert.ToInt32(dr["NCNNum_BenAve"].ToString()),
                                DCNFec_Alta = dr["DCNFec_Alta"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(dr["DCNFec_Alta"].ToString()),
                                DCNFec_Baja = dr["DCNFec_Baja"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(dr["DCNFec_Baja"].ToString()),
                                ObservacionesNucleo = dr["ObservacionesNucleo"] is DBNull ? "" : dr["ObservacionesNucleo"].ToString(),
                                cancela = dr["cancela"] is DBNull ? "" : dr["cancela"].ToString(),
                                NCNNum_Acciones = dr["NCNNum_Acciones"] is DBNull ? 0 : Convert.ToInt32(dr["NCNNum_Acciones"].ToString()),
                                Tot_Nuc = dr["Tot_Nuc"] is DBNull ? 0 : Convert.ToDecimal(dr["Tot_Nuc"].ToString()),
                                Plano_Gral = dr["Plano_Gral"] is DBNull ? 0 : Convert.ToDecimal(dr["Plano_Gral"].ToString()),
                                Sup_Delimitada = dr["Sup_Delimitada"] is DBNull ? 0 : Convert.ToDecimal(dr["Sup_Delimitada"].ToString()),
                                NCNSup_Ach = dr["NCNSup_Ach"] is DBNull ? 0 : Convert.ToDecimal(dr["NCNSup_Ach"].ToString()),
                                NCNBeneficiados = dr["NCNBeneficiados"] is DBNull ? 0 : Convert.ToDecimal(dr["NCNBeneficiados"].ToString()),
                                Tipo_mov = dr["Tipo_mov"] is DBNull ? "" : dr["Tipo_mov"].ToString(),
                                Usuario_mov = dr["Usuario_mov"] is DBNull ? "" : dr["Usuario_mov"].ToString(),
                                Fecha_mov = dr["Fecha_mov"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(dr["Fecha_mov"].ToString()),
                                NucleoAccion = dr["NucleoAccion"] is DBNull ? 0 : Convert.ToDecimal(dr["NucleoAccion"].ToString()),
                                NCNSup_NoReg = dr["NCNSup_NoReg"] is DBNull ? 0 : Convert.ToDecimal(dr["NCNSup_NoReg"].ToString()),
                                NAASup_Acc = dr["NAASup_Acc"] is DBNull ? 0 : Convert.ToDecimal(dr["NAASup_Acc"].ToString()),
                                SCNCve_Mun_inegi = dr["SCNCve_Mun_inegi"] is DBNull ? "" : dr["SCNCve_Mun_inegi"].ToString(),
                                SCNCve_Nuc_inegi = dr["SCNCve_Nuc_inegi"] is DBNull ? "" : dr["SCNCve_Nuc_inegi"].ToString(),
                                SCNCve_FolTierras = dr["SCNCve_FolTierras"] is DBNull ? "" : dr["SCNCve_FolTierras"].ToString(),

                            };

                            list.Add(nucleo);
                        }

                    }


                }

            }
           catch (Exception ex)
            {
                
                throw  ex;
            }

            return list;
        }


        public List<EntityLayer.cat_nuc> Select()
        {
                throw new NotImplementedException();
        }

        public bool Insert(EntityLayer.cat_nuc objeto)
        {
            throw new NotImplementedException();
        }

        public bool UpDate(EntityLayer.cat_nuc objeto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(EntityLayer.cat_nuc objeto)
        {
            throw new NotImplementedException();
        }
    }
}
