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
    public class UserRepository : IUserRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        #region Public Methods
        /// <summary>
        /// Establing connection with connection factory and GetInTouchRepository
        /// </summary>
        /// <param name="connectionFactory"></param>
        public UserRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        /// <summary>
        /// fetching data from database using Get method
        /// </summary>
        /// <returns></returns>

        List<string> IUserRepository.Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return (List<string>)db.Query<string>("select EmailId from [User] where Role='Admin'");
        } 
        #endregion
    }
}