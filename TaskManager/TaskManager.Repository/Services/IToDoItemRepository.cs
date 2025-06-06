﻿using TaskManager.Dal.Entities;

namespace TaskManager.Repository.Services;

public interface IToDoItemRepository
{
    Task<long> AddToDoItemAsync(ToDoItem toDoItem);
    Task DeleteToDoItemByIdAsync(long id);
    Task UpdateToDoItemAsync(ToDoItem toDoItem);
    Task<ICollection<ToDoItem>> SelectAllToDoItemsAsync(int skip, int take);
    Task<ToDoItem> SelectToDoItemByIdAsync(long id);
    Task<ICollection<ToDoItem>> SelectByDueDateToDoItemsAsync(DateTime dueDate);
    Task<ICollection<ToDoItem>> SelectCompletedToDoItemsAsync(int skip, int take);
    Task<ICollection<ToDoItem>> SelectIncompleteToDoItemsAsync(int skip, int take);
}
