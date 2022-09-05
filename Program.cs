using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            string decision;
            Console.WriteLine("############################################## Welcome to pizza house #################################################");

            SqlConnection con = new SqlConnection(@"server=BHAVNAWKS651\SQLEXPRESS;database=pizza;Integrated Security=true;");
            do
            {

                Console.WriteLine("Enter your choice\nPress 1 to login as Admin\nPress 2 to login as Franchisee\nPress 3 to login as employee");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        {
                            Console.WriteLine("You have successfully logged in as admin");
                            Console.WriteLine("For Franchisee modification press 1\nFor Admin modification press 2");
                            int admininput = int.Parse(Console.ReadLine());
                            if (admininput==1)
                            {
                                CFranchisee f1 = new CFranchisee();
                                Console.WriteLine("Press 1 to Display all record\nPress 2 register new Franchisee record\nPress 3 to Delete record");
                                int franModification= int.Parse(Console.ReadLine());
                                switch(franModification)
                                {
                                    case 1:
                                        f1.display();
                                        break;

                                    case 2:
                                        f1.add();
                                        break;

                                    case 3:
                                        f1.delete();
                                        break;
                                    default:
                                        Console.WriteLine("You have entered invalid choise!");
                                        break;

                                }
                            }
                            else if(admininput==2)
                            {
                                admin a1 = new admin();
                                Console.WriteLine("Press 1 to Display all record\nPress 2 Add record\nPress 3 to Delete record");
                                int adminModification = int.Parse(Console.ReadLine());
                                switch (adminModification)
                                {
                                    case 1:
                                        a1.display();
                                        break;

                                    case 2:
                                        a1.add();
                                        break;

                                    case 3:
                                        a1.delete();
                                        break;
                                    default:
                                        Console.WriteLine("You have entered invalid choise!");
                                        break;

                                }
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("You have successfully logged in as Franchisee");
                            Console.WriteLine("Please enter 1 to register an employee\nEnter 2 to Salary distriburton\nEnter 3 to Display sale Datewise\nEnter 4 to Display sale data mode wise");
                            int franChoice = int.Parse(Console.ReadLine());
                            switch(franChoice)
                            {
                                case 1:
                                    CEmployee c1 = new CEmployee();
                                    c1.Add();
                                    break;

                                case 2:
                                    Console.WriteLine("Confirm the salary before distribution");
                                    con.Open();
                                    SqlCommand cmd2 = new SqlCommand($"select ename,salary from employee", con);
                                    SqlDataReader sdr2 = cmd2.ExecuteReader();
                                    while (sdr2.Read())
                                    {
                                        Console.WriteLine("Employee Name : " + sdr2.GetValue(0) + "\n" + "Employee Salary : " + sdr2.GetValue(1));
                                    }
                                    Console.WriteLine("Press yes to confirm distribution");
                                    string conf = Console.ReadLine();
                                    if (conf =="yes")
                                    {
                                        Console.WriteLine("salary distributed successfully");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Salary not distributed");
                                    }
                                    break;

                                case 3:
                                    Console.WriteLine("Enter the date for which you want data {format:yyyy-mm-dd}");
                                    DateTime currentDate = DateTime.Parse(Console.ReadLine());
                                    con.Open();
                                    SqlCommand cmd1 = new SqlCommand($"select * from sales where sale ='{currentDate}'", con);
                                    SqlDataReader sdr1 = cmd1.ExecuteReader();
                                    while (sdr1.Read())
                                    {
                                        Console.WriteLine("Sales id : " + sdr1.GetValue(0) + "\n" + "Pizza Ordered : " + sdr1.GetValue(1) + "\n" + "Employee id : " + sdr1.GetValue(2) + "\n" + "Order Timing : " + sdr1.GetValue(3) + "\n" + "Mode : " + sdr1.GetValue(4));
                                    }

                                    break;

                                case 4:
                                    Console.WriteLine("Enter online to display data in online mode\noff to display data in offline mode");
                                    string modeSelected = Console.ReadLine().ToUpper();
                                    con.Open();
                                    SqlCommand cmd = new SqlCommand($"select * from sales where mode ='{modeSelected}'", con);
                                    SqlDataReader sdr = cmd.ExecuteReader();
                                    while (sdr.Read())
                                    {
                                        Console.WriteLine("Sales id : " + sdr.GetValue(0) + "\n" + "Pizza Ordered : " + sdr.GetValue(1) + "\n" + "Employee id : " + sdr.GetValue(2) + "\n" + "Order Timing : " + sdr.GetValue(3) + "\n" + "Mode : " + sdr.GetValue(4));
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Enter valid choice");
                                    break;
                            }
                            break;
                        }

                    case 3:
                        {
                            Console.WriteLine("You have successfully logged in as employee");
                            Console.WriteLine("Please enter 1 to enter the record\nEnter 2 to display the recore");
                            int employeeChoice= int.Parse(Console.ReadLine());

                            switch (employeeChoice)
                            {

                                case 1:
                                    CSaleItem s1 = new CSaleItem();
                                    s1.add();
                                    break;

                                case 2:
                                    CSaleItem s2 = new CSaleItem();
                                    s2.display();
                                    break;

                                default:
                                    Console.WriteLine("Your choice is invalid");
                                    break;
                            }
                            
                            break;
                        }
                    default:
                        Console.WriteLine("Ivalid! Enter a valid choice to login");
                        break;
                   
                }
                Console.WriteLine("Do you want to continue with Pizza House? (Yes/No)");
                decision = Console.ReadLine();


            }while (decision.ToUpper() == "YES");

            Console.ReadLine();

        }
    }
}
