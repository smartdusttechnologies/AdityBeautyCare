using System.Collections.Generic;
using AditiBeautyCare.Business.Common;
using AditiBeautyCare.Business.Core.Model.BeautyCareService;

namespace AditiBeautyCare.Business.Core.Interfaces.BeautyCareService
{
    /// <summary>
    /// For implimenting interface for BeautyCareService
    /// </summary>
    public interface IBeautyCareService
    {
        /// <summary>
        /// implimenting interface for get method
        /// </summary>
        /// <returns></returns>
        List<BeautyCareServiceModel> Get();

        /// <summary>
        /// implimenting interface for Get with id method
        /// </summary>
        /// <returns></returns>
        BeautyCareServiceModel Get(int id);

        /// <summary>
        /// impliment interface for getpage index
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        List<BeautyCareServiceModel> GetPages(int pageIndex);

        /// <summary>
        ///implimenting add method
        /// </summary>
        /// <param name="beautyCareService"></param>
        /// <returns></returns>
        RequestResult<int> Add(BeautyCareServiceModel beautyCareService);

        /// <summary>
        /// implimenting add collection service
        /// </summary>
        /// <param name="beautyCareService"></param>
        /// <returns></returns>
        RequestResult<int> AddCollection(List<BeautyCareServiceModel> beautyCareService);

        /// <summary>
        ///implimenting add method
        /// </summary>
        /// <param name="beautyCareService"></param>
        /// <returns></returns>
        RequestResult<bool> Add(BeautyCareServiceBookingModel beautyCareService);

        /// <summary>
        /// implimenting add collection service
        /// </summary>
        /// <param name="beautyCareService"></param>
        /// <returns></returns>
        //RequestResult<int> AddCollection(List<BeautyCareServiceBookingModel> beautyCareService);

        /// <summary>
        /// Implimenting Getbooking  method
        /// </summary>
        /// <returns></returns>
        List<BeautyCareServiceBookingModel> Getbooking();

        /// <summary>
        /// Impimenting Getbooking Id  mentod 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BeautyCareServiceBookingModel Getbooking(int id);

        /// <summary>
        /// implimenting getbooking pages index with id
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        List<BeautyCareServiceBookingModel> GetbookingPages(int pageIndex);

        /// <summary>
        /// Implimenting Update booking method
        /// </summary>
        /// <param name="id"></param>
        /// <param name="beautyCareServicebooking"></param>
        /// <returns></returns>
        RequestResult<int> Updatebooking(int id, BeautyCareServiceBookingModel beautyCareServicebooking);
        


        bool Delete(int id);

       
    }
}
