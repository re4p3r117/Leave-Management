﻿using Leave_Management.Contracts;
using Leave_Management.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Repository
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveRequestRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(LeaveRequest entity)
        {
            await _db.LeaveRequests.AddAsync(entity);
            //save
            return await Save();
            //throw new NotImplementedException();
        }

        public async Task<bool> Delete(LeaveRequest entity)
        {
            _db.LeaveRequests.Remove(entity);
            //save
            return await Save();
            //throw new NotImplementedException();
        }

        public async Task<ICollection<LeaveRequest>> FindAll()
        {
            var leaveHistories = await _db.LeaveRequests
                .Include(q => q.RequestingEmployee)
                .Include(q => q.ApprovedBy)
                .Include(q => q.LeaveType)
                .ToListAsync();
            return leaveHistories;
            //throw new NotImplementedException();
        }

        public async Task<LeaveRequest> FindById(int id)
        {
            var leaveHistory = await _db.LeaveRequests
                .Include(q => q.RequestingEmployee)
                .Include(q => q.ApprovedBy)
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);
            return leaveHistory;
            // throw new NotImplementedException();
        }

        public async Task<ICollection<LeaveRequest>> GetLeaveRequestsByEmployee(string employeeid)
        {
            //var leaveRequests = _db.LeaveRequests
            //    .Include(q => q.RequestingEmployee)
            //    .Include(q => q.ApprovedBy)
            //    .Include(q => q.LeaveType)
            //    .Where(q => q.RequestingEmployeeId == employeeid)
            //    .ToList();
            var leaveRequests = await FindAll();
                
            return leaveRequests.Where(q => q.RequestingEmployeeId == employeeid)
                .ToList();
        }

        public async Task<bool> isExists(int id)
        {
            var exists = await _db.LeaveRequests.AnyAsync(q => q.Id == id);
            return exists;
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
            //throw new NotImplementedException();
        }

        public async Task<bool> Update(LeaveRequest entity)
        {
            _db.LeaveRequests.Update(entity);
            //save
            return await Save();
            //throw new NotImplementedException();
        }
    }
}
