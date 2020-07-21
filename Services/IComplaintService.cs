using Complaint.Api.Global.Requests;
using Complaint.Api.Global.Responses;

namespace Complaint.Api.Services
{
    public interface IComplaintService
    {
        Dto GetAll();
        Dto GetByKey(int complaintId);
        Dto Save(ComplaintRequest request);
    }
}
