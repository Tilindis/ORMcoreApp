using Microsoft.EntityFrameworkCore;
using ORMcoreApp.DataAcces;
using ORMcoreApp.Models;
using System;
using System.Linq;

namespace ORMcoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PoliceManContent policeManContext = new PoliceManContent();

            var pareigunas = new Pareigunas();

            //Create

            //policeManContext.uzduociuListai.Add(new UzduociuListas()
            //{
            //    day = DateTime.Now,
            //    Frequency = 4,
            //    pareigunasId = 3,
            //    uzduotis = policeManContext.Uzduotys.FirstOrDefault(u => u.Id == 3)

            //});

            //policeManContext.skirtinguDienuAutomobiliai.Add(new DienosAutomobilis()
            //{
            //    day = DateTime.Now,
            //    pareigunas = policeManContext.pareigunai.FirstOrDefault(p => p.Id == 2),
            //    automobilis = policeManContext.automobiliai.FirstOrDefault(a => a.Id == 2)
            //});

            //policeManContext.ginklai.Add(new Ginklas()
            //{
            //    GunName = "Colt",
            //    GunModel = "B-41",
            //    GunID = 10012
            //});

            //policeManContext.automobiliai.Add(new Automobilis()
            //{
            //    CarModel = "A4",
            //    CarMake = "Audi",
            //    Passengers = 5,
            //    VinId = "AudiA300000000122"
            //});

            //policeManContext.SaveChanges();

            policeManContext.automobiliai.Load();

            //Delete 
            //policeManContext.automobiliai.Remove(policeManContext.automobiliai.FirstOrDefault(a => a.Id == 7));

            //foreach (var item in Cars)
            //{
            //    Console.WriteLine("Item id: " + item.Id + " VIN: " + item.VinId + " Make: " + item.CarMake + "Model: " + item.CarModel + " Passengers: " + item.Passengers);
            //}

            //Cars.RemoveAll(c => c.Id == 6);

            

            //Update 

            //var gunList0 = policeManContext.ginklai.Where(c => c.Id == 1).ToList();
            //gunList0.ForEach(c => c.GunID = 10022);
            //policeManContext.SaveChanges();
            //var pareigunasWithOutGun = policeManContext.pareigunai.Where(c => c.ginklasId == 3).ToList();
            //pareigunasWithOutGun.ForEach(c => c.ginklas = policeManContext.ginklai.FirstOrDefault(g => g.GunID == 3));



            policeManContext.pareigunai.Load();
            
            policeManContext.Uzduotys.Load();
            policeManContext.ginklai.Load();



            //Read To List

            Console.WriteLine("Ginklai:");
            var guns = policeManContext.ginklai;
            foreach (var item in guns)
            {
                Console.WriteLine("id: " + item.Id + "Name: " + item.GunName + "Model: " + item.GunModel + " Reg. id: " + item.GunID);
            }

            //Console.WriteLine("Automobiliai");
            //var CarsList = policeManContext.automobiliai;

            //foreach (var item in CarsList)
            //{
            //    Console.WriteLine("Item id: " + item.Id + " VIN: " + item.VinId + " Make: " + item.CarMake + "Model: " + item.CarModel + " Passengers: " + item.Passengers);
            //}

            //Console.WriteLine("Uzduotys");
            //var Tasks = policeManContext.Uzduotys;

            //foreach (var item in Tasks)
            //{
            //    Console.WriteLine("Item id: " + item.Id + "Title: " + item.Title + "Description: " + item.Description);
            //}

            //Console.WriteLine("Pareigunai");
            //var Officers = policeManContext.pareigunai;

            //foreach (var item in Officers)
            //{
            //    Console.WriteLine("Item id: " + item.Id + " Name: " + item.Name + " LastName: " + item.LastName + " Unit: " + item.Unit + " Role: " + item.Role + " Gun id: " + item.ginklas.Id + " " + item.ginklas.GunModel);
            //}

            //Console.WriteLine("Uzduociu listas");
            //var TasksList = policeManContext.uzduociuListai;

            //foreach (var item in TasksList)
            //{
            //    Console.WriteLine("Item id: " + item.Id + " Day: " + item.day.Month + ":" + item.day.Day + " Frequency: " + item.Frequency + " OfficerID: " + item.pareigunasId + " uzduotis: " + item.uzduotis.Title);
            //}

            //Console.WriteLine("Prikisrtas automobilis");
            //var DienosAutomobiliai = policeManContext.skirtinguDienuAutomobiliai.ToList();

            //foreach (var item in DienosAutomobiliai)
            //{
            //    Console.WriteLine("Item id: " + item.Id + " Day: " + item.day.Month + ":" + item.day.Day + " Pareigunas: " + item.pareigunas.Id + " " + item.pareigunas.LastName + " Car: " + item.automobilis.Id + " " + item.automobilis.CarModel);
            //}

            Console.WriteLine("Hello World!");

            Console.ReadLine();
        }
    }
}
