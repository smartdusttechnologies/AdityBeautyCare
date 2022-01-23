using System.Data;

namespace AditiBeautyCare.Business.Infrastructure
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
