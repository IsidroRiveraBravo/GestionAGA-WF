using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.BusinessLayer
{
    public static class FillControls
    {

        public static bool ValidSelectedValueCombo(System.Windows.Forms.ComboBox comboBox)
        {
            bool todoOk = true;
            if (Convert.ToInt32(comboBox.SelectedValue.ToString()) == 0) todoOk = false;
            return todoOk;
        }

        public static void ComboBox<T>(System.Windows.Forms.ComboBox comboBox, List<T> datasource, string displayMember, string valueMember)
        {
            comboBox.DataSource = null;
            comboBox.DataSource = datasource;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
        }

        //public static void SetComoBoxEstado(System.Windows.Forms.ComboBox comboBox)
        //{
        //    BusinessLayer.cat_edoBL cat_edo = new BusinessLayer.cat_edoBL();
        //    List<EntityLayer.cat_edo> edoList = cat_edo.Read();
        //    edoList.Insert(0, new EntityLayer.cat_edo { clv_edo = 0, Estado = "Seleccione una opción" });

        //    BusinessLayer.FillControls.ComboBox(comboBox, edoList, "Estado", "clv_edo");

        //}


        //public static void SetComboBoxSerie(System.Windows.Forms.ComboBox comboBox, int valorDefault = 0)
        //{

        //    BusinessLayer.serie_documentalBL serie_doc = new BusinessLayer.serie_documentalBL();
        //    List<EntityLayer.serie_documental> serieList = serie_doc.Read();

        //    if (serieList.Count > 0)
        //    {

        //        serieList.Insert(0, new EntityLayer.serie_documental { clv_serie_doc = 0, Serie_documental = "Seleccione una opción", Abreviatura_serieDoc = "" });
        //        BusinessLayer.FillControls.ComboBox(comboBox, serieList, "Serie_documental", "clv_serie_doc");

        //        // Se pone disponible el comboBox
        //        comboBox.Enabled = true;
        //        comboBox.SelectedValue = valorDefault;


        //    }
        //    else
        //    {
        //        throw new Exception("No hay datos para la serie documental, seleccione otra por favor.");

        //    }


        //}

        //public static void SetComboAccionAgraria(System.Windows.Forms.ComboBox comboBox)
        //{
        //    try
        //    {
        //        BusinessLayer.accion_AgrariaBL accionBL = new BusinessLayer.accion_AgrariaBL();
        //        List<EntityLayer.accion_Agraria> accionList = accionBL.Read(Convert.ToInt32(comboBox.SelectedValue.ToString()));

        //        if (accionList.Count > 0)
        //        {
        //            comboBox.Enabled = true;
        //            accionList.Insert(0, new EntityLayer.accion_Agraria
        //            {
        //                clv_serie_doc = 0,
        //                clv_accionAgraria = "",
        //                Accion_Agraria = "Seleccione una opción",
        //                Abreviatura_accionAgraria = "",
        //                Activo = true,
        //                Notas = "",
        //            });

        //            BusinessLayer.FillControls.ComboBox(comboBox, accionList, "Accion_Agraria", "clv_accionAgraria");
        //        }
        //        else
        //        {
        //            throw new Exception("No hay datos para la Acción Agraría, llame a sistemas por favor.");
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }



        //}


        //public static void SetComboAccionAgraria(System.Windows.Forms.ComboBox comboBox, int valorDefault)
        //{
        //    try
        //    {
        //        BusinessLayer.accion_AgrariaBL accionBL = new BusinessLayer.accion_AgrariaBL();
        //        List<EntityLayer.accion_Agraria> accionList = accionBL.Read(Convert.ToInt32(comboBox.SelectedValue.ToString()));

        //        if (accionList.Count > 0)
        //        {
        //            comboBox.Enabled = true;
        //            accionList.Insert(0, new EntityLayer.accion_Agraria
        //            {
        //                clv_serie_doc = 0,
        //                clv_accionAgraria = "",
        //                Accion_Agraria = "Seleccione una opción",
        //                Abreviatura_accionAgraria = "",
        //                Activo = true,
        //                Notas = "",
        //            });

        //            BusinessLayer.FillControls.ComboBox(comboBox, accionList, "Accion_Agraria", "clv_accionAgraria");
        //            comboBox.SelectedValue = valorDefault;
        //        }
        //        else
        //        {
        //            throw new Exception("No hay datos para la Acción Agraría, llame a sistemas por favor.");
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }

        //}


        //public static void SetComboAccionAgraria(System.Windows.Forms.ComboBox comboBox, int valorDefault = 0, int valorFiltro = 0)
        //{
        //    try
        //    {
        //        BusinessLayer.accion_AgrariaBL accionBL = new BusinessLayer.accion_AgrariaBL();
        //        List<EntityLayer.accion_Agraria> accionList = accionBL.Read(valorFiltro);

        //        if (accionList.Count > 0)
        //        {
        //            comboBox.Enabled = true;
        //            accionList.Insert(0, new EntityLayer.accion_Agraria
        //            {
        //                clv_serie_doc = 0,
        //                clv_accionAgraria = "",
        //                Accion_Agraria = "Seleccione una opción",
        //                Abreviatura_accionAgraria = "",
        //                Activo = true,
        //                Notas = "",
        //            });

        //            BusinessLayer.FillControls.ComboBox(comboBox, accionList, "Accion_Agraria", "clv_accionAgraria");
        //            //comboBox.SelectedValue = 0;
        //        }
        //        else
        //        {
        //            throw new Exception("No hay datos para la Acción Agraría, llame a sistemas por favor.");
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        //public static void SetComboBoxDelegacion(System.Windows.Forms.ComboBox comboBox)
        //{
        //    BusinessLayer.cat_edoBL cat_edo = new BusinessLayer.cat_edoBL();
        //    List<EntityLayer.cat_edo> edoList = cat_edo.Read();
        //    edoList.Insert(0, new EntityLayer.cat_edo { clv_edo = 0, Estado = "Seleccione una opción" });

        //    BusinessLayer.FillControls.ComboBox(comboBox, edoList, "Estado", "clv_edo");

        //}

        //public static void SetComboBoxDelegacion(System.Windows.Forms.ComboBox comboBox, int valueDefault)
        //{
        //    BusinessLayer.cat_edoBL cat_edo = new BusinessLayer.cat_edoBL();
        //    List<EntityLayer.cat_edo> edoList = cat_edo.Read();
        //    edoList.Insert(0, new EntityLayer.cat_edo { clv_edo = 0, Estado = "Seleccione una opción" });

        //    BusinessLayer.FillControls.ComboBox(comboBox, edoList, "Estado", "clv_edo");
        //    comboBox.SelectedValue = valueDefault;

        //}

       
    }

}
