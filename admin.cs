using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Project
{
    class admin : IMethods
    {
        private int id;
        private string adminName;
        private string adminPassword;

        SqlConnection con = new SqlConnection(@"server=BHAVNAWKS651\SQLEXPRESS;database=pizza;Integrated Security=true;");
        public string name
        {
            get
            {
                return this.adminName;

            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Admin name cannot be null! Please enter admin name");
                }
                this.adminName = value;
            }
        }

        public string password
        {
            get
            {
                return this.adminPassword;

            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Your password cannot be null! Please enter your password");
                }
                this.adminPassword = value;
            }
        }

        public void display()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("select * from admin", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Console.WriteLine("Admin id : " + sdr.GetValue(0) + "\n" + "Admin name : " + sdr.GetValue(1));
            }
            con.Close();
        }

        public int add()
        {
            int flag = 0;
            try
            {
                Console.WriteLine("Enter admin name");
                name = Console.ReadLine();
                Console.WriteLine("Enter admin password");
                password = Console.ReadLine();

                con.Open();
                //Console.WriteLine($"insert into admin values('{name}','{password}')");
                SqlCommand cmd = new SqlCommand($"insert into admin values('{name}','{password}')", con);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Admin record inserted successfully");
                flag = 1;
            }
            catch (Exception)
            {
                Console.WriteLine("Insertion Failed! Try Again");
                Console.WriteLine();
            }
            return flag;

        }

        public int delete()
        {
            int flag = 0;
            try
            {
                Console.WriteLine("Enter the admin id that you want to delete ");
                id = int.Parse(Console.ReadLine());
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from admin where id=" + id + "", con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Admin with id:" + id + " deleted successfully");
                con.Close();
                flag = 1;
            }
            catch (Exception)
            {
                Console.WriteLine("Detetion Failed! Try Again");
                Console.WriteLine();
            }
            return flag;
        }
    }
}
