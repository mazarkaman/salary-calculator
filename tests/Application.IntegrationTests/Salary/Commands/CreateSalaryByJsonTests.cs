using Entekhab.Salary.Application.SalaryCalculator.Commands.CreateSalaryByCustom;
using Entekhab.Salary.Application.SalaryCalculator.Commands.CreateSalaryByJson;
using Entekhab.Salary.Application.SalaryCalculator.Models;
using Entekhab.Salary.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using static Entekhab.Salary.Application.IntegrationTests.Testing;

namespace Entekhab.Salary.Application.IntegrationTests.Salary.Commands;

public class TestCreateSalaryByCustomCommand:BaseTestFixture
{
    [Test]
    public async Task ShouldCreateItem()
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
        result.Should().BePositive();
    }
}