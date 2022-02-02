using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayCalc;
using PayCalc.Services;

namespace EmployeePayCalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermEmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository<PermanentEmployee> _perm;
        private readonly IPermCalculator _calc;
        public PermEmployeeController(IEmployeeRepository<PermanentEmployee> perm, IPermCalculator calc)
        {
            _perm = perm;
            _calc = calc;
        }

        [HttpGet]
        public async Task<ActionResult<List<PermanentEmployee>>> Get()
        {
            return Ok(_perm.GetAll());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<PermanentEmployee>> Get(int Id)
        {
            var getOne = (_perm.GetEmployee(Id));
            if (_perm.GetEmployee(Id) == null)
                return NotFound("Employee not found");
            else
                return Ok(getOne);
        }
        [HttpPost]
        public async Task<ActionResult<PermanentEmployee>> PostNewStaff(PermanentEmployee PermAdd)
        {
            PermAdd.TotalPay = _calc.TotalPay(PermAdd.AnnualSalary, PermAdd.AnnualBonus);
            PermAdd.HourlyPay = _calc.HourlyRate(PermAdd.AnnualSalary, PermAdd.HoursWorked);
            var response = _perm.Create(PermAdd);
            if (response == null)
                return NotFound("Employee not found");
            else
                return StatusCode(201,response);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<List<PermanentEmployee>>> Update(PermanentEmployee PermUpdate)
        {
            PermUpdate.TotalPay = _calc.TotalPay(PermUpdate.AnnualSalary, PermUpdate.AnnualBonus);
            PermUpdate.HourlyPay = _calc.HourlyRate(PermUpdate.AnnualSalary, PermUpdate.HoursWorked);
            var response = _perm.Update(PermUpdate);
            if (response == null)
                return NotFound("Employee not found");
            else
                return Ok(response);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<PermanentEmployee>> Delete(int Id)
        {
            if (_perm.GetEmployee(Id) == null)
                return NotFound("Employee not found");
            else
                _perm.Delete(Id);
            return NoContent();
        }
    }
}
