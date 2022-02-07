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
        #region public methods
        public GetInTouchService(IGetInTouchRepository getInTouchRepository)
        {
            _getInTouchRepository = getInTouchRepository;
        }
        

        public RequestResult<int> Add(GetInTouchModel mailsend)
        {
            _getInTouchRepository.Insert(mailsend);
            return new RequestResult<int>(1);
        }

        public RequestResult<int> AddCollection(List<GetInTouchModel> mailsend)
        {
            _getInTouchRepository.InsertCollection(mailsend);
            return new RequestResult<int>(1);
        }

        
        #endregion
    }
}
