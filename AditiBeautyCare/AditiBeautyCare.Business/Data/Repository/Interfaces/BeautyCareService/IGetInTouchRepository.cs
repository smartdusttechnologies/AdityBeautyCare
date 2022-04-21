using AditiBeautyCare.Business.Core.Model.BeautyCareService;
using System.Collections.Generic;
using System.Net.Mail;

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
        int Insert(EmailModel mailsend);

        /// <summary>
        /// Implimenting Interface for Insertcollection method in GetInTouchRepository
        /// </summary>
        /// <param name="mailsend"></param>
        /// <returns></returns>
        int InsertCollection(List<EmailModel> mailsend);

       // public static implicit operator string(IGetInTouchRepository v);
    }
}
