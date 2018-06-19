using estimoteXamarin.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace estimoteXamarin.Services
{
    public class DiscoverManager
    {
        private readonly List<Implementation> implementations;

        public DiscoverManager()
        {
            implementations = new List<Implementation> {
                new Implementation
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    ColorHex = "#ff3300",
                    LogoUrl = "https://www.pinterest.es/pin/268456827762654782/",
                    ProximityZones = new List<ProximityZone>
                    {
                        new ProximityZone
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                            Name = "zone1",
                            Distance = 0.5,
                            Sectors = new List<Sector>
                            {
                                new Sector
                                {
                                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                                    Name = "sec1",
                                    Beacons = new List<Beacon>
                                    {
                                        new Beacon
                                        {
                                            Id = "6626459410d0d46140e928b6d2d8e014",
                                            Uuid = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                                            Major = 1,
                                            Minor = 1
                                        },
                                        new Beacon
                                        {
                                            Id = "2",
                                            Uuid = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                                            Major = 2,
                                            Minor = 2
                                        }
                                    }
                                },
                                new Sector
                                {
                                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                                    Name = "sec1",
                                    Beacons = new List<Beacon>
                                    {
                                        new Beacon
                                        {
                                            Id = "3",
                                            Uuid = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                                            Major = 3,
                                            Minor = 3
                                        },
                                        new Beacon
                                        {
                                            Id = "4",
                                            Uuid = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                                            Major = 4,
                                            Minor = 4
                                        }
                                    }
                                }
                            }
                        },
                        new ProximityZone
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                            Name = "zone1",
                            Distance = 1,
                            Sectors = new List<Sector>
                            {
                                new Sector
                                {
                                    Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                                    Name = "sec1",
                                    Beacons = new List<Beacon>
                                    {
                                        new Beacon
                                        {
                                            Id = "cfe7c3a1cdfadba8a249f75d6eae0634",
                                            Uuid = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                                            Major = 5,
                                            Minor = 5
                                        },
                                        new Beacon
                                        {
                                            Id = "6",
                                            Uuid = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                                            Major = 6,
                                            Minor = 6
                                        }
                                    }
                                },
                                new Sector
                                {
                                    Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                                    Name = "sec1",
                                    Beacons = new List<Beacon>
                                    {
                                        new Beacon
                                        {
                                            Id = "7",
                                            Uuid = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                                            Major = 7,
                                            Minor = 7
                                        },
                                        new Beacon
                                        {
                                            Id = "8",
                                            Uuid = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                                            Major = 8,
                                            Minor = 8
                                        }
                                    }
                                }
                            }
                        }
                    }
                },
                new Implementation
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    ColorHex = "#ff3300",
                    LogoUrl = "https://www.pinterest.es/pin/268456827762654782/",
                    ProximityZones = new List<ProximityZone>
                    {
                        new ProximityZone
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                            Name = "zone1",
                            Distance = 0.2,
                            Sectors = new List<Sector>
                            {
                                new Sector
                                {
                                    Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                                    Name = "sec1",
                                    Beacons = new List<Beacon>
                                    {
                                        new Beacon
                                        {
                                            Id = "9",
                                            Uuid = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                                            Major = 9,
                                            Minor = 9
                                        },
                                        new Beacon
                                        {
                                            Id = "10",
                                            Uuid = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                                            Major = 10,
                                            Minor = 10
                                        }
                                    }
                                },
                                new Sector
                                {
                                    Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                                    Name = "sec1",
                                    Beacons = new List<Beacon>
                                    {
                                        new Beacon
                                        {
                                            Id = "11",
                                            Uuid = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                                            Major = 11,
                                            Minor = 11
                                        },
                                        new Beacon
                                        {
                                            Id = "12",
                                            Uuid = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                                            Major = 12,
                                            Minor = 12
                                        }
                                    }
                                }
                            }
                        },
                        new ProximityZone
                        {
                            Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                            Name = "zone1",
                            Distance = 0.2,
                            Sectors = new List<Sector>
                            {
                                new Sector
                                {
                                    Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
                                    Name = "sec1",
                                    Beacons = new List<Beacon>
                                    {
                                        new Beacon
                                        {
                                            Id = "13",
                                            Uuid = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                                            Major = 13,
                                            Minor = 13
                                        },
                                        new Beacon
                                        {
                                            Id = "14",
                                            Uuid = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                                            Major = 14,
                                            Minor = 14
                                        }
                                    }
                                },
                                new Sector
                                {
                                    Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
                                    Name = "sec1",
                                    Beacons = new List<Beacon>
                                    {
                                        new Beacon
                                        {
                                            Id = "15",
                                            Uuid = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                                            Major = 15,
                                            Minor = 15
                                        },
                                        new Beacon
                                        {
                                            Id = "16",
                                            Uuid = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                                            Major = 16,
                                            Minor = 16
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }

        public Task<Implementation> GetImplementation(Beacon beacon)
        {
            if(beacon.Id == "6626459410d0d46140e928b6d2d8e014" || beacon.Id == "cfe7c3a1cdfadba8a249f75d6eae0634")
            {
                return Task.FromResult(this.implementations.SingleOrDefault(x => x.Id == Guid.Parse("00000000-0000-0000-0000-000000000001")));
            }
            else
            {
                return Task.FromResult(this.implementations.SingleOrDefault(x => x.Id == Guid.Parse("00000000-0000-0000-0000-000000000002")));
            }
        }

        public Task<List<DiscoverListElement>> GetElements(Beacon beacon)
        {
            if (beacon.Id == "6626459410d0d46140e928b6d2d8e014")
            {
                return Task.FromResult(new List<DiscoverListElement>
                {
                    new DiscoverListElement
                    {
                        Title = "Pauta beacon blanco",
                        Message = "Prueba",
                        ImageUrl = "https://ritchyzz.deviantart.com/art/Logo-Necro-lic-Visage-Dota-2-689627519"
                    }
                });
            }
            else if(beacon.Id == "cfe7c3a1cdfadba8a249f75d6eae0634")
            {
                return Task.FromResult(new List<DiscoverListElement>
                {
                    new DiscoverListElement
                    {
                        Title = "Pauta beacon morado",
                        Message = "Prueba",
                        ImageUrl = "https://ritchyzz.deviantart.com/art/Logo-Roshan-Dota-2-693313732"
                    }
                });
            }
            else
            {
                return Task.FromResult(new List<DiscoverListElement>
                {
                    new DiscoverListElement
                    {
                        Title = "Pauta sin beacon",
                        Message = "Prueba",
                        ImageUrl = "https://ritchyzz.deviantart.com/gallery/63132301/DOTA-2-FLAT-ART"
                    }
                });
            }
        }
    }
}
