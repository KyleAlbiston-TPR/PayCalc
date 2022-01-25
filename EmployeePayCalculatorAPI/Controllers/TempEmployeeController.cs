using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayCalc;

namespace EmployeePayCalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempEmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository<TempEmployee> Temp;

        public TempEmployeeController(IEmployeeRepository<TempEmployee> temp)
        {
            Temp = temp;
        }

        [HttpGet]
        public async Task<ActionResult<List<TempEmployee>>> Get()
        {
            return Ok(Temp.GetAll());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<TempEmployee>> Get(int Id)
        {
            var getOne = (Temp.GetEmployee(Id));
            if (Temp.GetEmployee(Id) == null)
                return BadRequest("Employee not found");
            else
                return Ok(getOne);
        }
        [HttpPost]
        public async Task<ActionResult<TempEmployee>> PostNewStaff(TempEmployee TempAdd)
        {
            var response = Temp.Create(TempAdd);
            if (response == null)
                return BadRequest("Employee not found");
            else
                return Ok(response);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<List<TempEmployee>>> Update(TempEmployee TempUpdate)
        {
            var response = Temp.Update(TempUpdate);
            if (response == null)
                return BadRequest("Employee not found");
            else
                return Ok(response);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<TempEmployee>> Delete(int Id)
        {
            var deleteTemp = (Temp.Delete(Id));
            if (Temp.GetEmployee(Id) == null)
                return BadRequest("Employee not found");
            else
                return Ok(deleteTemp);
        }
    }
}
