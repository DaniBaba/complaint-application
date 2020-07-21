using Complaint.Api.Global.Requests;
using Complaint.Api.Global.Responses;

namespace Complaint.Api.Services
{
    public interface IUserService
    {
        Dto Login(AuthRequest request);
        Dto Register(UserRequest request);
    }
}
