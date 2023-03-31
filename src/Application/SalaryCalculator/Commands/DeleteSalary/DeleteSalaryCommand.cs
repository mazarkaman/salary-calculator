using MediatR;

namespace Entekhab.Salary.Application.SalaryCalculator.Commands.DeleteSalary;

public class DeleteSalaryCommand: IRequest
{
    public int ItemId { get; }

    public DeleteSalaryCommand(int itemId)
    {
        ItemId = itemId;
    }
}