using System;
using AutoMapper;
using CompanyEcosystem.BL.Data_Transfer_Object;
using CompanyEcosystem.BL.Interfaces;
using CompanyEcosystem.BL.Infrastructure;
using CompanyEcosystem.DAL.Entities;
using CompanyEcosystem.DAL.Interfaces;
using Microsoft.Extensions.Configuration;

namespace CompanyEcosystem.BL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Employee> _repository;
        private readonly IConfiguration _configuration;

        public AccountService(IRepository<Employee> repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public EmployeeDTO Register(EmployeeDTO employeeDto)
        {
            var employee = _repository.GetAll().FirstOrDefault(e => e.Email == employeeDto.Email);

            if (employee != null)
                throw new ValidationException("The employee is already registered", "");

            _repository.Create(new Employee
            {
                Email = employeeDto.Email,
                Password = HashPassword.HashPas(employeeDto.Password),
                Role = "User",
                Position = employeeDto.Position,
                LocationId = 1 // TODO: додати вибір відділу 
            });

            var response = Authenticate(new EmployeeDTO()
            {
                Email = employeeDto.Email,
                Password = employeeDto.Password
            });

            return response;
        }

        public EmployeeDTO Authenticate(EmployeeDTO employeeDto)
        {
            var user = _repository.GetAll().FirstOrDefault(x => x.Email == employeeDto.Email 
                                                                && x.Password == HashPassword.HashPas(employeeDto.Password));

            if (user == null)
                throw new ValidationException("Username or password is incorrect", "");

            var token = _configuration.GenerateJwtToken(user);

            return new EmployeeDTO {Email = user.Email, Role = user.Role, Position = user.Position, Token = token};
        }

        public IEnumerable<EmployeeDTO> GetAll()
        {
            var mapper = new MapperConfiguration(configure => configure.CreateMap<Employee,EmployeeDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(_repository.GetAll());
        }

        public EmployeeDTO GetById(int id)
        {
           var employee =  _repository.Get(id);
           return new EmployeeDTO { Email = employee.Email, Role = employee.Role, Position = employee.Position};
        }
    }
}
