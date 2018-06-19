using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace estimoteXamarin.Models
{
    [Table("beacon")]
    public class Beacon
    {
        [PrimaryKey]
        public string Id { get; set; }
        public Guid Uuid { get; set; }
        public int Major { get; set; }
        public int Minor { get; set; }

        [ForeignKey(typeof(Sector))]
        public Guid SectorId { get; set; }

        [ManyToOne]
        public Sector Sector { get; set; }
    }
}
