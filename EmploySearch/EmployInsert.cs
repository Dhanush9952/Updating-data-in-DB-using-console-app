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
    class EmployInsert
    {
        static void Main(string[] args)
        {
            int empno, basic;
            string name, dept, desig;
            Console.WriteLine("Enter Employ No ");
            empno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Employ Name ");
            name = Console.ReadLine();
            Console.WriteLine("Enter Department ");
            dept = Console.ReadLine();
            Console.WriteLine("Enter Designation ");
            desig = Console.ReadLine();
            Console.WriteLine("Enter Employ Basic ");
            basic = Convert.ToInt32(Console.ReadLine());
            string strcon = ConfigurationManager.ConnectionStrings["sqlpracticeconn"].ConnectionString;
            SqlConnection conn = new SqlConnection(strcon);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Employ", conn);
            SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Employ");
            DataRow dr = ds.Tables["Employ"].NewRow();
            dr["Empno"] = empno;
            dr["Name"] = name;
            dr["Dept"] = dept;
            dr["Desig"] = desig;
            dr["Basic"] = basic;
            ds.Tables["Employ"].Rows.Add(dr);
            ad.Update(ds, "Employ");
            Console.WriteLine("*****Record Inserted Successfully*****");
        }
    }
}
