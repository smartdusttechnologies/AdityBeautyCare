using AditiBeautyCare.Business.Core.Model.BeautyCareService;
using AditiBeautyCare.Business.Data.Repository.Interfaces.BeautyCareService;
using AditiBeautyCare.Business.Infrastructure;
using Dapper;
using PagedList;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AditiBeautyCare.Business.Data.Repository.BeautyCareService
{
        /// <summary>
        /// Connection between Database using ISampleRepository we Establing a connection
        /// </summary>
    public class BeautyCareRepository : IBeautyCareServiceRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        #region Public Methods
        /// <summary>
        /// Establing connection with connection factory and GetInTouchRepository
        /// </summary>
        /// <param name="connectionFactory"></param>
        public BeautyCareRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// fetching data from database using Get method
        /// </summary>
        /// <returns></returns>

        public List<BeautyCareServiceModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<BeautyCareServiceModel>("Select * From [BeautyCareServices] where IsDeleted=0").ToList();
        }
        /// <summary>
        /// Getting data from databse using Get method with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public BeautyCareServiceModel Get(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<BeautyCareServiceModel>("Select top 1 * From [BeautyCareServices] where Id=@id and IsDeleted=0", new { id }).FirstOrDefault();
        }
        /// <summary>
        /// Getting Page size of data using Getpages
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>

        public IPagedList<BeautyCareServiceModel> GetPages(int pageIndex = 1, int pageSize = 10)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            var query = db.QueryMultiple("SELECT COUNT(*) FROM [BeautyCareServices] where IsDeleted=0; SELECT Name, Description, Duration, Price, ImageUrl as FilePath FROM BeautyCareServices where IsDeleted=0 ORDER BY Id desc OFFSET ((@PageNumber - 1) * @Rows) ROWS FETCH NEXT @Rows ROWS ONLY", new { PageNumber = pageIndex, Rows = pageSize }, commandType: CommandType.Text);
            var row = query.Read<int>().First();
            var pageResult = query.Read<BeautyCareServiceModel>().ToList();
            return new StaticPagedList<BeautyCareServiceModel>(pageResult, pageIndex, pageSize, row);
        }

        /// <summary>
        /// Inserting data using Insert method
        /// </summary>
        /// <param name="beautyCareService"></param>
        /// <returns></returns>

        public int Insert(BeautyCareServiceModel beautyCareService)
        {
            string query = @"Insert into [BeautyCareServices](Name,Duration,ImageUrl,Price,Description) 
                values (@Name,@Duration,@FilePath,@Price,@Description)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, beautyCareService);
        }

        /// <summary>
        /// Inserting data to collection
        /// </summary>
        /// <param name="beautyCareService"></param>
        /// <returns></returns>
        public int InsertCollection(List<BeautyCareServiceModel> beautyCareService)
        {
            string query = @"Insert into [BeautyCareServices](Name,Duration,ImageUrl,Price,Description) 
                values (@Name,@Duration,@FilePath,@Price,@Description)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, beautyCareService);
        }

        /// <summary>
        /// Inserting data using Insert method
        /// </summary>
        /// <param name="beautyCareService"></param>
        /// <returns></returns>

        public int Insert(BeautyCareServiceBookingModel beautyCareService)
        {
            string query = @"Insert into [BeautyCareServiceBooking](ServiceId,UserName,UserEmail,Date,[From],[To],UserMobileNumber, Description) 
                values (@ServiceId,@UserName,@UserEmail,@Date,@From,@To,@UserMobileNumber,@Description)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, beautyCareService);
        }

        /// <summary>
        /// Inserting data to collection
        /// </summary>
        /// <param name="beautyCareService"></param>
        /// <returns></returns>
        public int InsertCollection(List<BeautyCareServiceBookingModel> beautyCareService)
        {
            string query = @"Insert into [BeautyCareServiceBooking](ServiceId,UserName,UserEmail,Date,From,To,UserMobileNumber,Description) 
                values (@ServiceId,@UserName,@UserEmail,@Date,@From,@To,@UserMobileNumber, @Description)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, beautyCareService);
        }

        /// <summary>
        /// Getting Booking from database
        /// </summary>
        /// <returns></returns>
        public List<BeautyCareServiceBookingModel> Getbooking()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<BeautyCareServiceBookingModel>("Select * From [BeautyCareServicebooking] where IsDeleted=0").ToList();
        }

        /// <summary>
        /// Getting data from databse
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BeautyCareServiceBookingModel Getbooking(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<BeautyCareServiceBookingModel>("Select top 1 * From [BeautyCareServicebooking] where Id=@id and IsDeleted=0", new { id }).FirstOrDefault();
        }

        /// <summary>
        /// Getting pages from database
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IPagedList<BeautyCareServiceBookingModel> GetbookingPages(int pageIndex = 1, int pageSize = 10)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            var query = db.QueryMultiple("SELECT COUNT(*) FROM [BeautyCareServicebooking] where IsDeleted=0;SELECT BCSB.ServiceId,BCS.Name as ServiceName,BCSB.Id,BCSB.Date,BCSB.UserName,BCSB.UserMobileNumber,BCSB.[From],BCSB.[To],BCSB.UserEmail FROM [BeautyCareServicebooking] BCSB INNER JOIN [BeautyCareServices] BCS ON BCS.Id=BCSB.ServiceId where BCSB.IsDeleted=0 and BCS.IsDeleted=0 and Date>=GETDATE() ORDER BY Date asc");
            var row = query.Read<int>().First();
            var pageResult = query.Read<BeautyCareServiceBookingModel>().ToList();
            return new StaticPagedList<BeautyCareServiceBookingModel>(pageResult, pageIndex, pageSize, row);
        }

        /// <summary>
        /// Updating bookings using Updatebooking method
        /// </summary>
        /// <param name="beautyCareservicebooking"></param>
        /// <returns></returns>
        public int Updatebooking(BeautyCareServiceBookingModel beautyCareservicebooking)
        {
            string query = @"update [BeautyCareServicebooking] Set 
                              UserName = @UserName,
                              UserEmail =@UserEmail,
                                ServiceId=@ServiceId,
                                Date=@Date,
                                [From]=@From,
                                [To]=@To,
                                UserMobileNumber=@UserMobileNumber,
                              Description = @Description
                            Where Id = @Id";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, beautyCareservicebooking);
        }
        /// <summary>
        /// Delete the Booking done by booking Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            string query = @"update [BeautyCareServicebooking] Set 
                                IsDeleted = @IsDeleted
                            Where Id = @Id and  Id=@id ";
            using IDbConnection db = _connectionFactory.GetConnection;
            db.Execute(query, new { IsDeleted = true, Id = id });
            return true;
        }
        #endregion
    }
}
