using System;
using System.Collections.Generic;

namespace HrSystem.Models
{
    public partial class Location
    {
        public Location()
        {
            Departments = new HashSet<Department>();
        }

        public long LocationId { get; set; }
        public string? StreetAddress { get; set; }
        public string? PostalCode { get; set; }
        public string City { get; set; } = null!;
        public string? StateProvince { get; set; }
        public long CountryId { get; set; }

        public virtual ICollection<Department> Departments { get; set; }

        public override string ToString()
        {
            return $"{StreetAddress}, {City}";
        }
    }
}
