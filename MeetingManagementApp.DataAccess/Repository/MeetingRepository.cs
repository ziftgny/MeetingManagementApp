using MeetingManagementApp.DataAccess.Data;
using MeetingManagementApp.DataAccess.Repository.IRepository;
using MeetingManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MeetingManagementApp.DataAccess.Repository
{
    public class MeetingRepository : Repository<Meeting>,IMeetingRepository
    {
        private ApplicationDbContext _db;
        public MeetingRepository(ApplicationDbContext db) : base(db)
        {
            _db= db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Meeting obj)
        {
            _db.Meetings.Update(obj);
        }
    }
}
