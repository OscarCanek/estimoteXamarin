using SQLite;
using SQLiteNetExtensionsAsync.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace estimoteXamarin.Models
{
    public class ImplementationRepository : RepositoryBase
    {
        public ImplementationRepository()
        {
            conn = new SQLiteAsyncConnection(Helpers.Settings.DbPath);
        }

        public async Task ReplaceImplementation(Implementation implementation)
        {
            var implementations = await conn.GetAllWithChildrenAsync<Implementation>(recursive: true);

            foreach (var imp in implementations)
            {
                await conn.DeleteAsync(imp, recursive: true);
            }

            //var beacons = await conn.GetAllWithChildrenAsync<Beacon>(recursive: true);
            //await conn.DeleteAllAsync(beacons);

            //var sectors = await conn.GetAllWithChildrenAsync<Sector>(recursive: true);
            //await conn.DeleteAllAsync(sectors);

            //var zones = await conn.GetAllWithChildrenAsync<ProximityZone>(recursive: true);
            //await conn.DeleteAllAsync(zones);

            try
            {
                await conn.InsertWithChildrenAsync(implementation, recursive: true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public async Task DeleteImplementation()
        {
            var implementations = await conn.GetAllWithChildrenAsync<Implementation>(recursive: true);

            foreach (var imp in implementations)
            {
                await conn.DeleteAsync(imp, recursive: true);
            }
        }
    }
}
