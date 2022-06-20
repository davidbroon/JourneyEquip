using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyEquip.Services.EmailService.Interest
{
    public interface IinterestEmailService
    {
                void InterestEmail(EmailDto request);
    }
}