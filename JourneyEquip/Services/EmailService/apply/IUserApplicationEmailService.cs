using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneyEquip.Services.EmailService.Apply
{
    public interface IUserApplicationEmailService
    {
        void UserApplicationEmail(EmailDto request);
    }
}