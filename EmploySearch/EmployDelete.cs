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
    class EmployDelete
    {
        static void Main(string[] args)
        {
            int empno;
            Console.WriteLine("Enter Employ No ");
            empno = Convert.ToInt32(Console.ReadLine());
            string strcon = ConfigurationManager.ConnectionStrings["sqlpracticeconn"].ConnectionString;
            SqlConnection conn = new SqlConnection(strcon);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Employ where empno=@empno", conn);
            ad.SelectCommand.Parameters.AddWithValue("@Empno", empno);
            SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
            cmd.DataAdapter = ad;
            DataSet ds = new DataSet();
            ad.Fill(ds, "Employ");
            DataRow dr = ds.Tables["Employ"].Rows[0];
            dr.Delete();
            ad.Update(ds, "Employ");
            Console.WriteLine("*****Record Deleted*****");
        }
    }
}
