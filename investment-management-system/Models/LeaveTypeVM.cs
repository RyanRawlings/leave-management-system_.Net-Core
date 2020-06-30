using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace investment_management_system.Models
{

    public class DetailsLeaveTypeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
    }

    
    // Allows you to tone down or increase the amount of data exposed to the view
    public class CreateLeaveTypeVM
    {
        [Required]
        public string Name { get; set; }
    }
}
