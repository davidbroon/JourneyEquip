using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyEquip.Services.EmailService.Send
{
    public interface ISendEmailService
    {
        void SendEmail(EmailDto request);

    }
}