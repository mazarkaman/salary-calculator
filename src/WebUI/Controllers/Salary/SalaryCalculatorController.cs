using Entekhab.Salary.Application.SalaryCalculator.Commands.CreateSalaryByCustom;
using Entekhab.Salary.Application.SalaryCalculator.Commands.CreateSalaryByJson;
using Entekhab.Salary.Application.SalaryCalculator.Commands.DeleteSalary;
using Entekhab.Salary.Application.SalaryCalculator.Commands.UpdateSalary;
using Entekhab.Salary.Application.SalaryCalculator.Queries.GetSalaryByDate;
using Entekhab.Salary.Application.SalaryCalculator.Queries.GetSalaryByPersonId;
using Entekhab.Salary.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;
using WebUI.Controllers.Salary.Models;

namespace WebUI.Controllers.Salary;

public class SalaryCalculatorController : ApiControllerBase
{
    [HttpPost("json")]
    public async Task<IActionResult> AddJson([FromBody]AddSalaryRequest request)
    {
        var command = new CreateSalaryByJsonCommand(request.SalaryData, request.OverTimeCalculator);
        var result = await Mediator.Send(command);
        return Created("", result);
    }
    
    [HttpPost("custom")]
    public async Task<IActionResult> AddCustom([FromBody]AddCustomSalaryRequest request)
    {
        var command = new CreateSalaryByCustomCommand(request.SalaryData, request.OverTimeCalculator);
        var result = await Mediator.Send(command);
        return Created("", result);
    }
    
    [HttpPut("{itemId:int}")]
    public async Task<IActionResult> Update([FromRoute]int itemId, UpdateSalaryRequest request)
    {
        var command = new UpdateSalaryCommand(itemId,request.SalaryData,request.OverTimeCalculator);
        var result = await Mediator.Send(command);
        return Ok(result);
    }
    
    
    [HttpDelete("{itemId:int}")]
    public async Task<IActionResult> Delete([FromRoute]int itemId)
    {
        var command = new DeleteSalaryCommand(itemId);
        var result = await Mediator.Send(command);
        return NoContent();
    }
    
    [HttpGet("{personId:int}")]
    public async Task<IActionResult> Get([FromRoute]int personId)
    {
        var command = new GetSalaryByPersonIdQuery(personId);
        var result = await Mediator.Send(command);
        return Ok(result);
    }
    
    [HttpGet("range")]
    public async Task<IActionResult> Get([FromQuery]DateTime fromDate,[FromQuery]DateTime toDate)
    {
        var command = new GetSalaryByDateQuery(fromDate, toDate);
        var result = await Mediator.Send(command);
        return Ok(result);
    }
}