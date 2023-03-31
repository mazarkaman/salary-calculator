using Entekhab.Salary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Entekhab.Salary.Infrastructure.Persistence.Configurations;

public class SalaryItemsConfiguration: IEntityTypeConfiguration<SalaryData>
{
    public void Configure(EntityTypeBuilder<SalaryData> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(r => r.OverTimeCalculatorType).HasConversion(new EnumToStringConverter<CalculatorType>());
    }
}