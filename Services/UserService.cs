using Complaint.Api.Global.Domain;
using Complaint.Api.Global.Framework;
using Complaint.Api.Global.Requests;
using Complaint.Api.Global.Responses;
using Complaint.Api.Services;
using System.Collections.Generic;
using System.Linq;

namespace Complaint.Api.Global.Services
{
    public class UserService : IUserService
    {
        private List<User> lstUser = new List<User>();
        private readonly JwtSettings _jwtSettings;

        public UserService(JwtSettings jwtSettings)
        {            
            _jwtSettings = jwtSettings;
        }

        public Dto Login(AuthRequest request)
        {
            var user = lstUser.Where(o => o.Email == request.Email && o.Password == request.Password).FirstOrDefault();
            if (user != null)
                return new Dto { Succeed = true, Data = _jwtSettings.GenerateJwtToken("1", "abc@gmail.com") };
            else
                return new Dto { Message = "Invalid User" };
        }

        public Dto Register(UserRequest request)
        {
            var user = lstUser.Where(o => o.Email == request.Email).FirstOrDefault();
            if (user != null)
                return new Dto { Message = "Duplicate user not allowed" };
            else
            {
                lstUser.Add(new User { UserName = request.UserName, Email = request.Email, Password = request.Password });
                return new Dto { Succeed = true };
            }
        }
    }
}
