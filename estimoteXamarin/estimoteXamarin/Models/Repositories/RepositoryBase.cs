using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace estimoteXamarin.Models
{
    public abstract class RepositoryBase
    {
        protected SQLiteAsyncConnection conn;

        public RepositoryBase()
        {
            conn = new SQLiteAsyncConnection(Helpers.Settings.DbPath);
        }
    }
}
