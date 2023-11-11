using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;

namespace arac_kiralama
{
    internal class sqlconn
    {
        public SqlConnection connsql()
        {

            SqlConnection consql = new SqlConnection("Data Source=Meert\\SQLEXPRESS;Initial Catalog=arac_kiralama;Integrated Security=True");

            consql.Open();
            return consql;

        }
     
        
        

    }
}
