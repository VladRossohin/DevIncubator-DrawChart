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
    public class UserDataRepository : IRepository<UserData>
    {
        private ChartContext db;
        public void Create(UserData item)
        {
            db.UserData.Add(item);
        }

        public void Delete(int id)
        {
            UserData userData = db.UserData.Find(id);
            if (userData != null)
            {
                db.UserData.Remove(userData);
            }
        }

        public IEnumerable<UserData> Find(Func<UserData, Boolean> predicate)
        {
            return db.UserData.Where(predicate).ToList();
        }

        public UserData Get(int id)
        {
            return db.UserData.Find(id);
        }

        public IEnumerable<UserData> GetAll()
        {
            return db.UserData;
        }

        public void Update(UserData item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
