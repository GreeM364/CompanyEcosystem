using AutoMapper;
using CompanyEcosystem.BL.DataTransferObjects;
using CompanyEcosystem.BL.Infrastructure;
using CompanyEcosystem.BL.Interfaces;
using CompanyEcosystem.PL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEcosystem.PL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        public AccountController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            try
            {
                var employeeDto = _mapper.Map<RegisterViewModel, EmployeeDto>(model);

                var response =  _accountService.Register(employeeDto);

                return Ok(_mapper.Map<EmployeeDto, EmployeeViewModel>(response));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var employeeDto = _mapper.Map<AuthenticateViewModel, EmployeeDto>(model);

                var response = _accountService.Authenticate(employeeDto);

                return Ok(_mapper.Map<EmployeeDto, EmployeeViewModel>(response));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IEnumerable<EmployeeViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<EmployeeDto>, List<EmployeeViewModel>>(_accountService.GetAll());
        }
    }
}
