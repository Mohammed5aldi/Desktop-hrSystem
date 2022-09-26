using System;
using System.Collections.Generic;

namespace HrSystem.Models
{
    public partial class Department : Object
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public long DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public long LocationId { get; set; }

        public virtual Location Location { get; set; } = null!;
        public virtual ICollection<Employee> Employees { get; set; }

        public override string ToString()
        {
            return DepartmentName;
        }
    }
}
