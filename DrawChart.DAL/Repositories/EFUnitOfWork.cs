using ChartDraw.DAL.EF;
using ChartDraw.DAL.Entities;
using ChartDraw.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartDraw.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ChartContext db;
        private PointRepository pointRepository;
        private UserDataRepository userDataRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = ChartContext.getInstance(connectionString);
        }

        public IRepository<Point> Points
        {
            get
            {
                if (pointRepository == null)
                    pointRepository = new PointRepository(db);
                return pointRepository;
            }
        }

        public IRepository<UserData> UserData
        {
            get
            {
                if (userDataRepository == null)
                    userDataRepository = new UserDataRepository();
                return userDataRepository;
            }
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if(disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
