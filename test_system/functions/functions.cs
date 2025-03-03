using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static test_system.global_variable;


namespace test_system
{
    internal class functions
    {


        public string fun_ascii_only (string get_string )
        {
            string returnValue = "";
            int loop;
            int new_string_counter = 0;

            byte[] return_bytes = new byte[100];
            byte[] get_bytes = Encoding.ASCII.GetBytes(get_string);

            for ( loop = 0; loop < get_string.Length; loop++)
            {
                if (get_bytes[loop] > 31)
                {
                    return_bytes[new_string_counter++] = get_bytes[loop];
                }
            }
            returnValue = System.Text.Encoding.UTF8.GetString(return_bytes);
            return returnValue;   
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




    }
}
