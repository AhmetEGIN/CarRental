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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length<2)
            {
                return new ErrorResult(Messages.CheckBrandData);
            }
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);

        }

        public IResult Delete(Brand brand)
        {
            var result = _brandDal.Get(c => c.Id == brand.Id);
            if (result is null)
            {
                return new ErrorResult(Messages.BrandNotFound);
            }
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);


        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.BrandListed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            var result = _brandDal.Get(b => b.Id == id);
            if (result is null)
            {
                return new ErrorDataResult<Brand>(Messages.BrandNotFound);
            }
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == id));

        }

        public IResult Update(Brand brand)
        {
            var result = _brandDal.Get(b => b.Id == brand.Id);
            if (result is null)
            {
                return new ErrorResult(Messages.BrandNotFound);
            }
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);

        }
    }
}
