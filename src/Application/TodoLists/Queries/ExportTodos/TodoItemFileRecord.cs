using Entekhab.Salary.Application.Common.Mappings;
using Entekhab.Salary.Domain.Entities;

namespace Entekhab.Salary.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
