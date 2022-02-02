using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayCalc;
using PayCalc.Services;

namespace EmployeePayCalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempEmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository<TempEmployee> _temp;
        private readonly ITempCalculator _calc;

        public TempEmployeeController(IEmployeeRepository<TempEmployee> temp, ITempCalculator calc)
        {
            _temp = temp;
            _calc = calc;
        }

        [HttpGet]
        public async Task<ActionResult<List<TempEmployee>>> Get()
        {
            return Ok(_temp.GetAll());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<TempEmployee>> Get(int Id)
        {
            var getOne = (_temp.GetEmployee(Id));
            if (_temp.GetEmployee(Id) == null)
                return NotFound("Employee not found");
            else
                return Ok(getOne);
        }
        [HttpPost]
        public async Task<ActionResult<TempEmployee>> PostNewStaff(TempEmployee TempAdd)
        {
            TempAdd.TotalPay = _calc.TotalPay(TempAdd.WeeksWorked, TempAdd.DayRate);
            TempAdd.HourlyPay = _calc.HourlyRate(TempAdd.DayRate);
            var response = _temp.Create(TempAdd);
            if (response == null)
                return NotFound("Employee not found");
            else
                return StatusCode(201, response);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<List<TempEmployee>>> Update(TempEmployee TempUpdate)
        {
            TempUpdate.TotalPay = _calc.TotalPay(TempUpdate.WeeksWorked, TempUpdate.DayRate);
            TempUpdate.HourlyPay = _calc.HourlyRate(TempUpdate.DayRate);
            var response = _temp.Update(TempUpdate);
            if (response == null)
                return NotFound("Employee not found");
            else
                return Ok(response);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<TempEmployee>> Delete(int Id)
        {
            if (_temp.GetEmployee(Id) == null)
                return NotFound("Employee not found");
            else
                _temp.Delete(Id);
            return NoContent();
        }
    }
}
