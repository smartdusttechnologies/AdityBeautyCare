using System;
using System.Collections.Generic;
using System.Text;
using AditiBeautyCare.Business.Common.Sample;
using AditiBeautyCare.Business.Core.Model.BeautyCareService;

namespace AditiBeautyCare.Business.Core.Interfaces.BeautyCareService
{
    public interface IBeautyCareService
    {
        List<BeautyCareServiceModel> Get();

        BeautyCareServiceModel Get(int id);
        List<BeautyCareServiceModel> GetPages(int pageIndex);

        RequestResult<int> Add(BeautyCareServiceBookingModel beautyCareService);
        RequestResult<int> AddCollection(List<BeautyCareServiceBookingModel> beautyCareService);
        List<BeautyCareServiceBookingModel> Getbooking();

        BeautyCareServiceBookingModel Getbooking(int id);
        List<BeautyCareServiceBookingModel> GetbookingPages(int pageIndex);
        RequestResult<int> Updatebooking(int id, BeautyCareServiceBookingModel beautyCareServicebooking);
    }
}
