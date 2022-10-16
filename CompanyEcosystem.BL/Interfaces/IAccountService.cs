using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CompanyEcosystem.BL.BusinessModels;
using CompanyEcosystem.BL.DataTransferObjects;
using CompanyEcosystem.DAL.Entities;

namespace CompanyEcosystem.BL.Interfaces
{
    public interface IAccountService
    {
        EmployeeDto Authenticate(EmployeeDto employeeDto);
        EmployeeDto Register(EmployeeDto employeeDto);
        IEnumerable<EmployeeDto> GetAll();
        EmployeeDto GetById(int id);
    }

}
