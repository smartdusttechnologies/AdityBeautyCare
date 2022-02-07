using AditiBeautyCare.Business.Common.Sample;
using AditiBeautyCare.Business.Core.Interfaces.BeautyCareService;
using AditiBeautyCare.Business.Core.Model.BeautyCareService;
using AditiBeautyCare.Business.Data.Repository.Interfaces.BeautyCareService;
using System.Collections.Generic;

namespace AditiBeautyCare.Business.Services.BeautyCareService
{
    public class BeautyCareService : IBeautyCareService
    {
        private readonly IBeautyCareServiceRepository _beautyCareServiceRepository;
        #region public methods
        public BeautyCareService(IBeautyCareServiceRepository beautyCareServiceRepository)
        {
            _beautyCareServiceRepository = beautyCareServiceRepository;
        }
        public List<BeautyCareServiceModel> Get()
        {
            return _beautyCareServiceRepository.Get();
        }

        public BeautyCareServiceModel Get(int id)
        {
            return _beautyCareServiceRepository.Get(id);
        }

        public List<BeautyCareServiceModel> GetPages(int pageIndex)
        {
            return _beautyCareServiceRepository.GetPages(pageIndex).ToNonNullList();
        }
        public RequestResult<int> Add(BeautyCareServiceBookingModel beautyCareService)
        {
            _beautyCareServiceRepository.Insert(beautyCareService);
            return new RequestResult<int>(1);
        }
        public RequestResult<int> AddCollection(List<BeautyCareServiceBookingModel> beautyCareService)
        {
            _beautyCareServiceRepository.InsertCollection(beautyCareService);
            return new RequestResult<int>(1);
        }
        public List<BeautyCareServiceBookingModel> Getbooking()
        {
            return _beautyCareServiceRepository.Getbooking();
        }

        public BeautyCareServiceBookingModel Getbooking(int id)
        {
            return _beautyCareServiceRepository.Getbooking(id);
        }

        public List<BeautyCareServiceBookingModel> GetbookingPages(int pageIndex)
        {
            return _beautyCareServiceRepository.GetbookingPages(pageIndex).ToNonNullList();
        }
        public RequestResult<int> Updatebooking(int id, BeautyCareServiceBookingModel beautyCareServicebooking)
        {
            _beautyCareServiceRepository.Updatebooking(beautyCareServicebooking);
            return new RequestResult<int>(1);
        }
        #endregion
    }
}
