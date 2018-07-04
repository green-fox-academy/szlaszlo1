﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Models
{
    public class Todos
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool IsUrgent { get; set; }
        public bool IsDone { get; set; }
    }
}
