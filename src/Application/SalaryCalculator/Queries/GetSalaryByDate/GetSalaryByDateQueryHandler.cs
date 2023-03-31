using AutoMapper;
using AutoMapper.QueryableExtensions;
using Entekhab.Salary.Application.Common.Interfaces;
using Entekhab.Salary.Application.SalaryCalculator.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Entekhab.Salary.Application.SalaryCalculator.Queries.GetSalaryByDate;

public class GetSalaryByDateQueryHandler:IRequestHandler<GetSalaryByDateQuery, List<SalaryDataDetailDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSalaryByDateQueryHandler(IApplicationDbContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<SalaryDataDetailDto>> Handle(GetSalaryByDateQuery request, CancellationToken cancellationToken)
    {
        var items = await _context.SalaryData
            .Where(r => r.Date >= request.FromDate && r.Date <= request.ToDate)
            .AsNoTracking().ProjectTo<SalaryDataDetailDto>(_mapper.ConfigurationProvider).ToListAsync();
        return items;
    }
}