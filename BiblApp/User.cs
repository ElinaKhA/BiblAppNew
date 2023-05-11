using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiblApp
{
    [Table ("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Login { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Role { get; set; }
        public DateTime Birth{ get; set; }
        public string Password{ get; set;}

    }
}
