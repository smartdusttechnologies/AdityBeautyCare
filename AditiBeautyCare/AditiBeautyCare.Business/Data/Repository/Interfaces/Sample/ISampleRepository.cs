using System;
using System.Collections.Generic;
using System.Text;
using AditiBeautyCare.Business.Core.Model;
using PagedList;

namespace AditiBeautyCare.Business.Data.Repository.Interfaces
{
    public interface ISampleRepository
    {
        int Insert(SampleModel sample);
        int Update(SampleModel sample);
        List<SampleModel> Get();
        IPagedList<SampleModel> GetPages(int pageIndex = 1, int pageSize = 10);
        SampleModel Get(int id);
        bool Delete(int id);
        int InsertCollection(List<SampleModel> sample);
    }
}
