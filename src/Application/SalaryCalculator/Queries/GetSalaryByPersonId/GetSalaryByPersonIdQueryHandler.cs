using AutoMapper;
using AutoMapper.QueryableExtensions;
using Entekhab.Salary.Application.Common.Interfaces;
using Entekhab.Salary.Application.SalaryCalculator.Models;
using Entekhab.Salary.Application.SalaryCalculator.Queries.GetSalaryByDate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Entekhab.Salary.Application.SalaryCalculator.Queries.GetSalaryByPersonId;

public class GetSalaryByPersonIdQueryHandler:IRequestHandler<GetSalaryByPersonIdQuery, List<SalaryDataDetailDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSalaryByPersonIdQueryHandler(IApplicationDbContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<SalaryDataDetailDto>> Handle(GetSalaryByPersonIdQuery request, CancellationToken cancellationToken)
    {
        var item = await _context.SalaryData
            .Where(r => r.PersonId == request.PersonId)
            .AsNoTracking().ProjectTo<SalaryDataDetailDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken: cancellationToken);
        return item; 
    }
}