using AutoMapper;
using CompanyEcosystem.BL.DataTransferObjects;
using CompanyEcosystem.BL.Interfaces;
using CompanyEcosystem.BL.Infrastructure;
using CompanyEcosystem.DAL.Entities;
using CompanyEcosystem.DAL.Interfaces;
using Microsoft.Extensions.Configuration;

namespace CompanyEcosystem.BL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Employee?> _repository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AccountService(IRepository<Employee?> repository, IConfiguration configuration, IMapper mapper)
        {
            _repository = repository;
            _configuration = configuration;
            _mapper = mapper;
        }

        public EmployeeDto Register(EmployeeDto employeeDto)
        {
            var employee = _repository.GetAsync(e => e.Email == employeeDto.Email);

            if (employee != null)
                throw new ValidationException("The employee is already registered", "");

            var result = _mapper.Map<EmployeeDto, Employee>(employeeDto);
            _repository.CreateAsync(result);

            var response = Authenticate(new EmployeeDto()
            {
                Email = employeeDto.Email,
                Password = employeeDto.Password
            });

            return response;
        }

        public EmployeeDto Authenticate(EmployeeDto employeeDto)
        {
            var user = _repository.GetFirstAsync(x => x.Email == employeeDto.Email
                                                      && x.Password == HashPassword.HashPas(employeeDto.Password));

            
            if (user == null)
                throw new ValidationException("Username or password is incorrect", "");
                
            var token = UserHelper.GenerateJwtToken(_configuration, user.Result);

            return new EmployeeDto
            {
                Email = user.Result.Email, 
                Role = user.Result.Role, 
                Position = user.Result.Position, 
                Token = token
            };
        }

        public IEnumerable<EmployeeDto> GetAll()
        {
            var employees = _mapper.Map<List<Employee>, List<EmployeeDto>>(_repository.GetAllAsync().Result!);

            //if (employees == null)
            //    throw new ValidationException("Employees not found", "");

            return employees;
        }

        public EmployeeDto GetById(int id)
        { 
           var employee =  _repository.GetByIdAsync(id);

           if (employee == null)
               throw new ValidationException("Employee not found", "");

           return new EmployeeDto 
           { 
               Email = employee.Result.Email, 
               Role = employee.Result.Role, 
               Position = employee.Result.Position
           };
        }
    }
}
