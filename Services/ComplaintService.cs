using Complaint.Api.Services;
using Complaint.Api.Global.Requests;
using Complaint.Api.Global.Responses;
using System.Collections.Generic;
using System.Linq;
using Complaint.Api.Global.Domain;

namespace Complaint.Api.Global.Services
{
    public class ComplaintService : IComplaintService
    {
        private List<Complaints> lstComplaint = new List<Complaints>();

        public Dto GetAll()
        {
            return new Dto { Succeed = true, Data = lstComplaint.ToList() };
        }

        public Dto GetByKey(int complaintId)
        {
            return new Dto { Succeed = true, Data = lstComplaint.Where(o => o.ComplaintId == complaintId).FirstOrDefault() };
        }

        public Dto Save(ComplaintRequest request)
        {
            int complaintId = lstComplaint.Count + 1;
            lstComplaint.Add(new Complaints { ComplaintId = complaintId, Subject = request.Subject, Description = request.Description });
            return new Dto { Succeed = true };
        }
    }
}
