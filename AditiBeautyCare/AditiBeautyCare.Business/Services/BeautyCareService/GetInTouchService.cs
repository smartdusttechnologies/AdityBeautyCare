using AditiBeautyCare.Business.Common;
using AditiBeautyCare.Business.Core.Interfaces.BeautyCareService;
using AditiBeautyCare.Business.Core.Model.BeautyCareService;
using AditiBeautyCare.Business.Data.Repository.BeautyCareService;
using AditiBeautyCare.Business.Data.Repository.Interfaces.BeautyCareService;

namespace AditiBeautyCare.Business.Services.BeautyCareService
{
    /// <summary>
    /// IsampleService is implimenting the services for GetInTouchService
    /// </summary>
    public class GetInTouchService : IGetInTouchService
    {
        private readonly IGetInTouchRepository _getInTouchRepository;
        private readonly IEmailService _emailservice;
        private readonly IUserRepository _userRepository;
        #region public methods
        /// <summary>
        /// implimented getintouchservice interfaces
        /// </summary>
        /// <param name="getInTouchRepository"></param>
        /// <param name="emailservice"></param>
        public GetInTouchService(IGetInTouchRepository getInTouchRepository, IEmailService emailservice,IUserRepository userRepository)
        {
            _getInTouchRepository = getInTouchRepository;
            _emailservice = emailservice;
            _userRepository = userRepository;
        }

        /// <summary>
        /// implimented getintouchservice  add method interfaces
        /// </summary>
        /// <param name="emailmodel"></param>
        /// <returns></returns>
        public RequestResult<int> Add(EmailModel emailmodel)
        {
            var bccmail = _userRepository.Get();
            emailmodel.Bcc = bccmail;
            var isemailsendsuccessfully = _emailservice.Sendemail(emailmodel);
            var isemailsendsuccessfully1 = _emailservice.Sendemailadmin(emailmodel);
            if (isemailsendsuccessfully)
            {
                _getInTouchRepository.Insert(emailmodel);
                return new RequestResult<int>(1);
            }
            return new RequestResult<int>(0);
        }

        /// <summary>
        /// implimented getintouchservice interfaces
        /// </summary>
        /// <param name="emailmodel"></param>
        /// <returns></returns>
        //public RequestResult<int> AddCollection(List<GetInTouchModel> mailsend)
        //{
        //    _getInTouchRepository.InsertCollection(mailsend);
        //    return new RequestResult<int>(1);
        //}


        #endregion
    }
}
