using Microsoft.Data.SqlClient;
using System.Data;

namespace DatabaseApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Connect();
            //Insert();



            try
            {
                List<Employee> employees = GetAllEmployees();

                //displaying retrived employees
                Console.WriteLine("Employees");
                foreach (var emp in employees)
                {
                    Console.WriteLine($"EmpNo: {emp.EmpNo}, Name: {emp.Name}, Basic: {emp.Basic}, DeptNo: {emp.DeptNo}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Data not found..." + ex.Message);
            }

            //try
            //{
            //    int id = 1;
            //    Employee emp = GetSingleEmployee(id);

            //    if (emp != null)
            //    {
            //        Console.WriteLine($"EmpNo: {emp.EmpNo}, Name: {emp.Name}, Basic: {emp.Basic}, DeptNo: {emp.DeptNo}");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Employee not found...");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Data not Found..." + ex.Message);
            //}

        }
        //connection
        static void Connect()
        {
            SqlConnection cn = new SqlConnection();
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJuly2024;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
            //cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJuly2024;User Id=sa;Password=password";

            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CdacActs2024;Integrated Security=True";
            try
            {
                cn.Open();
                Console.WriteLine("success");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }


        }
        static void Insert()
        {
            SqlConnection cn = new SqlConnection();
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJuly2024;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
            //cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJuly2024;User Id=sa;Password=password";
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CdacActs2024;Integrated Security=True";
            try
            {
                cn.Open();
                //SqlCommand cmdInsert = cn.CreateCommand();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = "insert into Employees values(20, 'Siddhesh', 999999999, 10)";
                cmdInsert.ExecuteNonQuery();


                Console.WriteLine("success");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }


        }
        static List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CdacActs2024;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.EmpNo = reader.GetInt32(0);
                        employee.Name = reader.GetString(1);
                        employee.Basic = reader.GetDecimal(2);
                        employee.DeptNo = reader.GetInt32(3);

                        employees.Add(employee);
                    }
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Data does not found.." + ex.Message);
            }
            return employees;
        }
        static Employee GetSingleEmployee(int EmpNo)
        {
            Employee emp = new Employee();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CdacActs2024;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees where EmpNo = @EmpNo";

                cmd.Parameters.AddWithValue("@EmpNo", EmpNo);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        emp.EmpNo = reader.GetInt32(0);
                        emp.Name = reader.GetString(1);
                        emp.Basic = reader.GetDecimal(2);
                        emp.DeptNo = reader.GetInt32(3);
                    }
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Data does not found.." + ex.Message);
            }

            return emp;
        }













        public class Employee
        {
            public int EmpNo { get; set; }
            public string Name { get; set; }
            public decimal Basic { get; set; }
            public int DeptNo { get; set; }


        }
    }


    
}
