using System;
using System.Collections.Generic;

namespace HrSystem.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Dependents = new HashSet<Dependent>();
            InverseManager = new HashSet<Employee>();
        }

        public long EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string HireDate { get; set; } = null!;
        public long JobId { get; set; }
        public double Salary { get; set; }
        public long? ManagerId { get; set; }
        public long DepartmentId { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual Job Job { get; set; } = null!;
        public virtual Employee? Manager { get; set; }
        public virtual ICollection<Dependent> Dependents { get; set; }
        public virtual ICollection<Employee> InverseManager { get; set; }

        public override string ToString()
        {
            return FirstName + LastName + EmployeeId;
        }
    }
}
