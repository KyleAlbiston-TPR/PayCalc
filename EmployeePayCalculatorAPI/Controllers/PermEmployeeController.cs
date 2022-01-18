using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayCalc;

namespace EmployeePayCalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermEmployeeController : ControllerBase
    {
        private MockEmployeeRepository Perm;
        //private Calculator Calculator;

        public PermEmployeeController(IEmployeeRepository<PermantentEmployee> perm)
        {
            Perm = (MockEmployeeRepository)perm;
        }

        [HttpGet]
        public async Task<ActionResult<List<PermantentEmployee>>> Get()
        {
            return Ok(string.Concat(Perm.GetAll()));
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<PermantentEmployee>> Get(int Id)
        {
            var getOne = (string.Concat(Perm.GetEmployee(Id)));
            if (Perm.GetEmployee(Id) == null)
                return BadRequest("Employee not found");
            else
                return Ok(getOne);
        }
        [HttpPost]
        public async Task<ActionResult<PermantentEmployee>> PutNewStaff(int Id, string Name, ContractType Contract, decimal AnnualSalary, decimal AnnualBonus, int HoursWorked)
        {
            var response = (string.Concat(Perm.Create(Id, Name, Contract, AnnualSalary, AnnualBonus, HoursWorked)));
            if (response == null)
                return BadRequest("Employee not found");
            else
                return Ok(response);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<List<PermantentEmployee>>> Update(int Id, string Name, ContractType Contract, decimal AnnualSalary, decimal AnnualBonus, int HoursWorked)
        {
            var updatePerm = (string.Concat(Perm.Update(Id, Name, Contract, AnnualSalary, AnnualBonus, HoursWorked)));
            if (Perm.GetEmployee(Id) == null)
                return BadRequest("Employee not found");
            else
                return Ok(updatePerm);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<PermantentEmployee>> Delete(int Id)
        {
            var deletePerm = (string.Concat(Perm.Delete(Id)));
            if (Perm.GetEmployee(Id) == null)
                return BadRequest("Employee not found");
            else
                return Ok(deletePerm);
        }
    }
}
