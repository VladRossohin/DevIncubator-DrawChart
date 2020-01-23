using ChartDraw.DAL.EF;
using ChartDraw.DAL.Entities;
using ChartDraw.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartDraw.DAL.Repositories
{
    class PointRepository : IRepository<Point>
    {
        private ChartContext db;
        public PointRepository(ChartContext context)
        {
            this.db = context;
        }

        public void Create(Point point)
        {
            db.Points.Add(point);
        }

        public void Delete(int id)
        {
            Point point = db.Points.Find(id);
            if (point != null)
            {
                db.Points.Remove(point);
            }
        }

        public IEnumerable<Point> Find(Func<Point, Boolean> predicate)
        {
            return db.Points.Include(o => o.UserData).Where(predicate).ToList();
        }

        public Point Get(int id)
        {
            return db.Points.Find(id);
        }

        public IEnumerable<Point> GetAll()
        {
            return db.Points.Include(o => o.UserData);
        }

        public void Update(Point point)
        {
            db.Entry(point).State = EntityState.Modified;
        }
    }
}
