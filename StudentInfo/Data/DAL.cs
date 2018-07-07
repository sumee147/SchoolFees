using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
namespace StudentInfo.Data
{
    class DAL
    {

		public  SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentInfoConnectionString"].ConnectionString);
    }
   
}

