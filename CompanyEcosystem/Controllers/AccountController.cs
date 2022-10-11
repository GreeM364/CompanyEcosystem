using AutoMapper;
using CompanyEcosystem.BL.Data_Transfer_Object;
using CompanyEcosystem.BL.Infrastructure;
using CompanyEcosystem.BL.Interfaces;
using CompanyEcosystem.PL.Models;
using Microsoft.AspNetCore.Mvc;

//TODO: правельне відображення вивода всіх 
//TODO: правельне розміщення мідлвере
namespace CompanyEcosystem.PL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            try
            {
                EmployeeDTO employeetDTO = new EmployeeDTO
                    { Email = model.Email, Password = model.Password, Position = model.Position };

                var response =  _accountService.Register(employeetDTO);

                return Ok(new AuthenticateResponse {Email = response.Email, Position = response.Position, 
                    Role = response.Role, Token = response.Token});
            }
            catch (ValidationException e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                EmployeeDTO employeetDTO = new EmployeeDTO
                    { Email = model.Email, Password = model.Password };

                var response = _accountService.Authenticate(employeetDTO);

                return Ok(new AuthenticateResponse {Email = response.Email, Position = response.Position, 
                    Role = response.Role, Token = response.Token});
            }
            catch (ValidationException e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        public IEnumerable<AuthenticateResponse> GetAll()
        {
            IEnumerable<EmployeeDTO> employeeDtos = _accountService.GetAll();
            var mapper = new MapperConfiguration(configure => configure.CreateMap<EmployeeDTO, AuthenticateResponse>()).CreateMapper();
            var locations = mapper.Map<IEnumerable<EmployeeDTO>, List<AuthenticateResponse>>(employeeDtos);

            return locations;
        }
    }
}
