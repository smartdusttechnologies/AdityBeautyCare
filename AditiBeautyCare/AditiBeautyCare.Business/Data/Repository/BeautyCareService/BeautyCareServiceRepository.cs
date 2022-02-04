using AditiBeautyCare.Business.Common.Sample;
using AditiBeautyCare.Business.Core.Interfaces.BeautyCareService;
using AditiBeautyCare.Business.Core.Model.BeautyCareService;
using AditiBeautyCare.Business.Data.Repository.Interfaces.BeautyCareService;
using AditiBeautyCare.Business.Infrastructure;
using Dapper;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AditiBeautyCare.Business.Data.Repository.BeautyCareService
{
    public class BeautyCareRepository:IBeautyCareServiceRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        #region Public Methods
        public  BeautyCareRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<BeautyCareServiceModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<BeautyCareServiceModel>("Select * From [BeautyCareServices] where IsDeleted=0").ToList();
        }

        public BeautyCareServiceModel Get(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<BeautyCareServiceModel>("Select top 1 * From [BeautyCareServices] where Id=@id and IsDeleted=0", new { id }).FirstOrDefault();
        }

        public IPagedList<BeautyCareServiceModel> GetPages(int pageIndex = 1, int pageSize = 10)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            var query = db.QueryMultiple("SELECT COUNT(*) FROM [BeautyCareServices] where IsDeleted=0;SELECT* FROM [BeautyCareServices] where IsDeleted=0 ORDER BY Id desc OFFSET ((@PageNumber - 1) * @Rows) ROWS FETCH NEXT @Rows ROWS ONLY", new { PageNumber = pageIndex, Rows = pageSize }, commandType: CommandType.Text);
            var row = query.Read<int>().First();
            var pageResult = query.Read<BeautyCareServiceModel>().ToList();
            return new StaticPagedList<BeautyCareServiceModel>(pageResult, pageIndex, pageSize, row);
        }
        public int Insert(BeautyCareServiceBookingModel beautyCareService)
        {
            string query = @"Insert into [BeautyCareServiceBooking](ServiceId,UserName,UserEmail,Date,[From],[To],UserMobileNumber, Description) 
                values (@ServiceId,@UserName,@UserEmail,@Date,@From,@To,@UserMobileNumber,@Description)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, beautyCareService);
        }

        public int InsertCollection(List<BeautyCareServiceBookingModel> beautyCareService)
        {
            string query = @"Insert into [BeautyCareServiceBooking](ServiceId,UserName,UserEmail,Date,From,To,UserMobileNumber,Description) 
                values (@ServiceId,@UserName,@UserEmail,@Date,@From,@To,@UserMobileNumber, @Description)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, beautyCareService);
        }
        #endregion
    }

}
