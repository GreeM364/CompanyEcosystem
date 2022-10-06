using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CompanyEcosystem.BL.BusinessModels;
using CompanyEcosystem.BL.Data_Transfer_Object;
using CompanyEcosystem.BL.Infrastructure;
using CompanyEcosystem.DAL.Entities;
using CompanyEcosystem.DAL.Interfaces;

namespace CompanyEcosystem.BL.Services
{
    public class ServiceEmployee
    {
        private readonly IRepository<Employee> Repository;
        public ServiceEmployee(IRepository<Employee> repository)
        {
            Repository = repository;
        }

        public void Register(EmployeeDTO employeeDTO)
        {
            var employee = Repository.GetAll().FirstOrDefault(x => x.Email == employeeDTO.Email);

            if (employee == null)
                throw new ValidationException("User with this login already exists", "");

            employee = new Employee()
            {
                Email = employeeDTO.Email,
                Password = HashPassword.HashPas(employeeDTO.Password),
                Role = Role.User.ToString(),
                Position = employeeDTO.Position.ToString()
            };

            Repository.Create(employee);
            var result = Authenticate(employee);
        }

        public ClaimsIdentity Authenticate(Employee employee)
        {
            var claims = new List<Claim>
            {
                new (ClaimsIdentity.DefaultNameClaimType, employee.Email),
                new (ClaimsIdentity.DefaultRoleClaimType, employee.Role)
            };

            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
