using Entekhab.Salary.Application.Common.Models;
using Entekhab.Salary.Application.SalaryCalculator.Models;
using MediatR;

namespace Entekhab.Salary.Application.SalaryCalculator.Queries.GetSalaryByDate;

public class GetSalaryByDateQuery: IRequest<List<SalaryDataDetailDto>>
{
    public DateTime FromDate { get; }
    public DateTime ToDate { get; }

    public GetSalaryByDateQuery(DateTime fromDate,DateTime toDate)
    {
        FromDate = fromDate;
        ToDate = toDate;
    }
}