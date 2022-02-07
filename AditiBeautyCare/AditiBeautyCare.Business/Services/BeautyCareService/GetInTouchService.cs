using AditiBeautyCare.Business.Common.BeautyCareService;
using AditiBeautyCare.Business.Core.Interfaces.BeautyCareService;
using AditiBeautyCare.Business.Core.Model.BeautyCareService;
using AditiBeautyCare.Business.Data.Repository.Interfaces.BeautyCareService;
using System;
using System.Collections.Generic;
using System.Text;

namespace AditiBeautyCare.Business.Services.BeautyCareService
{
    public class GetInTouchService: IGetInTouchService
    {
        private readonly IGetInTouchRepository _getInTouchRepository;
        private readonly IEmailService _emailservice;
        #region public methods
        public GetInTouchService(IGetInTouchRepository getInTouchRepository, IEmailService  emailservice)
        {
            _getInTouchRepository = getInTouchRepository;
                _emailservice = emailservice;
        }
        

        public RequestResult<int> Add(EmailModel emailmodel)
        {
            var isemailsendsuccessfully = _emailservice.Sendemail(emailmodel);
            if (isemailsendsuccessfully)
            {
                _getInTouchRepository.Insert(emailmodel);
                return new RequestResult<int>(1);
            }
            return new RequestResult<int>(0);
        }

        //public RequestResult<int> AddCollection(List<GetInTouchModel> mailsend)
        //{
        //    _getInTouchRepository.InsertCollection(mailsend);
        //    return new RequestResult<int>(1);
        //}

        
        #endregion
    }
}
