using AditiBeautyCare.Business.Core.Model.BeautyCareService;

namespace AditiBeautyCare.Business.Core.Interfaces.BeautyCareService
{
    /// <summary>
    /// For implimenting interface for EmailService
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Implimenting interface for Sendmail Method
        /// </summary>
        /// <param name="emailModel"></param>
        /// <returns></returns>
        bool Sendemail(EmailModel emailModel);
    }
}
