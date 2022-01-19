using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayCalc;

namespace EmployeePayCalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempEmployeeController : ControllerBase
    {
        private TempEmployeeRepository Temp;
        //private Calculator Calculator;

        public TempEmployeeController(IEmployeeRepository<TempEmployee> temp)
        {
            Temp = (TempEmployeeRepository)temp;
        }

        [HttpGet]
        public async Task<ActionResult<List<TempEmployee>>> Get()
        {
            return Ok(string.Concat(Temp.GetAll()));
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<TempEmployee>> Get(int Id)
        {
            var getOne = (string.Concat(Temp.GetEmployee(Id)));
            if (Temp.GetEmployee(Id) == null)
                return BadRequest("Employee not found");
            else
                return Ok(getOne);
        }
        [HttpPost]
        public async Task<ActionResult<TempEmployee>> PutNewStaff(int Id, string Name, ContractType Contract, int WeeksWorked, decimal DayRate)
        {
            var response = (string.Concat(Temp.Create(Id, Name, Contract, WeeksWorked, DayRate)));
            if (response == null)
                return BadRequest("Employee not found");
            else
                return Ok(response);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<List<TempEmployee>>> Update(int Id, string Name, ContractType Contract, int WeeksWorked, decimal DayRate)
        {
            var updateTemp = (string.Concat(Temp.Update(Id, Name, Contract, WeeksWorked, DayRate)));
            if (Temp.GetEmployee(Id) == null)
                return BadRequest("Employee not found");
            else
                return Ok(updateTemp);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<TempEmployee>> Delete(int Id)
        {
            var deleteTemp = (string.Concat(Temp.Delete(Id)));
            if (Temp.GetEmployee(Id) == null)
                return BadRequest("Employee not found");
            else
                return Ok(deleteTemp);
        }
    }
}
