using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ioc.Core.Data;

namespace Ioc.Data
{
    public class UnitOfWork : IUnitOfWork , IDisposable
    {
        IDbContext dbContext;
        public UnitOfWork(IDbContext dbContext, IRepository<User> userRepository, IRepository<UserProfile> userProfileRepository)
        {
            this.dbContext = dbContext;
            this.userProfileRepository = userProfileRepository;
            this.userRepository = userRepository;
        }
        public IRepository<User> userRepository { get; private set; }

        public IRepository<UserProfile> userProfileRepository { get; private set; }

        public int Complete()
        {
           return this.dbContext.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
