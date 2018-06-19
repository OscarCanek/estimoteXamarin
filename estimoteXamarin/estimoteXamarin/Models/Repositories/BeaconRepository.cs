using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estimoteXamarin.Models
{
    public class BeaconRepository : RepositoryBase
    {
        private List<Sector> sectors = new List<Sector>();

        public BeaconRepository() : base()
        {
            conn = new SQLiteAsyncConnection(Helpers.Settings.DbPath);
        }

        public async Task<Sector> GetSector(string id)
        {
            // se debe consultar a la base de datos el sector al que pertenece el beacon
            var beacon = await conn.Table<Beacon>()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (beacon == null)
            {
                return null;
            }

            return await conn.Table<Sector>().Where(x => x.Id == beacon.SectorId).FirstOrDefaultAsync();
        }

        internal async Task<Implementation> GetImplementation(string deviceId)
        {
            var b = await conn.Table<Beacon>().ToListAsync();

            // obtener la implementación a la que pertenece el sector
            var beacon = await conn.Table<Beacon>()
                .Where(x => x.Id == deviceId)
                .FirstOrDefaultAsync();

            if (beacon == null)
            {
                return null;
            }

            var sector = await conn.Table<Sector>().Where(x => x.Id == beacon.SectorId).FirstOrDefaultAsync();

            if (sector == null)
            {
                return null;
            }

            var zone = await conn.Table<ProximityZone>()
                .Where(x => x.Id == sector.ProximityZoneId)
                .FirstOrDefaultAsync();

            if (zone == null)
            {
                return null;
            }

            return await conn.Table<Implementation>()
                .Where(x => x.Id == zone.ImplementationId)
                .FirstOrDefaultAsync();
        }
    }
}
