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


            CarManager carManager = new CarManager(new EfCarDal());
           
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            //////////////////////    Veritabanındaki tüm arabaları getirme:

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("CarId: " + car.CarId + " BrandId: " + car.BrandId + " ColorId: " + car.ColorId + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice + " Description: " + car.Description);
            }

            Console.WriteLine("-----------------------------------------------------------------------------------");



            //////////////////////7/BrandId lerine göre arabaları getirme:

            foreach (var car in carManager.GetCarsByBrandId(3))
            {
                Console.WriteLine("CarId: " + car.CarId + " BrandId: " + car.BrandId + " ColorId: " + car.ColorId + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice + " Description: " + car.Description);
            }

            Console.WriteLine("-----------------------------------------------------------------------------------");



            ///////////////////////ColorId lerine göre arabaları getirme:

            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine("CarId: " + car.CarId + " BrandId: " + car.BrandId + " ColorId: " + car.ColorId + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice + " Description: " + car.Description);
            }

            //////////////////////veritabanına ücreti 0 dan küçük araba eklersek :
            //carManager.Add(new Car {BrandId=1,ColorId=3,DailyPrice=-10,ModelYear=2012,Description="dizel"});

            brandManager.Add(new Brand { BrandName = "Toyota" });//Burada Toyota veritabanına yeni bir Brand(marka) olarak eklenir.
            brandManager.Add(new Brand { BrandName = "A" }); //Fakat burada (2 karakterden küçük olamaz) yazdırır ve veritabanına eklemez.


            
        }



        


    }
}
