using Entekhab.Salary.Application.Common.Mappings;
using Entekhab.Salary.Domain.Entities;

namespace Entekhab.Salary.Application.TodoItems.Queries.GetTodoItemsWithPagination;

public class TodoItemBriefDto : IMapFrom<TodoItem>
{
    public int Id { get; set; }

    public int ListId { get; set; }

    public string? Title { get; set; }

    public bool Done { get; set; }
}
