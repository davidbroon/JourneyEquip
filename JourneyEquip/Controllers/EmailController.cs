using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace JourneyEquip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly ISendEmailService _sendEmailService;
        private readonly IinterestEmailService _interestEmailService;
        private readonly IUserApplicationEmailService _userApplicationEmailService;

        public EmailController(ISendEmailService sendEmailService, IinterestEmailService interestEmailService, IUserApplicationEmailService userApplicationEmailService)
     {
            _sendEmailService = sendEmailService;
            _interestEmailService = interestEmailService;
            _userApplicationEmailService = userApplicationEmailService;
        } 

        [HttpPost("interest")]
        public IActionResult InterestEmail(EmailDto request)
        {
            _interestEmailService.InterestEmail(request);
            return Ok();
        }

           [HttpPost("apply")]
        public IActionResult UserApplicationEmail(EmailDto request)
        {
            _userApplicationEmailService.UserApplicationEmail(request);
            return Ok();
        }

    }
}