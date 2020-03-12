using System;
using System.Text;
using System.Windows.Forms;

namespace Utils
{
    public class Utilities
    {
        public enum Modos { Cerrar, Consultar, Seleccionar, Insertar, Modificar, Eliminar };

        public static bool ConfirmDialog(String title, String message)
        {
            if (MessageBox.Show(message, title, MessageBoxButtons.YesNo) == DialogResult.Yes)
                return true;
            return false;
        }

        public static void SetTitulo(Modos modo, Label label, string section)
        {
            switch (modo)
            {
                case Utilities.Modos.Consultar:
                    label.Text = "Consultar " + section;
                    break;
                case Utilities.Modos.Insertar:
                    label.Text = "Insertar " + section;
                    break;
                case Utilities.Modos.Modificar:
                    label.Text = "Modificar " + section;
                    break;
                case Utilities.Modos.Eliminar:
                    label.Text = "Eliminar " + section;
                    break;
            }
        }

        public static string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("x2"));

            return sb.ToString();
        }

        public static string[] GetMeses()
        {
            string[] meses = {
                "Enero",
                "Febrero",
                "Marzo",
                "Abril",
                "Mayo",
                "Junio",
                "Julio",
                "Agosto",
                "Septiembre",
                "Octubre",
                "Noviembre",
                "Diciembre"
            };
            return meses;
        }

        public static string[] GetAnos(int num = 20)
        {
            string[] anos = new string[num + 1];
            int index = 0;
            for (int ano = DateTime.Now.Year; ano >= DateTime.Now.Year - num; ano--)
            {
                anos[index] = ano.ToString();
                index++;
            }
            return anos;
        }

    }
}