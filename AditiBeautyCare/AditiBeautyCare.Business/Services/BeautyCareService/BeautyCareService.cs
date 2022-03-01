using AditiBeautyCare.Business.Common;
using AditiBeautyCare.Business.Core.Interfaces.BeautyCareService;
using AditiBeautyCare.Business.Core.Model.BeautyCareService;
using AditiBeautyCare.Business.Data.Repository.Interfaces.BeautyCareService;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;


namespace AditiBeautyCare.Business.Services.BeautyCareService
{
    /// <summary>
    /// IsampleService is implimenting the services for BeautyCareService
    /// </summary>
    public class BeautyCareService : IBeautyCareService
    {
        private readonly IBeautyCareServiceRepository _beautyCareServiceRepository;
        #region public methods
        /// <summary>
        /// implimented beautycare service interfaces
        /// </summary>
        /// <param name="beautyCareServiceRepository"></param>
        public BeautyCareService(IBeautyCareServiceRepository beautyCareServiceRepository)
        {
            _beautyCareServiceRepository = beautyCareServiceRepository;
        }

        /// <summary>
        /// implimented beautycare service interfaces
        /// </summary>
        /// <returns></returns>
        public List<BeautyCareServiceModel> Get()
        {
            return _beautyCareServiceRepository.Get();
        }

        /// <summary>
        /// implimented beautycare service interfaces
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BeautyCareServiceModel Get(int id)
        {
            return _beautyCareServiceRepository.Get(id);
        }

        /// <summary>
        /// implimented beautycare service interfaces
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public List<BeautyCareServiceModel> GetPages(int pageIndex)
        {
            return _beautyCareServiceRepository.GetPages(pageIndex).ToNonNullList();
        }

        /// <summary>
        /// implimented beautycare service interfaces
        /// </summary>
        /// <param name="beautyCareService"></param>
        /// <returns></returns>
        public RequestResult<int> Add(BeautyCareServiceModel beautyCareService)
        {
            _beautyCareServiceRepository.Insert(beautyCareService);
            return new RequestResult<int>(1);
        }

        /// <summary>
        /// implimented beautycare service interfaces
        /// </summary>
        /// <param name="beautyCareService"></param>
        /// <returns></returns>
        public RequestResult<int> AddCollection(List<BeautyCareServiceModel> beautyCareService)
        {
            _beautyCareServiceRepository.InsertCollection(beautyCareService);
            return new RequestResult<int>(1);
        }

        /// <summary>
        /// implimented beautycare service interfaces
        /// </summary>
        /// <param name="beautyCareService"></param>
        /// <returns></returns>
        public RequestResult<int> Add(BeautyCareServiceBookingModel beautyCareService)
        {
            _beautyCareServiceRepository.Insert(beautyCareService);
            return new RequestResult<int>(1);
        }

        /// <summary>
        /// implimented beautycare service interfaces
        /// </summary>
        /// <param name="beautyCareService"></param>
        /// <returns></returns>
        public RequestResult<int> AddCollection(List<BeautyCareServiceBookingModel> beautyCareService)
        {
            _beautyCareServiceRepository.InsertCollection(beautyCareService);
            return new RequestResult<int>(1);
        }

        /// <summary>
        /// implimented beautycare service interfaces
        /// </summary>
        /// <returns></returns>
        public List<BeautyCareServiceBookingModel> Getbooking()
        {
            return _beautyCareServiceRepository.Getbooking();
        }

        

        /// <summary>
        /// implimented beautycare service interfaces
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BeautyCareServiceBookingModel Getbooking(int id)
        {
            return _beautyCareServiceRepository.Getbooking(id);
        }

        /// <summary>
        /// implimented beautycare service interfaces
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public List<BeautyCareServiceBookingModel> GetbookingPages(int pageIndex)
        {
            return _beautyCareServiceRepository.GetbookingPages(pageIndex).ToNonNullList();
        }

        /// <summary>
        /// implimented beautycare service interfaces
        /// </summary>
        /// <param name="id"></param>
        /// <param name="beautyCareServicebooking"></param>
        /// <returns></returns>
        public RequestResult<int> Updatebooking(int id, BeautyCareServiceBookingModel beautyCareServicebooking)
        {
            _beautyCareServiceRepository.Updatebooking(beautyCareServicebooking);
            return new RequestResult<int>(1);
        }
        /// <summary>
        /// Delete 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public bool Delete(int id)
        {
            _beautyCareServiceRepository.Delete(id);
            return true;
        }
        #endregion
    }
}


