using Entekhab.Salary.Application.SalaryCalculator.Models;
using MediatR;

namespace Entekhab.Salary.Application.SalaryCalculator.Queries.GetSalaryByPersonId;

public class GetSalaryByPersonIdQuery: IRequest<List<SalaryDataDetailDto>>
{
    public int PersonId { get; }

    public GetSalaryByPersonIdQuery(int personId)
    {
        PersonId = personId;
    }
}