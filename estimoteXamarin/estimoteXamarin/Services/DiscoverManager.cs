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
                            Distance = 0.5,
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
                                            Id = "360420bd6a13046cbee5e6db2195920c",
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
                            Distance = 1,
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
                                            Id = "724c51010637e1b51c40b9224cb8ed33",
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
                },
                new Implementation
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
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
                                    Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
                                    Name = "sec1",
                                    Beacons = new List<Beacon>
                                    {
                                        new Beacon
                                        {
                                            Id = "17",
                                            Uuid = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                                            Major = 17,
                                            Minor = 17
                                        },
                                        new Beacon
                                        {
                                            Id = "18",
                                            Uuid = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                                            Major = 18,
                                            Minor = 18
                                        }
                                    }
                                },
                                new Sector
                                {
                                    Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                                    Name = "sec1",
                                    Beacons = new List<Beacon>
                                    {
                                        new Beacon
                                        {
                                            Id = "19",
                                            Uuid = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                                            Major = 19,
                                            Minor = 19
                                        },
                                        new Beacon
                                        {
                                            Id = "20",
                                            Uuid = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                                            Major = 20,
                                            Minor = 20
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
                                    Id = Guid.Parse("00000000-0000-0000-0000-000000000011"),
                                    Name = "sec1",
                                    Beacons = new List<Beacon>
                                    {
                                        new Beacon
                                        {
                                            Id = "21",
                                            Uuid = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                                            Major = 21,
                                            Minor = 21
                                        },
                                        new Beacon
                                        {
                                            Id = "22",
                                            Uuid = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                                            Major = 22,
                                            Minor = 22
                                        }
                                    }
                                },
                                new Sector
                                {
                                    Id = Guid.Parse("00000000-0000-0000-0000-000000000012"),
                                    Name = "sec1",
                                    Beacons = new List<Beacon>
                                    {
                                        new Beacon
                                        {
                                            Id = "23",
                                            Uuid = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                                            Major = 23,
                                            Minor = 23
                                        },
                                        new Beacon
                                        {
                                            Id = "16",
                                            Uuid = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                                            Major = 24,
                                            Minor = 24
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
            if (beacon.Id == "6626459410d0d46140e928b6d2d8e014" || beacon.Id == "cfe7c3a1cdfadba8a249f75d6eae0634")
            {
                return Task.FromResult(this.implementations.SingleOrDefault(x => x.Id == Guid.Parse("00000000-0000-0000-0000-000000000001")));
            }
            else if (beacon.Id == "360420bd6a13046cbee5e6db2195920c" || beacon.Id == "724c51010637e1b51c40b9224cb8ed33")
            {
                return Task.FromResult(this.implementations.SingleOrDefault(x => x.Id == Guid.Parse("00000000-0000-0000-0000-000000000002")));
            }
            else
            {
                return Task.FromResult(this.implementations.SingleOrDefault(x => x.Id == Guid.Parse("00000000-0000-0000-0000-000000000003")));
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
            else if (beacon.Id == "cfe7c3a1cdfadba8a249f75d6eae0634")
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
