﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MustDoX
{
    class Task
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }

        public string Name { get; set; }

        public string Info { get; set; }
    }
}
