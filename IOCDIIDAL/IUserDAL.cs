using IOCDIModel;
using System;
using System.Linq.Expressions;

namespace IOCDIIDAL
{
    public interface IUserDAL
    {
        public UserModel Find(Expression<Func<UserModel, bool>> expression);

        void Update(UserModel userModel);

    }
}
