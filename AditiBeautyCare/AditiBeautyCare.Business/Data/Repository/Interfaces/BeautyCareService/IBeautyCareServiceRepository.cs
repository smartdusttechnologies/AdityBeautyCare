﻿using AditiBeautyCare.Business.Core.Model.BeautyCareService;
using PagedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace AditiBeautyCare.Business.Data.Repository.Interfaces.BeautyCareService
{
    public interface IBeautyCareServiceRepository
    {
        List<BeautyCareServiceModel> Get();
     
        BeautyCareServiceModel Get(int id);
        IPagedList<BeautyCareServiceModel> GetPages(int pageIndex = 1, int pageSize = 10);
        int Insert(BeautyCareServiceBookingModel beautyCareService);
        int InsertCollection(List<BeautyCareServiceBookingModel> beautyCareService);
        List<BeautyCareServiceBookingModel> Getbooking();

        BeautyCareServiceBookingModel Getbooking(int id);
        IPagedList<BeautyCareServiceBookingModel> GetbookingPages(int pageIndex = 1, int pageSize = 10);
        int Updatebooking(BeautyCareServiceBookingModel beautycareServices);
       
    }
}
