using System.Linq;
using Ioc.Core.Data;
using Ioc.Data;

namespace Ioc.Service
{
    public class UserService : IUserService
    {

        private IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<User> GetUsers()
        {
            return unitOfWork.userRepository.Table;
        }

        public User GetUser(long id)
        {
            return unitOfWork.userRepository.GetById(id);
        }

        public void InsertUser(User user)
        {
            unitOfWork.userRepository.Insert(user);
            unitOfWork.Complete();
        }

        public void UpdateUser(User user)
        {
            unitOfWork.userRepository.Update(user);
            unitOfWork.Complete();
        }

        public void DeleteUser(User user)
        {
            unitOfWork.userProfileRepository.Delete(user.UserProfile);
            unitOfWork.userRepository.Delete(user);
            unitOfWork.Complete();
        }
    }
}
