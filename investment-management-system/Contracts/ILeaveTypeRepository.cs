using investment_management_system.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace investment_management_system.Contracts
{
    // How to inherit public interface behaviour
    public interface ILeaveTypeRepository : IRepositoryBase<LeaveType>
    {
    }
}

