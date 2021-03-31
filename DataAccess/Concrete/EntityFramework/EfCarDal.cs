using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RecapContext>, ICarDal

    {
        public List<CarDetailDto> GetByBrandDetails(int brandId)
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from c in context.Cars
                             where c.BrandId == brandId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 Id = c.CarId,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetByColorDetails(int colorId)
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from c in context.Cars
                             where c.ColorId == colorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 Id = c.CarId,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }


        public List<CarDetailDto> GetCarDetails()
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 Id = c.CarId,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }

        public List<CarDto> CarDto(Expression<Func<Car, bool>> filter = null)
        {
            using (RecapContext recapContext = new RecapContext())
            {
                IQueryable<CarDto>
                    carDetailsDtos = from car in filter is null ?
                                     recapContext.Cars : recapContext.Cars.Where(filter)
                                     join brand in recapContext.Brands
                                         on car.BrandId equals brand.BrandId
                                     join color in recapContext.Colors
                                         on car.ColorId equals color.ColorId
                                     select new CarDto
                                     {
                                         CarId = car.CarId,
                                         BrandName = brand.BrandName,
                                         ColorName = color.ColorName,
                                         ModelYear = car.ModelYear,
                                         DailyPrice = car.DailyPrice,
                                         Description = car.Description,
                                         ImagePath = recapContext.CarImages.Where(image => image.CarId == car.CarId).FirstOrDefault().ImagePath
                                     };
                return carDetailsDtos.ToList();
            }

        }
    }
}
