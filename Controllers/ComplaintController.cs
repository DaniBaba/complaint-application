using Microsoft.AspNetCore.Mvc;
using Complaint.Api.Global.Requests;
using Complaint.Api.Global.Services;
using Microsoft.AspNetCore.Authorization;
using Complaint.Api.Services;

namespace Complaint.Api.Global.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ComplaintController : Controller
    {
        private readonly IComplaintService _complaintService;

        public ComplaintController(IComplaintService complaintService)
        {
            _complaintService = complaintService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_complaintService.GetAll());
        }

        [HttpGet("{complaintId}")]
        public IActionResult Get(int complaintId)
        {
            return Ok(_complaintService.GetByKey(complaintId));
        }

        [HttpPost]
        public IActionResult Save(ComplaintRequest request)
        {
            return Ok(_complaintService.Save(request));
        }
    }
}
