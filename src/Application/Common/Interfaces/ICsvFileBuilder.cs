using newnew.Application.TodoLists.Queries.ExportTodos;

namespace newnew.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
