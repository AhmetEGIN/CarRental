using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            var result = _userDal.Get(u => u.Id == user.Id);
            if (result is null)
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.UserAdded);
            }
            return new ErrorResult(Messages.CheckUserData);
        }

        public IResult Delete(User user)
        {
            var result = _userDal.Get(u => u.Id == user.Id);
            if (result is null)
            {
                _userDal.Delete(user);
                return new SuccessResult(Messages.UserDeleted);
            }
            return new ErrorResult(Messages.UserNotFound);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        }

        public IDataResult<User> GetById(int id)
        {
            var result = _userDal.Get(u => u.Id == id);
            if (result is null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            return new SuccessDataResult<User>(result,Messages.UserListed);
        }

        public IResult Update(User user)
        {
            var result = _userDal.Get(u => u.Id == user.Id);
            if (result is null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);

        }
    }
}
