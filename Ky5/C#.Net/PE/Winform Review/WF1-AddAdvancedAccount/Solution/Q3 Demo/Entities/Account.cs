using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Q3_Demo.Entities
{
    class Account
    {
        public string UserID { get; set; }
        public string DisplayName { get; set; }
        public DateTime JoinedDate { get; set; }
        public bool Active { get; set; }
        public int EmployeeID { get; set; }
    }
}
