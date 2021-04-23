using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Darbas.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public int Salary { get; set; }


        public EmployeeInfo EmployeeInfo { get; set; }
        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }
}