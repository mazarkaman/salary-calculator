using Entekhab.Salary.Application.SalaryCalculator.Commands.CreateSalaryByCustom;
using Entekhab.Salary.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using static Entekhab.Salary.Application.IntegrationTests.Testing;

namespace Entekhab.Salary.Application.IntegrationTests.Salary.Commands;

public class CreateSalaryByCustomTest:BaseTestFixture
{
    [Test]
    public async Task ShouldCreateItem()
    {
        const string input = "PersonId/FirstName/LastName/BasicSalary/Allowance/Transportation/Date\n1/Ali/Ahmadi/1200000/400000/350000/14010801\n100/Reza/Rezaee/100000/300000/150000/14010801";
        var command = new CreateSalaryByCustomCommand(input, CalculatorType.TypeA);
        var result = await SendAsync(command);
        result.Count.Should().Be(2);
    }
    
}