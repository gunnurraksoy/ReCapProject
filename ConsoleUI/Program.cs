using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)

        {
            //CarTest1();
            //CarTest2();
            //BrandTest1();
            //ColorTest1();


            //join ile yapılan kodun testi:

            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName+"/" +car.BrandName+"/"+car.ColorName+"/"+car.DailyPrice);
            }

        }

        private static void ColorTest1()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var car in colorManager.GetAll())
            {
                Console.WriteLine(car.ColorName);


            }
        }

        private static void BrandTest1()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var car in brandManager.GetAll())
            {
                Console.WriteLine(car.BrandName);


            }
        }

        private static void CarTest2()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine((carManager.GetById(7)).DailyPrice);
        }

        private static void CarTest1()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ColorId);


            }
        }





    }
}
