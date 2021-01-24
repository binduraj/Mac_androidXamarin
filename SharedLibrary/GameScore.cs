using System;
using SQLite;

namespace SharedLibrary
{
    [Table("GameScore")]
    public class GameScore
    {
        [PrimaryKey, AutoIncrement,Column("Id")]
        public int Id { get; set; }

        [MaxLength(10)]
        public string Name { get; set; }

        public int Score { get; set; }
    }
}
