using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiblApp
{
    [Table ("Books")]
    public class Book
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Author { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }

    }
}
