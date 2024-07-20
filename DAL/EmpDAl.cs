using Microsoft.Data.SqlClient;
using ModelBinding.Models;
using System.Data;

namespace ModelBinding.DAL
{
    public class EmpDAl
    {

        static void Connect()
        {
            SqlConnection cn = new SqlConnection();
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
        public static List<Employee> GetAllEmployees()
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

        public static Employee GetSingleEmployee(int EmpNo)
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

        internal static void Insert(Employee emp)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CdacActs2024;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = "insert into Employees values(@EmpNo, @Name, @Basic,@DeptNo)";

                cmdInsert.Parameters.AddWithValue("@EmpNo", emp.EmpNo);
                cmdInsert.Parameters.AddWithValue("@Name", emp.Name);
                cmdInsert.Parameters.AddWithValue("@Basic", emp.Basic);
                cmdInsert.Parameters.AddWithValue("@DeptNo", emp.DeptNo);

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

        internal static void Edit(int EmpNo,Employee obj)
        {
           
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CdacActs2024;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Employees set Name=@Name,Basic=@Basic,DeptNo=@DeptNo where EmpNo=@EmpNo";

                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@Basic", obj.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", obj.DeptNo);
                cmd.Parameters.AddWithValue("@EmpNo", EmpNo);

                //execute the update query
                int readData = cmd.ExecuteNonQuery();
                if (readData > 0)
                {
                    //fetch the employee
                   
                    Console.WriteLine("Employee No:" + EmpNo + "Update successfully");
                }
                else
                {
                    Console.WriteLine("Not found...");
                }
                cn.Close();



            }
            catch (Exception ex)
            {
                Console.WriteLine("Data not Found..." + ex.Message);
            }
            
        }

        internal static void Delete(int id)
        {
           Employee employee=new Employee();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CdacActs2024;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText= "Delete From Employees where EmpNo = @EmpNo";

                cmd.Parameters.AddWithValue("@EmpNo",id);

                int data=cmd.ExecuteNonQuery();
                if (data > 0)
                {
                    Console.WriteLine("Data Deleted"+id);
                }
                else
                {
                    Console.WriteLine("data not found");
                }

            } 
            catch (Exception ex) {
                Console.WriteLine("Data not found To delete:"+ex.Message);
                    }
        }
    }
    }
