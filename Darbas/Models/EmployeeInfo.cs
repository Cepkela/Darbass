using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Darbas.Models
{
    public class EmployeeInfo
    {
        [Key]
        public int EmployeeId { get; set; }
        public int Age { get; set; }
        [Required]
        public virtual Employee Employee { get; set; }
    }
}