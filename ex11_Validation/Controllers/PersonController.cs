using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ex11_Validation.Database;
using ex11_Validation.Models;

namespace ex11_Validation.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ApplicationContext _db;

        public PersonController(ApplicationContext db)
        {
            _db = db;
        }

        [HttpPost("add/manager")]
        public async Task<ActionResult<Manager>> AddManager([FromBody]Manager manager)
        {
            _db.Managers.Add(manager);
            await _db.SaveChangesAsync();

            return manager;
        }

        [HttpPost("add/employee")]
        public async Task<ActionResult<Employee>> AddEmployee([FromBody]Employee employee, 
            [FromQuery]int managerId)
        {
            var manager = _db.Managers.FirstOrDefault(manager => manager.Id == managerId);
            if (manager is null)
            {
                return BadRequest("Manager with such id does not exist");
            }

            employee.Manager = manager;
            _db.Employees.Add(employee);
            await _db.SaveChangesAsync();

            return employee;
        }

        [HttpPost("add/director")]
        public async Task<ActionResult<Director>> AddDirector([FromBody]Director director)
        {
            _db.Directors.Add(director);
            await _db.SaveChangesAsync();
            return director;
        }
    }
}
