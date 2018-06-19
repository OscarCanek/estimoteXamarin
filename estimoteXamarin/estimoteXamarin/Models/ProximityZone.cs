using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace estimoteXamarin.Models
{
    [Table("proximity_zone")]
    public class ProximityZone
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Distance { get; set; }

        [ForeignKey(typeof(Implementation))]
        public Guid ImplementationId { get; set; }

        [ManyToOne]
        public Implementation Implementation { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Sector> Sectors { get; set; }
    }
}
