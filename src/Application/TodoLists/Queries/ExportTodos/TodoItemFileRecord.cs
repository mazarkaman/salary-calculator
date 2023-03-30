using newnew.Application.Common.Mappings;
using newnew.Domain.Entities;

namespace newnew.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
