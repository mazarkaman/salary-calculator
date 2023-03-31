using Entekhab.Salary.Application.SalaryCalculator.Commands.CreateSalaryByCustom;
using Entekhab.Salary.Application.SalaryCalculator.Commands.CreateSalaryByJson;
using Entekhab.Salary.Application.SalaryCalculator.Commands.DeleteSalary;
using Entekhab.Salary.Application.SalaryCalculator.Commands.UpdateSalary;
using Entekhab.Salary.Application.SalaryCalculator.Models;
using Entekhab.Salary.Application.SalaryCalculator.Queries.GetSalaryByDate;
using Entekhab.Salary.Application.SalaryCalculator.Queries.GetSalaryByPersonId;
using Entekhab.Salary.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;
using WebUI.Controllers.Salary.Models;

namespace WebUI.Controllers.Salary;

[ApiController]
[Route("[controller]")]
public class SalaryCalculatorController : ApiControllerBase
{
    
    /// <summary>
    /// Adds a new salary record using JSON data.
    /// </summary>
    /// <param name="request">The request containing the salary data and overtime calculator.</param>
    /// <returns>The newly created salary record.</returns>
    [HttpPost("json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<SalaryDataDto>> AddJson([FromBody] AddSalaryRequest request)
    {
        var command = new CreateSalaryByJsonCommand(request.SalaryData, request.OverTimeCalculator);
        var result = await Mediator.Send(command);
        return Created("", result);
    }

    /// <summary>
    /// Adds a new salary record using custom data.
    /// </summary>
    /// <param name="request">The request containing the salary data and overtime calculator.</param>
    /// <returns>The newly created salary record.</returns>
    [HttpPost("custom")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<SalaryDataDto>> AddCustom([FromBody] AddCustomSalaryRequest request)
    {
        var command = new CreateSalaryByCustomCommand(request.SalaryData, request.OverTimeCalculator);
        var result = await Mediator.Send(command);
        return Created("", result);
    }

    /// <summary>
    /// Updates an existing salary record.
    /// </summary>
    /// <param name="itemId">The ID of the salary record to update.</param>
    /// <param name="request">The request containing the updated salary data and overtime calculator.</param>
    /// <returns>The updated salary record.</returns>
    [HttpPut("{itemId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SalaryDataDto>> Update([FromRoute] int itemId, [FromBody] UpdateSalaryRequest request)
    {
        var command = new UpdateSalaryCommand(itemId, request.SalaryData, request.OverTimeCalculator);
        var result = await Mediator.Send(command);
        return Ok(result);
    }

    /// <summary>
    /// Deletes an existing salary record.
    /// </summary>
    /// <param name="itemId">The ID of the salary record to delete.</param>
    /// <returns>No content response.</returns>
    [HttpDelete("{itemId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete([FromRoute] int itemId)
    {
        var command = new DeleteSalaryCommand(itemId);
        await Mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    /// Gets the salary record for a specific person.
    /// </summary>
    /// <param name="personId">The ID of the person whose salary record is requested.</param>
    /// <returns>The salary record for the specified person.</returns>
    [HttpGet("{personId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SalaryDataDto>> Get([FromRoute] int personId)
    {
        var query = new GetSalaryByPersonIdQuery(personId);
        var result = await Mediator.Send(query);
        return Ok(result);
    }

    /// <summary>
    /// Gets the salary records for a range of dates.
    /// </summary>
    /// <param name="fromDate">The start date of the range.</param>
    /// <param name="toDate">The end date of the range.</param>
    /// <returns>The salary records for the specified date range.</returns>
    [HttpGet("range")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<SalaryDataDto>>> Get([FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
    {
        var query = new GetSalaryByDateQuery(fromDate, toDate);
        var result = await Mediator.Send(query);
        return Ok(result);
    }
}
