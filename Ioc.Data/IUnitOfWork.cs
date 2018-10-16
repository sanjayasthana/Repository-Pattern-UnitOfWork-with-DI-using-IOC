using Ioc.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.Data
{
    public interface IUnitOfWork
    {
        IRepository<User> userRepository { get; }
        IRepository<UserProfile> userProfileRepository { get; }

        int Complete();
    }
}
