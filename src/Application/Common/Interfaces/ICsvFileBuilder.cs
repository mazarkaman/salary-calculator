using Entekhab.Salary.Application.TodoLists.Queries.ExportTodos;

namespace Entekhab.Salary.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
