using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Dal.Entities;

namespace TaskManager.Repository.Services;

public class ToDoItemRepositoryEFCore// : IToDoItemRepository
{
    public Task<long> AddToDoItemAsync(ToDoItem toDoItem)
    {
        throw new NotImplementedException();
    }

    public Task DeleteToDoItemByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<ToDoItem>> SelectAllToDoItemsAsync(int skip, int take)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<ToDoItem>> SelectByDueDateToDoItemsAsync(DateTime dueDate)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<ToDoItem>> SelectCompletedToDoItemsAsync(short skip, short take)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<ToDoItem>> SelectIncompleteToDoItemsAsync(short skip, short take)
    {
        throw new NotImplementedException();
    }

    public Task<ToDoItem> SelectToDoItemByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateToDoItemAsync(ToDoItem toDoItem)
    {
        throw new NotImplementedException();
    }
}
