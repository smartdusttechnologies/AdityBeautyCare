using AditiBeautyCare.Business.Core.Model.BeautyCareService;
using PagedList;
using System.Collections.Generic;

namespace AditiBeautyCare.Business.Data.Repository.Interfaces.BeautyCareService
{
    /// <summary>
    /// Creating Interface for BeautyCareServiceRepository
    /// </summary>
    public interface IBeautyCareServiceRepository
    {
        /// <summary>
        /// Implimenting Interface for Get method in BeautyCareServiceRepository
        /// </summary>
        /// <returns></returns>
        List<BeautyCareServiceModel> Get();

        /// <summary>
        /// Implimenting Interface for Get with id as parameter method in BeautyCareServiceRepository
        /// </summary>
        /// <returns></returns>
        BeautyCareServiceModel Get(int id);

        /// <summary>
        /// Implimenting Interface for GetPages method in BeautyCareServiceRepository
        /// </summary>
        /// <returns></returns>
        IPagedList<BeautyCareServiceModel> GetPages(int pageIndex = 1, int pageSize = 10);

        /// <summary>
        /// Implimenting Interface for Insert method in BeautyCareServiceRepository
        /// </summary>
        /// <returns></returns>
        int Insert(BeautyCareServiceModel beautyCareService);

        /// <summary>
        /// Implimenting Interface for InsertCollection method in BeautyCareServiceRepository
        /// </summary>
        /// <returns></returns>
        int InsertCollection(List<BeautyCareServiceModel> beautyCareService);

        /// <summary>
        /// Implimenting Interface for Insert method in BeautyCareServiceRepository
        /// </summary>
        /// <returns></returns>
        int Insert(BeautyCareServiceBookingModel beautyCareService);

        /// <summary>
        /// Implimenting Interface for InsertCollection method in BeautyCareServiceRepository
        /// </summary>
        /// <returns></returns>
        int InsertCollection(List<BeautyCareServiceBookingModel> beautyCareService);

        /// <summary>
        /// Implimenting Interface for Getbooking method in BeautyCareServiceRepository
        /// </summary>
        /// <returns></returns>
        List<BeautyCareServiceBookingModel> Getbooking();

        /// <summary>
        /// Implimenting Interface for Getbooking with id method in BeautyCareServiceRepository
        /// </summary>
        /// <returns></returns>
        BeautyCareServiceBookingModel Getbooking(int id);

        /// <summary>
        /// Implimenting Interface for Getbookingpages method in BeautyCareServiceRepository
        /// </summary>
        /// <returns></returns>
        IPagedList<BeautyCareServiceBookingModel> GetbookingPages(int pageIndex = 1, int pageSize = 10);

        /// <summary>
        /// Implimenting Interface for updatebooking method in BeautyCareServiceRepository
        /// </summary>
        /// <returns></returns>
        int Updatebooking(BeautyCareServiceBookingModel beautycareServices);
        //TODO: ADD COMMENT
        bool Delete(int id);

    }
}
