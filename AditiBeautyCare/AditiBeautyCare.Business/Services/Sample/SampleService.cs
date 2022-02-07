using System.Collections.Generic;
using AditiBeautyCare.Business.Core.Model;
using AditiBeautyCare.Business.Common.Sample;
using AditiBeautyCare.Business.Core.Interfaces;
using AditiBeautyCare.Business.Data.Repository.Interfaces;


namespace AditiBeautyCare.Business.Services
{
    /// <summary>
    /// IsampleService is implimenting the services for SampleService
    /// </summary>
    public class SampleService : ISampleService
    {
        private readonly ISampleRepository _sampleRepository;
        #region public methods
        public SampleService(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }
        public RequestResult<int> Add(SampleModel sample)
        {
            _sampleRepository.Insert(sample);
            return new RequestResult<int>(1);
        }
        public RequestResult<int> AddCollection(List<SampleModel> expenses)
        {
            _sampleRepository.InsertCollection(expenses);
            return new RequestResult<int>(1);
        }
        public bool Delete(int id)
        {
            _sampleRepository.Delete(id);
            return true;
        }
        public List<SampleModel> Get()
        {
            return _sampleRepository.Get();
        }
        public List<SampleModel> GetPages(int pageIndex)
        {
            return _sampleRepository.GetPages(pageIndex).ToNonNullList();
        }
        public SampleModel Get(int id)
        {
            return _sampleRepository.Get(id);
        }

        public RequestResult<int> Update(int id, SampleModel sample)
        {
            _sampleRepository.Update(sample);
            return new RequestResult<int>(1);
        }
        #endregion
    }
}
