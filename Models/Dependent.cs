using System;
using System.Collections.Generic;

namespace HrSystem.Models
{
    public partial class Dependent
    {
        public long DependentId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Relationship { get; set; } = null!;
        public long EmployeeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;

        


    }
}
