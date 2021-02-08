using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)

        {
            
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("CarId: " + car.CarId + " BrandId: " + car.BrandId + " ColorId: " + car.ColorId + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice + " Description: " + car.Description);
            }

            Console.WriteLine("-----------------------------------------------------------------------------------");


            // Veritabanına yeni bir araba ekleyelim ve ekledikten sonra veritabanaındaki tüm arabaları GetAll ile çekelim.
            InMemoryCarDal ınMemoryCarDal = new InMemoryCarDal();
            ınMemoryCarDal.Add(new Entities.Concrete.Car { CarId = 6,BrandId=3,ColorId=3,ModelYear=2011,DailyPrice=225,Description="benzin"});
            foreach (var car in ınMemoryCarDal.GetAll())
            {
                Console.WriteLine("CarId: " + car.CarId + " BrandId: " + car.BrandId + " ColorId: " + car.ColorId + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice + " Description: " + car.Description);

            }

            Console.WriteLine("-----------------------------------------------------------------------------------");
            

            //GetById metodu ile veritabanındaki 1 numaralı Id ye sahip olan arabanın tüm özelliklerini getirdik.
            foreach (var car in ınMemoryCarDal.GetById(1))
            {
                Console.WriteLine("CarId: " + car.CarId + " BrandId: " + car.BrandId + " ColorId: " + car.ColorId + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice + " Description: " + car.Description);
            }


        }


    }
}
