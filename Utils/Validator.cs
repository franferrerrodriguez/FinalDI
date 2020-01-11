using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Utils
{
    public class Validator
    {
        public static bool ValidateEmail(String str)
        {
            return Regex.Match(str, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success ? true : false;
        }

        public static bool ValidateDocument(String str)
        {
            bool result = false;
            if (str.Length.Equals(9))
            {
                try
                {
                    // NIE
                    if (ValidateOnlyLetters(str.Substring(0, 1)) && GetLetterNie(str.Substring(0, 8)).Equals(str.Substring(8)))
                        result = true;
                    // CIF / NIF
                    else if (GetLetterNif(str.Substring(0, 8)).Equals(str.Substring(8)))
                        result = true;
                }
                catch (Exception e)
                {
                    result = false;
                }
            }
            return result;
        }

        public static bool ValidatePassword(String str)
        {
            return true;
        }

        public static bool ValidateDateNac(DateTime date)
        {
            return DateTime.Now > date ? true : false;
        }

        private static string GetLetterNif(String str)
        {
            return "TRWAGMYFPDXBNJZSQVHLCKET"[Convert.ToInt32(str) % 23].ToString();
        }

        private static string GetLetterNie(String str)
        {
            str = "XYZ".IndexOf(str.Substring(0, 1)) + str.Substring(1, 7);
            return "TRWAGMYFPDXBNJZSQVHLCKET"[Convert.ToInt32(str) % 23].ToString();
        }


        public static bool ValidatePhone(String str)
        {
            return Regex.Match(str, @"^(\+34|34)?[6|7|8|9][0-9]{8}$").Success ? true : false;
        }

        public static bool ValidatePostalCode(String str)
        {
            return str.Length.Equals(5) && Regex.Match(str, @"^([1-9]{2}|[0-9][1-9]|[1-9][0-9])[0-9]{3}$").Success ? true : false;
        }

        public static bool ValidateOnlyLetters(String str)
        {
            return Regex.Match(str, @"[a-zA-ZñÑ\s]").Success ? true : false;
        }

        public static bool ValidateEmpty(String str)
        {
            return str.Replace(" ", "").Equals("") ? false : true;
        }

        public static bool ValidateOnlyNumbers(String str)
        {
            return Regex.Match(str, @"[0-9]{1,9}(\.[0-9]{0,2})?$").Success ? true : false;
        }

        public static void IndicarError(Control control, ErrorProvider errorProvider, Boolean active = false, String error = "")
        {
            ToolTip TTIP = new ToolTip();
            TTIP.SetToolTip(control, error);
            control.BackColor = active ? Color.LightCoral : Color.White;
            errorProvider.SetError(control, error);
        }

    }
}