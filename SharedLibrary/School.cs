using System;
using SQLite;
namespace SharedLibrary
{
    [Table("School_tbl")]
    public class School
    {
        [Column("SchoolId"), PrimaryKey, AutoIncrement]
        public int SchoolId { get; }

        [Column("Name"), MaxLength(50)]
        public string Name { get; set; }


    }
}
