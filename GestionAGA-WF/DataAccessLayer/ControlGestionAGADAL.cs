using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//agregar
using System.Data.SqlClient;
using GestionAGA_WF.EntityLayer;


namespace GestionAGA_WF.DataAccessLayer
{
    public class ControlGestionAGADAL
    {
        //propiedades
        public string strConexion { get; set; }
        /// <sumary></sumary>
        /// <returns></returns>

        public List<ControlGestionAGA> Select()
        {
            List<ControlGestionAGA> ListaControlGestionAGA = new List<ControlGestionAGA>();
            try
            {
                using (SqlConnection con = new SqlConnection(strConexion))
                {
                    SqlCommand query = new SqlCommand();
                    query.Connection = con;
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.CommandText = "uspSelect";

                    // TODO


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaControlGestionAGA;

        }
        public bool Insert(EntityLayer.ControlGestionAGA objControlGestionAGA)
        {
            bool todoOK = true;
            try
            {
                using (SqlConnection con = new SqlConnection(strConexion))
                {
                    SqlCommand query = new SqlCommand();
                    query.Connection = con;
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    //query.CommandText = "uspInsertControlDeGestionAGA";
                    query.CommandText = "uspInsertControlDeGestion2016";

                        //query.Parameters.Add( new SqlParameter("@pIdControlGestion", objControlGestionAGA.IdControlGestion));
                        query.Parameters.Add( new SqlParameter("@pCI", objControlGestionAGA.CI));
                        query.Parameters.Add( new SqlParameter("@pSIMCR", objControlGestionAGA.SIMCR));
                        query.Parameters.Add( new SqlParameter("@pCI_Institucional", objControlGestionAGA.CI_Institucional));
                        query.Parameters.Add( new SqlParameter("@pCI_AGA", objControlGestionAGA.CI_AGA));
                        query.Parameters.Add( new SqlParameter("@pAreaQueRemite", objControlGestionAGA.AreaQueRemite));
                        query.Parameters.Add( new SqlParameter("@pNumeroDeOficio", objControlGestionAGA.NumeroDeOficio));
                        query.Parameters.Add( new SqlParameter("@pFechaDeOficio", objControlGestionAGA.FechaDeOficio));
                        query.Parameters.Add( new SqlParameter("@pFechaRecepcionAR", objControlGestionAGA.FechaRecepcionAR));
                        query.Parameters.Add( new SqlParameter("@pFechaRecepcionAGA", objControlGestionAGA.FechaRecepcionAGA));
                        query.Parameters.Add( new SqlParameter("@pPoblado", objControlGestionAGA.Poblado));
                        query.Parameters.Add( new SqlParameter("@pMunicipio", objControlGestionAGA.Municipio));
                        query.Parameters.Add( new SqlParameter("@pEstado", objControlGestionAGA.Estado));
                        query.Parameters.Add( new SqlParameter("@pAsunto", objControlGestionAGA.Asunto));
                        query.Parameters.Add( new SqlParameter("@pTurnadoA", objControlGestionAGA.TurnadoA));
                        query.Parameters.Add( new SqlParameter("@pFirma", objControlGestionAGA.Firma));
                        //query.Parameters.Add( new SqlParameter("@pTermino", objControlGestionAGA.Termino));
                        query.Parameters.Add( new SqlParameter("@pTermino", objControlGestionAGA.FechaTermino));
                        query.Parameters.Add( new SqlParameter("@pOficioRespuesta", objControlGestionAGA.OficioRespuesta));
                        query.Parameters.Add( new SqlParameter("@pFechaRespuesta", objControlGestionAGA.FechaRespuesta));
                        query.Parameters.Add( new SqlParameter("@pObservacionesRespuesta", objControlGestionAGA.ObservacionesRespuesta));
                        query.Parameters.Add( new SqlParameter("@pClasificacionArchivistica", objControlGestionAGA.ClasificacionArchivistica));
                        query.Parameters.Add( new SqlParameter("@pSolicitadoPor", objControlGestionAGA.SolicitadoPor));
                        query.Parameters.Add( new SqlParameter("@pCosto", objControlGestionAGA.Costo));
                        query.Parameters.Add( new SqlParameter("@pFojas", objControlGestionAGA.Fojas));
                        query.Parameters.Add( new SqlParameter("@pPlanos", objControlGestionAGA.Planos));
                        //query.Parameters.Add( new SqlParameter("@pFechaReg", objControlGestionAGA.FechaReg));
                        //query.Parameters.Add( new SqlParameter("@pusuario", objControlGestionAGA.usuario));
                        //query.Parameters.Add(new SqlParameter("@pestatus", objControlGestionAGA.estatus));


                    con.Open();
                    query.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return todoOK;

        }
    }
}
