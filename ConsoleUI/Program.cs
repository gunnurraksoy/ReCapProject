using Business.Concrete;
using Core.Entities.Concrete;
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
            //Test3();
            //UserAdd();
            //CustomerAdd();
            //RentalAddTest();
            //RentalGetAll();
            //RentalDetailTest();


            


        }

        private static void RentalDetailTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetRentalDetails();
            foreach (var rent in result.Data)
            {
                Console.WriteLine(rent.CarId + "/" + rent.CustomerId + "/" + rent.RentDate + "/" + rent.ReturnDate);
            }
        }

        private static void RentalGetAll()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetAll();
            foreach (var rental in result.Data)
            {
                Console.WriteLine(rental.RentDate);
            }
            Console.WriteLine(result.Message);
        }

        private static void RentalAddTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result1 = rentalManager.Add(new Rental
            {
                CarId = 2,
                CustomerId = 2,
                RentDate = new DateTime(2021, 02, 20),
                ReturnDate = new DateTime(2021, 01, 10)
            });
            Console.WriteLine(result1.Message);


            var result2 = rentalManager.Add(new Rental
            {
                CarId = 5,
                CustomerId = 3,
                RentDate = new DateTime(2021, 01, 20),
                ReturnDate = new DateTime(2021, 01, 28)
            });
            Console.WriteLine(result2.Message);

            var result3 = rentalManager.Add(new Rental
            {
                CarId = 4,
                CustomerId = 3,
                RentDate = new DateTime(2021, 01, 17),
                ReturnDate = new DateTime(2021, 01, 19)
            });
            Console.WriteLine(result3.Message);

            var result4 = rentalManager.Add(new Rental
            {
                CarId = 2,
                CustomerId = 2,
                RentDate = new DateTime(2021, 02, 20)
            });
            Console.WriteLine(result4.Message);


            var result5 = rentalManager.Add(new Rental
            {
                CarId = 2,
                CustomerId = 2,
                RentDate = new DateTime(2021, 01, 01)
            });
            Console.WriteLine(result5.Message);
        }

        private static void CustomerAdd()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Add(new Customer { UserId = 1, CompanyName = "Trendyol" });
            Console.WriteLine(result.Message);
            var result2 = customerManager.Add(new Customer { UserId = 2, CompanyName = "Defacto" });
            Console.WriteLine(result2.Message);
            var result3 = customerManager.Add(new Customer { UserId = 3, CompanyName = "LcWaikiki" });
            Console.WriteLine(result3.Message);
        }

        private static void UserAdd()
        {
            //UserManager userManager = new UserManager(new EfUserDal());
            //var result1 = userManager.Add(new User { FirstName = "Günnur", LastName = "Aksoy", Email = "gunnurraksoy@gmail.com", Password = "12345" });
            //Console.WriteLine(result1.Message);

            //var result2 = userManager.Add(new User { FirstName = "İrem", LastName = "Çoban", Email = "iremcoban@gmail.com", Password = "1515" });
            //Console.WriteLine(result2.Message);

            //var result3 = userManager.Add(new User { FirstName = "Gülsemin", LastName = "Aksoy", Email = "gülseminaksoy@gmail.com", Password = "78955" });
            //Console.WriteLine(result3.Message);

            //var result4 = userManager.Add(new User { FirstName = "Ahmet", LastName = "Arslan", Email = "ahmetarslan@gmail.com", Password = "030201" });
            //Console.WriteLine(result4.Message);
        }

        private static void Test3()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.GetAll();
            foreach (var user in result.Data)
            {
                Console.WriteLine(user.FirstName);
            }
            Console.WriteLine(result.Message);
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
