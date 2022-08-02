using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {

            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
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
