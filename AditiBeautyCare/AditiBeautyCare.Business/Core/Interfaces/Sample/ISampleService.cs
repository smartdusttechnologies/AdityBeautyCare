using System.Collections.Generic;
using AditiBeautyCare.Business.Core.Model;
using AditiBeautyCare.Business.Common.Sample;

namespace AditiBeautyCare.Business.Core.Interfaces
{
    public interface ISampleService
    {
        List<SampleModel> Get();
        List<SampleModel> GetPages(int pageIndex);
        SampleModel Get(int id);
        RequestResult<int> Add(SampleModel sample);
        RequestResult<int> Update(int id, SampleModel sample);
        bool Delete(int id);
        RequestResult<int> AddCollection(List<SampleModel> sample);
        
    }

}
