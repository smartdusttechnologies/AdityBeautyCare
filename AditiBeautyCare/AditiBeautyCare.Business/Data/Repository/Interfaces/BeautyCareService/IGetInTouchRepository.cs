using AditiBeautyCare.Business.Core.Model.BeautyCareService;
using System.Collections.Generic;

namespace AditiBeautyCare.Business.Data.Repository.Interfaces.BeautyCareService
{
    /// <summary>
    /// Creating Interface for GetInTouchRepository
    /// </summary>
    public interface IGetInTouchRepository
    {
        /// <summary>
        /// Implimenting Interface for Insert method in GetInTouchRepository
        /// </summary>
        /// <param name="mailsend"></param>
        /// <returns></returns>
        bool Insert(EmailModel mailsend);

        /// <summary>
        /// Implimenting Interface for Insertcollection method in GetInTouchRepository
        /// </summary>
        /// <param name="mailsend"></param>
        /// <returns></returns>
        //bool InsertCollection(List<EmailModel> mailsend);
    }
}
