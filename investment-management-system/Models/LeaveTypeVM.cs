using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace investment_management_system.Models
{
    // Allows you to tone down or increase the amount of data exposed to the view
    public class LeaveTypeVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name="Date Created")]
        // Making the value nullable means that a value can be applied at any point rather then at runtime.
        public DateTime? DateCreated { get; set; }
    }
}
