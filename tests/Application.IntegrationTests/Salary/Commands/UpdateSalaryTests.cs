using Entekhab.Salary.Application.SalaryCalculator.Commands.CreateSalaryByJson;
using Entekhab.Salary.Application.SalaryCalculator.Commands.UpdateSalary;
using Entekhab.Salary.Application.SalaryCalculator.Models;
using Entekhab.Salary.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace Entekhab.Salary.Application.IntegrationTests.Salary.Commands;
using static Entekhab.Salary.Application.IntegrationTests.Testing;

public class UpdateSalaryTest:BaseTestFixture
{
    [Test]
    public async Task ShouldUpdate()
    {
        var command = new CreateSalaryByJsonCommand(
            new SalaryDataDto()
            {
                Allowance = 100,
                Date = "14010101",
                Transportation = 100,
                BasicSalary = 100,
                FirstName = "Sadegh",
                LastName = "Azarkaman",
                PersonId = 1
            }, CalculatorType.TypeA);
        var result = await SendAsync(command);
        var updateCommand = new UpdateSalaryCommand(result,
            new SalaryDataDto()
            {
                Allowance = 100,
                Date = "14010101",
                Transportation = 100,
                BasicSalary = 100,
                FirstName = "Sadegh",
                LastName = "EDITED",
                PersonId = 1
            }, CalculatorType.TypeA);
        result = await SendAsync(updateCommand);
        var updatedItem = await FindAsync<SalaryData>(result);
        updatedItem?.LastName.Should().Be("EDITED");
    }
}