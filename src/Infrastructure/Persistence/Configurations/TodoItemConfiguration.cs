using Entekhab.Salary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entekhab.Salary.Infrastructure.Persistence.Configurations;

public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        builder.Property(t => t.Title)
            .HasMaxLength(200)
            .IsRequired();
    }
}
