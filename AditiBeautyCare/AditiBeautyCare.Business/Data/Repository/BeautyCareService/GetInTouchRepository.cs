using AditiBeautyCare.Business.Core.Model.BeautyCareService;
using AditiBeautyCare.Business.Data.Repository.Interfaces.BeautyCareService;
using AditiBeautyCare.Business.Infrastructure;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AditiBeautyCare.Business.Data.Repository.BeautyCareService
{

    /// <summary>
    /// Connection between Database using ISampleRepository we Establing a connection
    /// </summary>
    public class GetInTouchRepository : IGetInTouchRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        #region Public Methods
        /// <summary>
        /// Establing connection with connection factory and GetInTouchRepository
        /// </summary>
        /// <param name="connectionFactory"></param>
        public GetInTouchRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        /// <summary>
        /// Inserting data to database using Insert Method
        /// </summary>
        /// <param name="mailsend"></param>
        /// <returns></returns>
        public int Insert(EmailModel mailsend)
        {
            string query = @"Insert into [GetInTouch](EmailTo,Name,Subject,Message) 
                values (@EmailTo,@Name,@Subject,@Message)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, new { EmailTo=mailsend.EmailTo.First(),Name=mailsend.Name, Subject=mailsend.Subject,Message=mailsend.Subject});
        }

        /// <summary>
        /// Inserting data to collection
        /// </summary>
        /// <param name="mailsend"></param>
        /// <returns></returns>
        public int InsertCollection(List<EmailModel> mailsend)
        {
            string query = @"Insert into [GetInTouch](EmailTo,Name,Subject,Message) 
                values @EmailTo,@Name,@Subject,@Message)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, mailsend);
        }
        #endregion
    }
}
