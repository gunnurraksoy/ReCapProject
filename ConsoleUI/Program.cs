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
            //ColorTest1();
            //ResultTest1();
            //ResultTest2();
            //Test1();
            //Test2();

        }

        private static void Test2()
        {
            ///////Marka adı 2 harften fazla olduğu içim ekleyecek ve eklediğine dağir mesaj verecek.
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.Add(new Brand { BrandName = "Honda" });
            Console.WriteLine(result.Message);
        }

        private static void Test1()
        {
            //////Araba ücreti 0 dan büyük olmadığı için eklemeyecek ve uyarı verecek.(Error)
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.Add(new Car { BrandId = 1, ColorId = 2, DailyPrice = -10, Description = "dizel", ModelYear = 2011 });
            Console.WriteLine(result.Message);
        }

        private static void ResultTest2()
        {

            ///// BAKIM SAATİNE DENK GELMEZSE TÜM ARABALARIN FİYATLARINI DÖNDÜRÜR, BAKIM ZAMANINA DENK GELİRSE MESAJ DÖNDÜRÜR
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ResultTest1()


        {
            //Arabaların hepsini joinlenmiş haliyle getir.(Resultun datasını dön)
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
            }

           
        }

        private static void ColorTest1()

        {

            //BAKIM SAATİNE DENK GELMEZSE TÜM RENKLERİN ADLARINI DÖNDÜRÜR, BAKIM ZAMANINA DENK GELİRSE MESAJ DÖNDÜRÜR
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            if (result.Success == true)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorName);
                }
            }

            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }

       

    
}
