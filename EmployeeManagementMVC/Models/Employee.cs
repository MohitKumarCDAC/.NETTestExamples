
using Microsoft.Data.SqlClient;
using System.Data;

namespace EmployeeManagementMVC.Models
{
    public class Employee
    {
        private int id;
        private string name;
        private string city;
        private string address;

        //properties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }


        public Employee()
        {
        }
        public Employee(int id,string name,string city,string address)
        {
            Id= id;
            Name= name;
            City= city;
            Address= address;
        }

        internal static List<Employee> GetAllEmployee()
        {
            List<Employee> EmpList = new List<Employee>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Mohit;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from EmployeeManagement";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee empDetails = new Employee();
                        empDetails.Id = reader.GetInt32(0);
                        empDetails.Name = reader.GetString(1);
                        empDetails.City = reader.GetString(2);
                        empDetails.Address = reader.GetString(3);

                        EmpList.Add(empDetails);
                    }
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return EmpList;
        

    }

        internal static Employee GetSingleEmployee(int id)
        {
            Employee EmpSingle = new Employee();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Mohit;Integrated Security=True";

            try
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from EmployeeManagement where id=@Id";
                cmd.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        EmpSingle.Id = reader.GetInt32(0);
                        EmpSingle.Name = reader.GetString(1);
                        EmpSingle.City = reader.GetString(2);
                        EmpSingle.Address = reader.GetString(3);
                        

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return EmpSingle;
        }

        internal static void Create(Employee emp)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Mohit;Integrated Security=True";
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into EmployeeManagement values(@Id,@Name,@City,@Address)";

                cmd.Parameters.AddWithValue("@Id", emp.Id);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@City", emp.City);
                cmd.Parameters.AddWithValue("@Address", emp.Address);


                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        internal static void Edit(int id, Employee emp)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Mohit;Integrated Security=True";
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update EmployeeManagement set Name=@Name,City=@City,Address=@Address where Id=@Id";


                cmd.Parameters.AddWithValue("@Name", emp .Name);
                cmd.Parameters.AddWithValue("@City",emp.city);
                cmd.Parameters.AddWithValue("@Address", emp.Address);
              
                cmd.Parameters.AddWithValue("@Id", id);
                //execute the update query
                int readData = cmd.ExecuteNonQuery();
                if (readData > 0)
                {
                    Console.WriteLine("Update Successfull");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        internal static void Delete(int id)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Mohit;Integrated Security=True";
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from EmployeeManagement where Id=@Id";

                cmd.Parameters.AddWithValue("@Id", id);
                int data = cmd.ExecuteNonQuery();
                if (data > 0)
                {
                    Console.WriteLine("delete Data");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
