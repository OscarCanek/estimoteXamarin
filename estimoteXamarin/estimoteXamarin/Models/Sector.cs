using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace estimoteXamarin.Models
{
    [Table("Sector")]
    public class Sector
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Name { get; set; }

        [ForeignKey(typeof(ProximityZone))]
        public Guid ProximityZoneId { get; set; }

        [ManyToOne]
        public ProximityZone ProximityZone { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Beacon> Beacons { get; set; }
    }
}
