﻿using Dynamic.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace Dynamic.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
