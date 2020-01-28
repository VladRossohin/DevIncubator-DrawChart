using ChartDraw.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartDraw.DAL.EF
{
    public class ChartContext : DbContext
    {
        public DbSet<Point> Points { get; set; }
        public DbSet<UserData> UserData { get; set; }
        // singleton
        private static ChartContext instance;

        static ChartContext()
        {
            Database.SetInitializer<ChartContext>(new StoreDbInitializer());
        }

        public static ChartContext getInstance(string connectionString)
        {
            if (instance == null)
                instance = new ChartContext(connectionString);
            return instance;
        }

        private ChartContext(string connectionString) : base(connectionString)
        {

        }

        
    }

    public class StoreDbInitializer : CreateDatabaseIfNotExists<ChartContext>
    {

    }
}
