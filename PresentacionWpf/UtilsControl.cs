using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Utils;
using static Utils.Utilities;

namespace PresentacionWpf
{
    public class UtilsControl
    {
        public static void SetTitulo(Modos modo, Label label, string section)
        {
            switch (modo)
            {
                case Utilities.Modos.Consultar:
                    label.Content = "Consultar " + section;
                    break;
                case Utilities.Modos.Insertar:
                    label.Content = "Insertar " + section;
                    break;
                case Utilities.Modos.Modificar:
                    label.Content = "Modificar " + section;
                    break;
                case Utilities.Modos.Eliminar:
                    label.Content = "Eliminar " + section;
                    break;
            }

        }
    }
}