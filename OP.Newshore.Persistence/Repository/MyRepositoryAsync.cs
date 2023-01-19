using Ardalis.Specification.EntityFrameworkCore;
using OP.Newshore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Newshore.Persistence.Repository
{
    public class MyRepositoryAsync<T> : RepositoryBase<T>, IRepositoryAsyncService<T> where T : class
    {
        private readonly ApplicationDbContext dbContext;

        public MyRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
