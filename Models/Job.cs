using System;
using System.Collections.Generic;

namespace HrSystem.Models
{
    public partial class Job
    {
        public Job()
        {
            Employees = new HashSet<Employee>();
        }

        public long JobId { get; set; }
        public string JobTitle { get; set; } = null!;
        public double MinSalary { get; set; }
        public double MaxSalary { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public override string ToString()
        {
            return JobTitle;
        }
    }
}
