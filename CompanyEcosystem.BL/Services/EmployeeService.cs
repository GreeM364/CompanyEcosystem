using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CompanyEcosystem.BL.Data_Transfer_Object;
using CompanyEcosystem.BL.Interfaces;
using CompanyEcosystem.BL.Infrastructure;
using CompanyEcosystem.DAL.Entities;
using CompanyEcosystem.DAL.Interfaces;
using Microsoft.Extensions.Configuration;

namespace CompanyEcosystem.BL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> Repository;
        private readonly IConfiguration _configuration;

        public EmployeeService(IRepository<Employee> repository, IConfiguration configuration)
        {
            Repository = repository;
            _configuration = configuration;
        }

        public EmployeeDTO Authenticate(EmployeeDTO employeeDTO)
        {
            var user = Repository.GetAll().FirstOrDefault(x => x.Email == employeeDTO.Email && x.Password == employeeDTO.Password);

            if (user == null)
            {
                // todo: need to add logger
                return null;
            }

            var token = _configuration.GenerateJwtToken(user);

            return new EmployeeDTO {Email = user.Email, Role = user.Role, Position = user.Position, Token = token};
        }

        public EmployeeDTO Register(EmployeeDTO employeeDTO)
        {
            var employee = Repository.GetAll().FirstOrDefault(e => e.Email == employeeDTO.Email);

            if (employee != null)
                throw new ValidationException("The employee is already registered", "");

            Repository.Create(new Employee
            {
                Email = employeeDTO.Email, 
                Password = employeeDTO.Password, 
                Role = "User",
                Position = employee.Position
            });

            var response = Authenticate(new EmployeeDTO()
            {
                Email = employeeDTO.Email,
                Password = employeeDTO.Password
            });

            return response;
        }

        public IEnumerable<EmployeeDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Employee,EmployeeDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(Repository.GetAll());
        }

        public EmployeeDTO GetById(int id)
        {
           var employee =  Repository.Get(id);
           return new EmployeeDTO { Email = employee.Email, Role = employee.Role, Position = employee.Position};
        }
    }
}
