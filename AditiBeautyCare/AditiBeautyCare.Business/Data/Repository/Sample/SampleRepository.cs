﻿using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using AditiBeautyCare.Business.Core.Model;
using AditiBeautyCare.Business.Data.Repository.Interfaces;
using System.Data;
using AditiBeautyCare.Business.Infrastructure;
using System.Linq;
using PagedList;

namespace AditiBeautyCare.Business.Data.Repository
{
    public class SampleRepository : ISampleRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public SampleRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<SampleModel> Get()
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<SampleModel>("Select * From [Sample] where IsDeleted=0").ToList();
        }

        public IPagedList<SampleModel> GetPages(int pageIndex = 1, int pageSize = 10)
        {
            using IDbConnection db = _connectionFactory.GetConnection;

            var query = db.QueryMultiple("SELECT COUNT(*) FROM [New] where IsDeleted=0;SELECT* FROM [New] where IsDeleted=0 ORDER BY Id desc OFFSET ((@PageNumber - 1) * @Rows) ROWS FETCH NEXT @Rows ROWS ONLY", new { PageNumber = pageIndex, Rows = pageSize }, commandType: CommandType.Text);
            var row = query.Read<int>().First();
            var pageResult = query.Read<SampleModel>().ToList();
            return new StaticPagedList<SampleModel>(pageResult, pageIndex, pageSize, row);

        }

        public SampleModel Get(int id)
        {
            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Query<SampleModel>("Select top 1 * From [New] where Id=@id and IsDeleted=0", new { id }).FirstOrDefault();
        }




        public int Insert(SampleModel sample)
        {
            string query = @"Insert into [New](Name, Description) 
                values (@Name, @Description)";

            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, sample);
        }


        public int InsertCollection(List<SampleModel> expenses)
        {
            string query = @"Insert into [New](Name, Description) 
                values (@Name, @Description)";

            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, expenses);
        }




        public int Update( SampleModel sample)
        {
            string query = @"update [New] Set 
                              Name = @Name,
                              Description = @Description
                            Where Id = @Id";

            using IDbConnection db = _connectionFactory.GetConnection;
            return db.Execute(query, sample);
        }

      
        public bool Delete( int id)
        {
            string query = @"update [New] Set 
                                IsDeleted = @IsDeleted
                            Where Id = @Id and  Id=@id ";

            using IDbConnection db = _connectionFactory.GetConnection;
            db.Execute(query, new { IsDeleted = true, Id = id});
            return true;
        }
    }
}