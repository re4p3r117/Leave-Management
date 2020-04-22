using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Models
{
    public class LeaveRequestViewModel
    {

        public int Id { get; set; }


        public EmployeeViewModel RequestingEmployee { get; set; }
        [Display(Name = "Employee Name")]
        public string RequestingEmployeeId { get; set; }
        [Display(Name = "Start Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public LeaveTypeViewModel LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        [Display(Name = "Date Requested")]
        public DateTime DateRequested { get; set; }
        [Display(Name = "Date Actioned")]
        public DateTime DateActioned { get; set; }
        [Display(Name = "Approval State")]
        public bool? Approved { get; set; } //bool? azt jelenti, hogy háromértékű lehet a bool true, false vagy null
        public EmployeeViewModel ApprovedBy { get; set; }
        public string ApprovedById { get; set; }
        public bool Cancelled { get; set; }
        [Display(Name = "Employee Comments")]
        [MaxLength(300)]
        public string RequestComments { get; set; }
    }

    public class AdminLeaveRequestViewModel
    {
        [Display(Name ="Total Number of Requests")]
        public int TotalRequests { get; set; }
        [Display(Name = "Number of Approved Requests")]
        public int ApprovedRequests { get; set; }
        [Display(Name = "Number of Pending Requests")]
        public int PendingRequests { get; set; }
        [Display(Name = "Number of Rejected Requests")]
        public int RejectedRequests { get; set; }

        public List<LeaveRequestViewModel> LeaveRequests { get; set; }
    }
    public class CreateLeaveRequestViewModel
    {
        [Display(Name = "Start Date")]
        [Required]
        //[DataType(DataType.Date)]
        public string StartDate { get; set; }
        [Display(Name = "End Date")]
        [Required]
        //[DataType(DataType.Date)]
        public string EndDate { get; set; }

        public IEnumerable<SelectListItem> LeaveTypes { get; set; }
        [Display(Name = "Leave Type")]
        public int LeaveTypeId { get; set; }
        [Display(Name = "Employee Comments")]
        [MaxLength(300)]
        public string RequestComments { get; set; }
    }

    public class EmployeeLeaveRequestViewViewModel
    {
        public List<LeaveAllocationViewModel> LeaveAllocations { get; set; }
        public List<LeaveRequestViewModel> LeaveRequests { get; set; }
    }
}
