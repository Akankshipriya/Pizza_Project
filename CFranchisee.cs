using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Project
{
    class CFranchisee: IMethods
    {
        private int id;
        private string fname;
        private string pincode;

        SqlConnection con = new SqlConnection(@"server=BHAVNAWKS651\SQLEXPRESS;database=pizza;Integrated Security=true;");

        public string name
        {
            get
            {
                return this.fname;

            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Franchisee Name cannot be null! Please enter franchisee name");
                }
                this.fname = value;
            }
        }

        public string Pincode
        {
            get
            {
                return this.pincode;

            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Franchisee Name cannot be null! Please enter franchisee name");
                }
                this.pincode = value;
            }
        }

        public void display()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Franchisee", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Console.WriteLine("Franchisee id : " + sdr.GetValue(0) + "\n" + "Franchisee name : " + sdr.GetValue(1) + "\n" + "Franchisee pincode : " + sdr.GetValue(2));
            }
            con.Close();
        }

        public int add()
        {
            int flag = 0;
            try
            {
                Console.WriteLine("Enter Franchisee name");
                name = Console.ReadLine();
                Console.WriteLine("Enter CFranchisee Pincode");
                Pincode = Console.ReadLine();

                con.Open();
                //Console.WriteLine($"insert into admin values('{name}','{password}')");
                SqlCommand cmd = new SqlCommand($"insert into Franchisee values('{name}','{Pincode}')", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Franchisee record registered successfully");
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
                Console.WriteLine("Enter the  Franchisee id that you want to delete ");
                id = int.Parse(Console.ReadLine());
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from Franchisee where id=" + id + "", con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("product with id:" + id + " deleted successfully");
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
