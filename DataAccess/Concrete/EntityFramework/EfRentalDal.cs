using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Customers
                             join r in context.Rentals
                             on c.Id equals r.CustomerId
                             join cc in context.Cars
                             on r.CarId equals cc.Id
                             join b in context.Brands
                             on cc.BrandId equals b.Id
                             select new RentalDetailDto { UserName = c.CompanyName, BrandName = b.BrandName, CarDescription = cc.Description,
                                 RentDate = r.RentDate, ReturnDate = r.ReturnDate, RentPrice = r.RentPrice};
                return result.ToList();

                             
            }
        }
    }
}
