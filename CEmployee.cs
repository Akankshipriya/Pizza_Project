using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Project
{
    public class CEmployee
    {
        public int eId;
        private string ename;
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public int salary { get; set; }


        SqlConnection con = new SqlConnection(@"server=BHAVNAWKS651\SQLEXPRESS;database=pizza;Integrated Security=true;");

        public int Add()
        {
            int flag = 0;
            try
            {
                Console.WriteLine("Enter employee name");
                ename = Console.ReadLine();
                Console.WriteLine("Enter employee phone number");
                phoneNumber = Console.ReadLine();
                Console.WriteLine("Enter employee email id");
                email = Console.ReadLine();
                Console.WriteLine("Enter employee salary");
                salary = int.Parse(Console.ReadLine());

                con.Open();
                //Console.WriteLine($"insert into admin values('{name}','{password}')");
                SqlCommand cmd = new SqlCommand($"insert into employee values('{ename}','{phoneNumber}','{email}',{salary})", con);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Inserted successfully");
                flag = 1;
            }
            catch (Exception)
            {
                Console.WriteLine("Insertion Failed! Try Again");
                Console.WriteLine();
            }
            return flag;

        }

    }
}
