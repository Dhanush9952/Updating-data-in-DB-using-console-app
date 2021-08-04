using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;

namespace EmploySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            string strcon = ConfigurationManager.ConnectionStrings["sqlpracticeconn"].ConnectionString;
            SqlConnection conn = new SqlConnection(strcon);
            int empno;
            Console.WriteLine("Enter Employ No ");
            empno = Convert.ToInt32(Console.ReadLine());
            SqlDataAdapter ad = new SqlDataAdapter("select * from Employ where Empno=@empno", conn);
            ad.SelectCommand.Parameters.AddWithValue("@empno",empno);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Emp");
            int count = ds.Tables["Emp"].Rows.Count;
            if (count == 1)
            {
                Console.WriteLine("Employ Name " + ds.Tables["Emp"].Rows[0]["Name"]);
                Console.WriteLine("Department " + ds.Tables["Emp"].Rows[0]["Dept"]);
                Console.WriteLine("Designation " + ds.Tables["Emp"].Rows[0]["Desig"]);
                Console.WriteLine("Basic " + ds.Tables["Emp"].Rows[0]["Basic"]);
            }
            else
            {
                Console.WriteLine("*****Record Not Found*****");
            }
        }
    }
}
