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
    class EmployUpdate
    {
        static void Main(string[] args)
        {
            int empno, basic;
            Console.WriteLine("Enter Employ No ");
            empno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Employ Name ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Department ");
            string dept = Console.ReadLine();
            Console.WriteLine("Enter Designation ");
            string desig = Console.ReadLine();
            Console.WriteLine("Enter Employ Basic ");
            basic = Convert.ToInt32(Console.ReadLine());
            string strcon = ConfigurationManager.ConnectionStrings["sqlpracticeconn"].ConnectionString;
            SqlConnection conn = new SqlConnection(strcon);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Employ where empno=@empno", conn);
            ad.SelectCommand.Parameters.AddWithValue("@Empno",empno);
            SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Employ");
            DataRow dr = ds.Tables["Employ"].Rows[0];
            if (dr != null)
            {
                dr["Name"] = name;
                dr["Dept"] = dept;
                dr["Desig"] = desig;
                dr["Basic"] = basic;
                ad.Update(ds,"Employ");
                Console.WriteLine("*****Record Updated Successfully*****");
            }
            else
            {
                Console.WriteLine("*****Recoed Not Found*****");
            }
        }
    }
}
