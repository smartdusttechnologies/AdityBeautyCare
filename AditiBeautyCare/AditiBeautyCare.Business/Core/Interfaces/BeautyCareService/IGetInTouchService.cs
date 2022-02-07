using AditiBeautyCare.Business.Common;
using AditiBeautyCare.Business.Core.Model.BeautyCareService;

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
        RequestResult<int> Add(EmailModel mailsend);

        /// <summary>
        /// implimenting Add collection method
        /// </summary>
        /// <param name="mailsend"></param>
        /// <returns></returns>
        //RequestResult<int> AddCollection(List<EmailModel> mailsend);

    }
}
