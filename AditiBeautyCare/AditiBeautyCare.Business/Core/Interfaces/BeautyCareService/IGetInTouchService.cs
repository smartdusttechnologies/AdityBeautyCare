using AditiBeautyCare.Business.Common.BeautyCareService;
using AditiBeautyCare.Business.Core.Model.BeautyCareService;
using System;
using System.Collections.Generic;
using System.Text;

namespace AditiBeautyCare.Business.Core.Interfaces.BeautyCareService
{
    public interface IGetInTouchService
    {

        RequestResult<int> Add(GetInTouchModel mailsend);
        RequestResult<int> AddCollection(List<GetInTouchModel> mailsend);

    }
}
