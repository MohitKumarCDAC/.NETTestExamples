
using Microsoft.Data.SqlClient;
using System.Data;

namespace ModelBinding.Models
{
    public class Employee
    {
        private int empNo { get; set; }
        private string name { get; set; }
        private decimal basic { get; set; }
        private int deptNo { get; set; }

        //properties
        public int EmpNo
        {
            get { return empNo; }
            set { empNo = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public decimal Basic
        {
            get { return basic; }
            set { basic = value; }
        }

        public int DeptNo
        {
            get { return deptNo; }
            set { deptNo = value; }
        }


        public Employee()
        {

        }
        public Employee(int empNo, string name, decimal basic, int deptNo)
        {
            EmpNo = empNo;
            Name = name;
            Basic = basic;
            DeptNo = deptNo;
            EmpNo = empNo;
            Name = name;
            Basic = basic;
            DeptNo = deptNo;
        }
    }
   

}
