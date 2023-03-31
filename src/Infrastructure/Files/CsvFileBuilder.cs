using System.Globalization;
using Entekhab.Salary.Application.Common.Interfaces;
using Entekhab.Salary.Application.TodoLists.Queries.ExportTodos;
using Entekhab.Salary.Infrastructure.Files.Maps;
using CsvHelper;

namespace Entekhab.Salary.Infrastructure.Files;

public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Context.RegisterClassMap<TodoItemRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}
