using Leave_Management.Contracts;
using Leave_Management.Data;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Leave_Management.Repository
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        public bool Create(LeaveType entity)
        {
            _db.LeaveTypes.Add(entity);
            //save
            return Save();
            //throw new NotImplementedException();
        }

        public bool Delete(LeaveType entity)
        {
            _db.LeaveTypes.Remove(entity);
            //save
            return Save();
            //throw new NotImplementedException();
        }

        public ICollection<LeaveType> FindAll()
        {
            var leaveTypes = _db.LeaveTypes.ToList();
            return leaveTypes;
            //vagy
            //return _db.LeaveTypes.ToList();
           // throw new NotImplementedException();
        }

        public LeaveType FindById(int id)
        {
            var leaveType = _db.LeaveTypes.Find(id);
            return leaveType;
            //throw new NotImplementedException();
        }

        public ICollection<LeaveType> GetEmployeesByLeaveType(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
            //throw new NotImplementedException();
        }

        public bool Update(LeaveType entity)
        {
            _db.LeaveTypes.Update(entity);
            //save
            return Save();
           // throw new NotImplementedException();
        }
    }
}
