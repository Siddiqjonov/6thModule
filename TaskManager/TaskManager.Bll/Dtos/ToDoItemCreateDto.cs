﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Bll.Dtos;

public class ToDoItemCreateDto
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public DateTime DueDate { get; set; }
}
