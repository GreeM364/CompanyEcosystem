using System.Security.Claims;
using CompanyEcosystem.BL.Data_Transfer_Object;
using CompanyEcosystem.BL.Infrastructure;
using CompanyEcosystem.BL.Interfaces;
using CompanyEcosystem.PL.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEcosystem.PL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService EmployeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            EmployeeService = employeeService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    EmployeeDTO employeetDTO = new EmployeeDTO
                        { Email = model.Email, Password = model.Password, Position = model.Position };

                    var response =  EmployeeService.Register(employeetDTO);

                    if (response == null)
                        return BadRequest(new { message = "Didn't register!" });
                    

                    return Ok(response);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            Console.WriteLine("Error during registration"); //TODO: Переробити if
            return BadRequest();
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    EmployeeDTO employeetDTO = new EmployeeDTO
                        { Email = model.Email, Password = model.Password };

                    var response = EmployeeService.Authenticate(employeetDTO);

                    if (response == null)
                        return BadRequest(new { message = "Username or password is incorrect" });

                    return Ok(response);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return BadRequest();
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = EmployeeService.GetAll();
            return Ok(users);
        }
    }
}
