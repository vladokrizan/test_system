using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static test_system.global_variable;


namespace test_system
{
    internal class functions
    {


        #region "funkcije za pretvorbo  "


        //=======================================================================================================================
        /// <summary>
        ///     pretvorba byta v bite 
        /// 
        ///             BitArray messageBits1 = new BitArray (10);
        ///             messageBits1 =  functions.func_byte_to_bits(1);
        ///             label5.Text = messageBits1[0].ToString();
        /// </summary>
        /// <param name="get_byte"></param>
        /// <returns></returns>
        //=======================================================================================================================
        public static BitArray func_byte_to_bits(byte get_byte)
        {
            byte[] _byte = new byte[3];
            _byte[0] = get_byte;
            BitArray messageBits = new BitArray(_byte);
            return messageBits;
        }





        /*
                    byte[] bytes_new = new byte [100];
                    int string_lenght;
                    int new_string_counter = 0;
                    string tmpString = "aa$fdffT.0\r14_rt_0-44\n\r4\\4r";
                    string_lenght = tmpString.Length;
                   label4.Text = tmpString;
                   label1.Text ="lenght " + string_lenght.ToString();
                            //string b = tmpString.Substring(0, 3);
                    byte[] bytes = Encoding.ASCII.GetBytes(tmpString);

                    for ( int loop=0; loop < string_lenght; loop++ )
                    {
                        if (bytes[loop] > 31)
                        {
                            bytes_new[new_string_counter++] = bytes[loop];
                        }
                    }
                    string result = System.Text.Encoding.UTF8.GetString(bytes_new ) ;
                    label2.Text = bytes[0].ToString()+"   "+ result;
                    textBox1.Text = tmpString;
                    label5.Text = result;

                byte[] bytes_new = new byte[100];
                int string_lenght;
                int new_string_counter = 0;
                string tmpString = "aa$fdffT014_rtr";
                string_lenght = tmpString.Length;
                    label1.Text ="lenght " + string_lenght.ToString();
                    //string b = tmpString.Substring(0, 3);
                    byte[] bytes = Encoding.ASCII.GetBytes(tmpString);
                    for (int loop=0; loop<string_lenght; loop++ )
                    {
                        if (bytes[loop] > 40)
                        {
                            bytes_new[new_string_counter++] = bytes[loop];
                        }
        }
        string result = System.Text.Encoding.UTF8.GetString(bytes_new);
        label2.Text = bytes[0].ToString() + "   " + result;
        textBox1.Text = tmpString;
        */

        #endregion

        #region "ASCII funkcije "

        //=======================================================================================================================
        //=======================================================================================================================
        public string fun_ascii_only(string get_string)
        {
            string returnValue = "";
            int loop;
            int new_string_counter = 0;

            byte[] return_bytes = new byte[100];
            byte[] get_bytes = Encoding.ASCII.GetBytes(get_string);

            for (loop = 0; loop < get_string.Length; loop++)
            {
                if (get_bytes[loop] > 31)
                {
                    return_bytes[new_string_counter++] = get_bytes[loop];
                }
            }
            returnValue = System.Text.Encoding.UTF8.GetString(return_bytes);
            return returnValue;
        }

        //=======================================================================================================================
        //=======================================================================================================================
        public string fun_convert_string_to_current_decimal_separator(string get_string)
        {
            string strReturnString = "";
            int loop;
            try
            {
                string decimalSeparator = CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator;
                if (decimalSeparator.Equals(","))
                {
                    for (loop = 0; loop <= get_string.Length - 1; loop++)
                    {
                        if (get_string[loop] == '.')
                            strReturnString = strReturnString + ',';
                        else
                            strReturnString = strReturnString + (get_string[loop]);
                    }
                }
                if (decimalSeparator.Equals("."))
                {
                    for (loop = 0; loop <= get_string.Length - 1; loop++)
                    {
                        if (get_string[loop] == ',')
                            strReturnString = strReturnString + '.';
                        else
                            strReturnString = strReturnString + (get_string[loop]);
                    }
                }
            }
            catch { }
            return (strReturnString);
        }


        //=============================================================================================================
        //=============================================================================================================
        public string fun_convert_string_to_decimal_separator_pika(string get_string)
        {
            string strReturnString = "";
            int loop;
            try
            {
                for (loop = 0; loop <= get_string.Length - 1; loop++)
                {
                    if (get_string[loop] == ',')
                        strReturnString = strReturnString + '.';
                    else
                        strReturnString = strReturnString + (get_string[loop]);
                }
            }
            catch
            {
            }
            return (strReturnString);
        }






        #endregion








    }
}
