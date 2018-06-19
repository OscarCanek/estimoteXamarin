using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace estimoteXamarin.Models
{
    [Table("implementation")]
    public class Implementation
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string LogoUrl { get; set; }
        public string ColorHex { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<ProximityZone> ProximityZones { get; set; }
    }
}
