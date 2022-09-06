using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Project
{
    class CSaleItem : IMethods
    {
        private int sid;
        public string pizzaName;

        public int eId;

        public DateTime sellingtime = DateTime.Now.Date;


        public string mode { get; set; }


        SqlConnection con = new SqlConnection(@"server=BHAVNAWKS651\SQLEXPRESS;database=pizza;Integrated Security=true;");

        public void display()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from sales", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Console.WriteLine("Sales id : " + sdr.GetValue(0) + "\n" + "Pizza Ordered : " + sdr.GetValue(1) + "\n" + "Employee id : " + sdr.GetValue(2) + "\n" + "Order Timing : " + sdr.GetValue(3) + "\n" + "Mode : " + sdr.GetValue(4));
            }
            con.Close();
        }

        public int add()
        {
            int flag = 0;
            try
            {
                Console.WriteLine("Enter Pizza name");
                pizzaName = Console.ReadLine();

                Console.WriteLine("Enter your employee id");
                eId = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the mode");
                mode = Console.ReadLine();



                con.Open();
                Console.WriteLine($"insert into sales values('{pizzaName}',{eId},'{sellingtime}','{mode}')");
                SqlCommand cmd = new SqlCommand($"insert into sales(pizzaname,employeeid,sale,mode) values('{pizzaName}',{eId},'{sellingtime}','{mode}')", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("inserted successfully");
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
                Console.WriteLine("Enter the  sale id that you want to delete ");
                sid = int.Parse(Console.ReadLine());
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from sales where id=" + sid + "", con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("product with id:" + sid+ " deleted successfully");
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
