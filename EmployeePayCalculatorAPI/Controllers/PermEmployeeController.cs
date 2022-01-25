using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayCalc;

namespace EmployeePayCalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermEmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository<PermanentEmployee> Perm;
        private readonly ICalculator<PermanentEmployee> Calculator;
        public PermEmployeeController(IEmployeeRepository<PermanentEmployee> perm, ICalculator<PermanentEmployee> calc)
        {
            Perm = perm;
            Calculator = calc;
        }

        [HttpGet]
        public async Task<ActionResult<List<PermanentEmployee>>> Get()
        {
            return Ok(Perm.GetAll());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<PermanentEmployee>> Get(int Id)
        {
            var getOne = (Perm.GetEmployee(Id));
            if (Perm.GetEmployee(Id) == null)
                return BadRequest("Employee not found");
            else
                return Ok(getOne);
        }
        [HttpPost]
        public async Task<ActionResult<PermanentEmployee>> PostNewStaff(PermanentEmployee PermAdd)
        {
            var response = Perm.Create(PermAdd);
            if (response == null)
                return BadRequest("Employee not found");
            else
                return StatusCode(201, response);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<List<PermanentEmployee>>> Update(PermanentEmployee PermUpdate)
        {
            var response = Perm.Update(PermUpdate);
            if (response == null)
                return BadRequest("Employee not found");
            else
                return Ok(response);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<PermanentEmployee>> Delete(int Id)
        {
            if (Perm.GetEmployee(Id) == null)
                return BadRequest("Employee not found");
            else
                Perm.Delete(Id);
            return NoContent();
        }
        [HttpPost("{Id}")]
        public async Task<ActionResult<PermanentEmployee>> TotalPay(int Id, decimal AnnualSalary, decimal AnnualBonus) 
            //not working as intended but is a start of something, still messing around with anything to do with calc
        {
            var total = Calculator.PermTotalPay(AnnualSalary, AnnualBonus);
            if (Perm.GetEmployee(Id) == null)
                return BadRequest("Employee not found");
            else       
            return Ok(total);
                
        }
    }
}
