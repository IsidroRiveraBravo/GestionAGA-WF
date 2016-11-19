using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionAGA_WF.EntityLayer;

namespace GestionAGA_WF.BusinessLayer
{
    public static class gestionUserAccess
    {
        
        internal static bool GetEnabledInsUserOption(EntityLayer.Usuario usuario, TabControl tabControl, string operacion)
        {
            // por omision el usuario tiene acceso
            bool enabled = true;
            List<EntityLayer.menuOptionsInsUpDel> listOptions = GetListOptionsMenuUser(usuario);

            try
            {
                if((tabControl.SelectedIndex + 1) <= listOptions.Count)
                {
                    List<optionsInsUpDel> options = listOptions[tabControl.SelectedIndex].options;

                    foreach (optionsInsUpDel item in options)
                    {
                        if (operacion.Trim().ToUpper() == item.operation.ToUpper())
                        {
                            enabled = Convert.ToBoolean(item.access);
                            break;
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            return enabled;
            
        }

        /// <summary>
        /// Solo se maneja el acceso a INS
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="tabPageName"></param>
        /// <returns></returns>
        internal static bool GetEnabledInsUserOption(EntityLayer.Usuario usuario, string tabPageName)
        {
            // por omision el usuario tiene acceso
            bool enabled = true;

            // se pregunta si tiene acceso a la pestaña y entonces pregunta por el acceso a INS, DEL, UPDATE
            if ( UserHaveAccessTabPage(usuario, tabPageName))
            {
               string optionsUserInsUpDel = GetOptionsInsDelUpInTabPage(usuario, tabPageName);

               switch (optionsUserInsUpDel.ToUpper())
               {
                   case "NADA":
                       enabled = false;
                       break;
                   case "TODO":
                       enabled = true;
                       break;

                   default:
                       enabled = DefineAccessToInsUpDel(optionsUserInsUpDel);
                       break;
               }

            }

            return enabled;
        }

        private static bool DefineAccessToInsUpDel(string optionsUserInsUpDel)
        {
            try
            {
                bool access = true;

                string optionClean = optionsUserInsUpDel.Substring(optionsUserInsUpDel.IndexOf('{'), (optionsUserInsUpDel.IndexOf('}') - 1));
                string[] optionsInsUpDel = optionClean.ToUpper().Trim().Split(',');

                foreach (string item in optionsInsUpDel)
                {

                    if (item.Trim().ToUpper().IndexOf("INS") >= 0)
                    {
                        string[] option = item.Split(':');
                        if (option[1].ToUpper() == "FALSE")
                        {
                            access = false;
                            break;
                        }
                    }
                }
                return access;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

           
        }

        private static string GetOptionsInsDelUpInTabPage(EntityLayer.Usuario usuario, string tabPageName)
        {
            string option = "";

            try
            {
                
                bool exitFor = false;
                int index = 0;

                // obtiene la cadena con las condiciones INS, DEL, UP
                string[] opcionesDeMenu = GetUsuarioOpcionesMenu(usuario);
                string[] opcionesInsDelUp = usuario.opcionesDeMenu.Split(';');

                // Se pregunta si el usuario tiene acceso a la pagina
                foreach (string item in opcionesDeMenu)
                {
                    switch (item.Trim())
                    {
                        case "*":
                            option = "TODO";
                            exitFor = true;
                            break;

                        case "0":
                            option = "NADA";
                            exitFor = true;
                            break;

                        case "8":
                            if (tabPageName.ToUpper() == "REGISTRO")
                                exitFor = true;
                            break;

                        case "26":
                            if (tabPageName.ToUpper() == "RECEPCION")
                                exitFor = true;
                            break;

                        default:

                            break;
                    }

                    // si lo encuentra se sale pero manda la cadena con las opciones Ins, Del, Up
                    if (exitFor)
                    {
                        if (!(option == "NADA" || option == "TODO")) option = opcionesInsDelUp[index];
                        break;
                    }
                    index++;
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
            return option;
        }

        private static bool UserHaveAccessTabPage(EntityLayer.Usuario usuario, string tabPageName)
        {
            bool userHaveAcces = true;

            try
            {
                bool exitFor = false;

                string[] opcionesDeMenu = GetUsuarioOpcionesMenu(usuario);

                // Se pregunta si el usuario tiene acceso a la pagina
                foreach (string item in opcionesDeMenu)
                {
                    switch (item.Trim())
                    {
                        case "*":
                            userHaveAcces = true;
                            exitFor = true;
                            break;

                        case "0":
                            userHaveAcces = false;
                            exitFor = true;
                            break;

                        case "8":
                            if (tabPageName.ToUpper() == "REGISTRO") userHaveAcces = true;
                            exitFor = true;
                            break;

                        case "26":
                            if (tabPageName.ToUpper() == "RECEPCION") userHaveAcces = true;
                            exitFor = true;
                            break;

                        default:
                            userHaveAcces = true;
                            break;
                    }

                    if (exitFor) break;

                }

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
            return userHaveAcces;
        }

        private static bool GetInsUserIns(string tabPageName)
        {
            // por omision el usuario tiene acceso
            bool haveIns = true;


            return haveIns;
        }

        private static string[] GetInsUpDelOptions(EntityLayer.Usuario usuario, string tabPageName)
        {
            string[] opcionesDeMenu = usuario.opcionesDeMenu.Split(';');
            try
            {
                int limite = opcionesDeMenu.Length - 1;

                for (int i = 0; i < limite; i++)
                {
                    // retira la opcion de menu  y los dos puntos (:)
                    opcionesDeMenu[i] = opcionesDeMenu[i].Trim().ToString().Remove(0, opcionesDeMenu[i].ToString().IndexOf(':') + 1).Trim();
                    opcionesDeMenu[i] = opcionesDeMenu[i].Trim().ToString().Remove(0, opcionesDeMenu[i].ToString().IndexOf(':')).Trim();
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            return opcionesDeMenu;
        }


        /// <summary>
        /// Obtiene las opciones de las pestañas disponibles para la gestion.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        internal static string[] GetUsuarioOpcionesMenu(EntityLayer.Usuario usuario)
        {
            List<EntityLayer.menuOptionsInsUpDel> listOptions = GetListOptionsMenuUser(usuario);
            string[] opcionesDeMenu = usuario.opcionesDeMenu.Split(';');
            
            try
            {
                int limite = opcionesDeMenu.Length - 1;

                for (int i = 0; i < limite; i++)
                {
                    // se prepara para remover las opciones de Ins, Del, Up. Y deja solo el numero de la opcion de menu
                    if (opcionesDeMenu[i].Trim().ToUpper().IndexOf(':') >=0 )
                    opcionesDeMenu[i] = opcionesDeMenu[i].ToString().Remove(opcionesDeMenu[i].ToString().IndexOf(':'));
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
            return opcionesDeMenu;
        }

        /// <summary>
        /// Obtiene las opciones de las pestañas disponibles para la gestion, en una lista.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        internal static List<EntityLayer.menuOptionsInsUpDel> GetListOptionsMenuUser(EntityLayer.Usuario usuario)
        {
            List<EntityLayer.menuOptionsInsUpDel> listOptions = new List<EntityLayer.menuOptionsInsUpDel>();
            string[] opcionesDeMenu = usuario.opcionesDeMenu.Split(';');

            try
            {
                int limite = opcionesDeMenu.Length - 1;
                foreach (string item in opcionesDeMenu)
                {
                    // se prepara para remover las opciones de Ins, Del, Up. Y deja solo el numero de la opcion de menu
                    EntityLayer.menuOptionsInsUpDel option = new EntityLayer.menuOptionsInsUpDel()
                    {
                        menu = GetNumberOption(item), // opcionesDeMenu[i].ToString().Remove(opcionesDeMenu[i].ToString().IndexOf(':') < 0 ? opcionesDeMenu[i]: ,
                        options = GetListOptionInsUpDelUser(item)
                    };

                    listOptions.Add(option);
                }

              
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

            return listOptions;
        }

        private static string GetNumberOption(string menu)
        {

            string option = "";
            try
            {
                if (menu.ToUpper().Trim().IndexOf(':') >= 0)
                {
                    option = menu.ToString().Remove(menu.ToString().IndexOf(':'));
                }
                else
                {
                    option = menu;
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

            return option;
        }

        private static List<EntityLayer.optionsInsUpDel> GetListOptionInsUpDelUser(string opcion)
        {
            List<EntityLayer.optionsInsUpDel> lista = new List<EntityLayer.optionsInsUpDel>();

            if (opcion.ToUpper().Trim().IndexOf(':') >= 0 && opcion.IndexOf('{') >= 0 && (opcion.IndexOf('}') - 1) >= 0 ) 
            {
               
                string opctionInsDelUp = opcion.Substring(opcion.IndexOf('{'), (opcion.IndexOf('}') - 1));
                string[] listOperaciones = opctionInsDelUp.Split(',');
                foreach (string item in listOperaciones)
                {
                    lista.Add(GetOptionWheIsInsOption(item));              
                }
            }
            else
            {
                GetListInsDelUpAllTrue();
            }

            return lista;
        }

        private static optionsInsUpDel GetOptionWheIsInsOption(string item)
        {
            EntityLayer.optionsInsUpDel option = new optionsInsUpDel();
            if (item.ToUpper().Trim().IndexOf("INS") >= 0)
            {
                option = GetInsOption(item);
            }
            else if (item.ToUpper().Trim().IndexOf("UP") >= 0)
            {
                option = GetUpDateOption(item);
            }
            else // (item.ToUpper().Trim().IndexOf("DEL") >= 0)
            {
                option = GetDeleteOption(item);
            }
            
            return option;
        }

        private static optionsInsUpDel GetDeleteOption(string item)
        {
            EntityLayer.optionsInsUpDel insOption = new optionsInsUpDel()
            {
                operation = "DELETE",
                access = "TRUE"
            };

            if (item.ToUpper().Trim().IndexOf("DEL") > 0 && item.ToUpper().Trim().IndexOf(":") > 0)
            {
                string[] operacion = item.Split(':');
                if (operacion.Count() > 0)
                {
                    insOption.access = operacion[1].ToUpper().Trim();
                }

            }

            return insOption;
        }

        private static optionsInsUpDel GetUpDateOption(string item)
        {
            EntityLayer.optionsInsUpDel insOption = new optionsInsUpDel()
            {
                operation = "UPDATE",
                access = "TRUE"
            };

            if (item.ToUpper().Trim().IndexOf("UP") > 0 && item.ToUpper().Trim().IndexOf(":") > 0)
            {
                string[] operacion = item.Split(':');
                if (operacion.Count() > 0)
                {
                    insOption.access = operacion[1];
                }

            }

            return insOption;
        }

        private static optionsInsUpDel GetInsOption(string item)
        {
            EntityLayer.optionsInsUpDel insOption = new optionsInsUpDel() 
            { 
                operation = "INSERT",
                access = "TRUE"
            };

            if (item.ToUpper().Trim().IndexOf("INS") > 0 && item.ToUpper().Trim().IndexOf(":") > 0)
            {
                string[] operacion = item.Split(':');
                if (operacion.Count() > 0)
                {                  
                   insOption.access = operacion[1] ;
                }

            }

            return insOption;
        }

        private static List<EntityLayer.optionsInsUpDel> GetListInsDelUpAllTrue()
        {
            List<EntityLayer.optionsInsUpDel> lista = new List<EntityLayer.optionsInsUpDel>();
            lista.Add(new EntityLayer.optionsInsUpDel { operation = "INSERT", access = "TRUE" });
            lista.Add(new EntityLayer.optionsInsUpDel { operation = "UPDATE", access = "TRUE" });
            lista.Add(new EntityLayer.optionsInsUpDel { operation = "DELETE", access = "TRUE" });
            return lista;

        }

        
        
    }
}
