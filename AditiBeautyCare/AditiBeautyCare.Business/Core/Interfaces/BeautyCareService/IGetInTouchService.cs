using AditiBeautyCare.Business.Common;
using AditiBeautyCare.Business.Core.Model.BeautyCareService;
using System.Collections.Generic;

namespace AditiBeautyCare.Business.Core.Interfaces.BeautyCareService
{
    /// <summary>
    /// For implimenting interface for GetInTouchService
    /// </summary>
    public interface IGetInTouchService
    {
        /// <summary>
        /// Implimenting add method 
        /// </summary>
        /// <param name="mailsend"></param>
        /// <returns></returns>
        RequestResult<bool> Add(EmailModel mailsend);

        /// <summary>
        /// implimenting Add collection method
        /// </summary>
        /// <param name="mailsend"></param>
        /// <returns></returns>
       /// RequestResult<bool> AddCollection(List<EmailModel> mailsend);

    }
}
