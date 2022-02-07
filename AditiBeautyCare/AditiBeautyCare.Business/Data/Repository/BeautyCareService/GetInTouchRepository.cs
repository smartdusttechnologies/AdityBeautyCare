using AditiBeautyCare.Business.Core.Model.BeautyCareService;
using AditiBeautyCare.Business.Data.Repository.Interfaces.BeautyCareService;
using AditiBeautyCare.Business.Infrastructure;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AditiBeautyCare.Business.Data.Repository.BeautyCareService
{
    public class GetInTouchRepository: IGetInTouchRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        #region Public Methods
        public GetInTouchRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public int Insert(EmailModel mailsend)
        {
            string query = @"Insert into [GetInTouch](EmailTo,Name,Subject,Body) 
                values (@EmailTo,@Name,@Subject,@Body)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, mailsend);
        }

        public int InsertCollection(List<EmailModel> mailsend)
        {
            string query = @"Insert into [GetInTouch](EmailTo,Name,Subject,Body) 
                values @EmailTo,@Name,@Subject,@Body)";
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, mailsend);
        }
        #endregion
    }
}
