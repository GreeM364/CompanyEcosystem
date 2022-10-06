using CompanyEcosystem.PL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEcosystem.PL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        public AccountController()
        {

        }

        [HttpGet]
        public void Login()
        {
            // TODO: зробити відображення сторінки регістрації
        }

        [HttpPost]
        public void Register(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                
            }
        }
    }
}
