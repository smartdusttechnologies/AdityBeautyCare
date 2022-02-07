﻿using AditiBeautyCare.Business.Core.Model.BeautyCareService;
using System;
using System.Collections.Generic;
using System.Text;

namespace AditiBeautyCare.Business.Data.Repository.Interfaces.BeautyCareService
{
    public interface IGetInTouchRepository
    {
        int Insert(GetInTouchModel mailsend);
        int InsertCollection(List<GetInTouchModel> mailsend);
    }
}
