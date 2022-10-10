using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CompanyEcosystem.BL.BusinessModels;
using CompanyEcosystem.BL.Data_Transfer_Object;
using CompanyEcosystem.DAL.Entities;

namespace CompanyEcosystem.BL.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeDTO Authenticate(EmployeeDTO model);
        EmployeeDTO Register(EmployeeDTO userModel);
        IEnumerable<EmployeeDTO> GetAll();
        EmployeeDTO GetById(int id);
    }

}
