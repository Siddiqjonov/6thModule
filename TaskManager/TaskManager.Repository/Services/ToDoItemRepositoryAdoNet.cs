using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using TaskManager.Dal.Entities;
using TaskManager.Repository.Settings;

namespace TaskManager.Repository.Services;

public class ToDoItemRepositoryAdoNet : IToDoItemRepository
{
    private readonly string ConnectionString;

    public ToDoItemRepositoryAdoNet(SqlDBConnectionString sqlDBConnectionString)
    {
        ConnectionString = sqlDBConnectionString.ConnectionString;
    }

    public async Task<long> AddToDoItemAsync(ToDoItem toDoItem)
    {
        var sql = @"
                    insert into ToDoItems (Title, Description, IsCompleted, CreatedAt, DueDate)
                    output inserted.Id
                    values (@Title, @Description, @IsCompleted, @CreatedAt, @DueDate);";

        using (var conn = new SqlConnection(ConnectionString))
        {
            await conn.OpenAsync();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Title", toDoItem.Title);
                cmd.Parameters.AddWithValue("@Description", toDoItem.Description);
                cmd.Parameters.AddWithValue("@IsCompleted", toDoItem.IsCompleted);
                cmd.Parameters.AddWithValue("@CreatedAt", toDoItem.CreatedAt);
                cmd.Parameters.AddWithValue("@DueDate", toDoItem.DueDate);

                var res = (long)await cmd.ExecuteScalarAsync();

                await conn.CloseAsync();
                return res;
            }
        }
    }

    public async Task DeleteToDoItemByIdAsync(long id)
    {
        var sql = @"DELETE FROM TODOITEMS WHERE ID = @id";

        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            await conn.OpenAsync();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                await cmd.ExecuteNonQueryAsync();
            }
        }
    }

    //public async Task<ICollection<ToDoItem>> SelectAllToDoItemsAsync(int skip, int take)
    //{
    //    var sql = @"
    //        select Id, Title, Description, IsCompleted, CreatedAt, DueDate from ToDoItems;";

    //    var toDoItems = new List<ToDoItem>();

    //    using (SqlConnection conn = new SqlConnection(ConnectionString))
    //    {
    //        await conn.OpenAsync();
    //        using (SqlCommand cmd = new SqlCommand(sql, conn))
    //        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
    //        {
    //            while (await reader.ReadAsync())
    //            {
    //                toDoItems.Add(new ToDoItem()
    //                {
    //                    Id = reader.GetInt64(0),
    //                    Title = reader.GetString(1),
    //                    Description = reader.GetString(2),
    //                    IsCompleted = reader.GetBoolean(3),
    //                    CreatedAt = reader.GetDateTime(4),
    //                    DueDate = reader.GetDateTime(5),
    //                });
    //            }
    //        }
    //    }
    //    return toDoItems;
    //}

    public async Task<ICollection<ToDoItem>> SelectAllToDoItemsAsync(int skip, int take)
    {
        // --- Pagination added here ---
        var sql = @"
        SELECT Id, Title, Description, IsCompleted, CreatedAt, DueDate 
        FROM ToDoItems
        ORDER BY Id
        OFFSET @Skip ROWS
        FETCH NEXT @Take ROWS ONLY;";
        // --- End of pagination added ---

        var toDoItems = new List<ToDoItem>();

        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            await conn.OpenAsync();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                // --- Pagination parameters added here ---
                cmd.Parameters.AddWithValue("@Skip", skip);
                cmd.Parameters.AddWithValue("@Take", take);
                // --- End of pagination parameters added ---

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        toDoItems.Add(new ToDoItem()
                        {
                            Id = reader.GetInt64(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            IsCompleted = reader.GetBoolean(3),
                            CreatedAt = reader.GetDateTime(4),
                            DueDate = reader.GetDateTime(5),
                        });
                    }
                }
            }
        }

        return toDoItems;
    }


    public async Task<ICollection<ToDoItem>> SelectByDueDateToDoItemsAsync(DateTime dueDate)
    {
        var sql = @"
        SELECT Id, Title, Description, IsCompleted, CreatedAt, DueDate 
        FROM ToDoItems 
        WHERE CAST(DueDate AS DATE) = CAST(@DueDate AS DATE);";

        var toDoItems = new List<ToDoItem>();

        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            await conn.OpenAsync();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@DueDate", dueDate);

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        toDoItems.Add(new ToDoItem()
                        {
                            Id = reader.GetInt64(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            IsCompleted = reader.GetBoolean(3),
                            CreatedAt = reader.GetDateTime(4),
                            DueDate = reader.GetDateTime(5),
                        });
                    }
                }
            }
        }

        return toDoItems;
    }


    public async Task<ICollection<ToDoItem>> SelectCompletedToDoItemsAsync(int skip, int take)
    {
        var sql = @"
        SELECT Id, Title, Description, IsCompleted, CreatedAt, DueDate 
        FROM ToDoItems 
        WHERE IsCompleted = 1
        ORDER BY Id
        OFFSET @Skip ROWS
        FETCH NEXT @Take ROWS ONLY;";

        var toDoItems = new List<ToDoItem>();

        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            await conn.OpenAsync();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Skip", skip);
                cmd.Parameters.AddWithValue("@Take", take);

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        toDoItems.Add(new ToDoItem()
                        {
                            Id = reader.GetInt64(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            IsCompleted = reader.GetBoolean(3),
                            CreatedAt = reader.GetDateTime(4),
                            DueDate = reader.GetDateTime(5),
                        });
                    }
                }
            }
        }

        return toDoItems;
    }


    public async Task<ICollection<ToDoItem>> SelectIncompleteToDoItemsAsync(int skip, int take)
    {
        var sql = @"
        SELECT Id, Title, Description, IsCompleted, CreatedAt, DueDate 
        FROM ToDoItems 
        WHERE IsCompleted = 0
        ORDER BY Id
        OFFSET @Skip ROWS
        FETCH NEXT @Take ROWS ONLY;";

        var toDoItems = new List<ToDoItem>();

        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            await conn.OpenAsync();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Skip", skip);
                cmd.Parameters.AddWithValue("@Take", take);

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        toDoItems.Add(new ToDoItem()
                        {
                            Id = reader.GetInt64(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            IsCompleted = reader.GetBoolean(3),
                            CreatedAt = reader.GetDateTime(4),
                            DueDate = reader.GetDateTime(5),
                        });
                    }
                }
            }
        }

        return toDoItems;
    }


    public async Task<ToDoItem> SelectToDoItemByIdAsync(long id)
    {
        var sql = @"
                    SELECT Id, Title, Description, IsCompleted, CreatedAt, DueDate 
                    FROM ToDoItems where id = @id;";

        ToDoItem toDoItem = new();

        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            await conn.OpenAsync();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        toDoItem = new ToDoItem()
                        {
                            Id = reader.GetInt64(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            IsCompleted = reader.GetBoolean(3),
                            CreatedAt = reader.GetDateTime(4),
                            DueDate = reader.GetDateTime(5),
                        };
                    }
                }
            }
        }

        return toDoItem;
    }

    public async Task UpdateToDoItemAsync(ToDoItem toDoItem)
    {
        var sql = @"update ToDoItems
                    set Title = @Title, Description = @Description, IsCompleted = @IsCompleted, DueDate = @DueDate
                    where Id = @id;";

        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            await conn.OpenAsync();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", toDoItem.Id);
                cmd.Parameters.AddWithValue("@Title", toDoItem.Title);
                cmd.Parameters.AddWithValue("@Description", toDoItem.Description);
                cmd.Parameters.AddWithValue("@IsCompleted", toDoItem.IsCompleted);
                //cmd.Parameters.AddWithValue("@CreatedAt", toDoItem.CreatedAt);
                cmd.Parameters.AddWithValue("@DueDate", toDoItem.DueDate);

                await cmd.ExecuteNonQueryAsync();
            }
        }

    }
}
