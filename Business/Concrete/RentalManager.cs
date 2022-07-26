﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var result = _rentalDal.Get(r => r.Id == rental.Id);
            if (result.ReturnDate > DateTime.Now || result is null)
            {
                return new ErrorResult(Messages.CarRented);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);


        }

        public IResult Delete(Rental rental)
        {
            var result = _rentalDal.Get(r => r.Id == rental.Id);
            if (result is null)
            {
                return new ErrorResult(Messages.RentalNotFound);
            }
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);


        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            var result = _rentalDal.Get(r => r.Id == id);
            if (result is null)
            {
                return new ErrorDataResult<Rental>(Messages.RentalNotFound);
            }
            return new SuccessDataResult<Rental>(result, Messages.RentalListed);
            
        }

        public IDataResult<List<RentalDetailDto>> GetLeasedVehicles()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails().Where(r => r.ReturnDate > DateTime.Now).ToList());
            
        }

        public IDataResult<List<RentalDetailDto>> GetRentDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.RentalsListed);
        }

        public IResult Update(Rental rental)
        {
            var result = _rentalDal.Get(r => r.Id == rental.Id);
            if (result is null)
            {
                return new ErrorResult(Messages.RentalNotFound);
            }
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}