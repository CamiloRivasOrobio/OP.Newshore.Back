using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Newshore.Application.Interfaces
{
    public interface IRepositoryAsyncService<T> : IRepositoryBase<T> where T : class
    {
    }
    public interface IReadRepositoryAsync<T> : IReadRepositoryBase<T> where T : class
    {
    }
}
