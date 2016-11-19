using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAGA_WF.DataAccessLayer
{
    public interface ICRUD<T>
    {
        // propiedades
        string strConexion {get; set;}

        // Métodos
        List<T> Select();
        bool Insert(T objeto);
        bool UpDate(T objeto);
        bool Delete(T objeto);
    }
}
