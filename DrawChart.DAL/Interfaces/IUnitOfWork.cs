using ChartDraw.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartDraw.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Point> Points { get; }
        IRepository<UserData> UserData { get; }
        void Save();
    }
}
