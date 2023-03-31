using Entekhab.Salary.Application.SalaryCalculator.Commands.CreateSalaryByJson;
using Entekhab.Salary.Application.SalaryCalculator.Commands.DeleteSalary;
using Entekhab.Salary.Application.SalaryCalculator.Models;
using Entekhab.Salary.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using static Entekhab.Salary.Application.IntegrationTests.Testing;

namespace Entekhab.Salary.Application.IntegrationTests.Salary.Commands;

public class DeleteSalaryTests:BaseTestFixture
{
    [Test]
    public async Task ShouldDelete()
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
        var item = await SendAsync(command);
        var delete = new DeleteSalaryCommand(item);
        await SendAsync(delete);
        var deletedItem = await FindAsync<SalaryData>(item);
        deletedItem.Should().BeNull();
    }
}