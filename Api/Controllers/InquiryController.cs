using Domain.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InquiryController : Controller
    {
        private readonly IInquiryService _inquiryService;
        public InquiryController(IInquiryService inquiryService)
        {
            _inquiryService = inquiryService;
        }

        [HttpPost]
        [Route("Request")]
        public IActionResult Post([FromBody] InqueryRequest inquiry)
        {
            var response = _inquiryService.Submit(inquiry);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetAllRequests")]
        public IActionResult Get()
        {
            var response = _inquiryService.GetAllRequests();
            return Ok(response);
        }
    }
}
