using AditiBeautyCare.Business.Core.Model.BeautyCareService;
using System;
using System.Collections.Generic;
using System.Text;

namespace AditiBeautyCare.Business.Core.Interfaces.BeautyCareService
{
    public interface IEmailService
    {
        bool Sendemail(EmailModel emailModel);
    }
}
