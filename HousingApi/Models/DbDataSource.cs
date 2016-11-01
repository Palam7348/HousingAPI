using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingApi.Models
{
    public class DbDataSource
    {
        private static DatabaseContext db = null;


        public static DatabaseContext All
        {
            get
            {
                if (db==null)
                {
                    db = new DatabaseContext();
                }
                return db;
            }
        }
    }
}
