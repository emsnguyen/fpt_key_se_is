using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Q3_Demo.Entities
{
    class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }

        public override string ToString()
        {
            return EmployeeID.ToString();
        }
    }
}
