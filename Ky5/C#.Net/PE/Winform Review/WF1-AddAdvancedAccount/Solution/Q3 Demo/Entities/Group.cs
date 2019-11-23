using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Q3_Demo.Entities
{
    class Group
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public override string ToString()
        {
            return GroupID.ToString();
        }
    }
}
