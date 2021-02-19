using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RecapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join cu in context.Customers
                             on r.CustomerId  equals cu.CustomerId
                             
                             select new RentalDetailDto { CarId=c.CarId, CustomerId= cu.CustomerId,RentDate=r.RentDate,ReturnDate=r.ReturnDate };

                return result.ToList();

            }
        }

    }
}
