using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyVienPhi
{
    public class ConnectionString
    {
        // connect to database
        public static string g_sConnection = @"Data Source=LAPTOP-9O8H2MCL;Initial Catalog=QLVP;Integrated Security=True";
        // method using create random id Physician, id Employee, id Patients
        public static string g_sRandomString(string s)
        {
            // random
            Random rand = new Random();
            return (s + rand.Next(int.MaxValue).ToString());
        }
    }
}
