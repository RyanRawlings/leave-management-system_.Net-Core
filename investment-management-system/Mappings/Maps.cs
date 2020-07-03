using AutoMapper;
using investment_management_system.Data;
using investment_management_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace investment_management_system.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {            
            CreateMap<LeaveType, LeaveTypeVM>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationVM>().ReverseMap();
            CreateMap<LeaveHistory, LeaveHistoryVM>().ReverseMap();
            CreateMap<Employee, EmployeeVM>().ReverseMap();
        }
    }
}
