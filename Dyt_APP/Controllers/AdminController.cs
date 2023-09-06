using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dyt_APP.Models.Classes;

namespace Dyt_APP.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin (blogları listeleme)

        Context contextAdmin = new Context();
        ClientEnumerable ce=new ClientEnumerable();
        [Authorize]
        public ActionResult Index()
        {
            var values = contextAdmin.Clients.Where(x => x.Station == Station.Active).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewClient()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewClient(Client c)
        {
            contextAdmin.Clients.Add(c);
            contextAdmin.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteClient(int id)
        {
            var findedClient = contextAdmin.Clients.Find(id);
            contextAdmin.Clients.Remove(findedClient);
            contextAdmin.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetClient(int id)
        {
            var findedClient = contextAdmin.Clients.Find(id);
            return View("GetClient", findedClient);
        }
        public ActionResult UpdateClient(Client c)
        {
            var findedClient = contextAdmin.Clients.Find(c.ID);
            findedClient.Name=c.Name;
            findedClient.Surname=c.Surname;
            findedClient.Age=c.Age;
            findedClient.Gender=c.Gender;
            findedClient.Weight=c.Weight;
            findedClient.Height=c.Height;
            findedClient.Phone=c.Phone;
            findedClient.Station=c.Station;
            findedClient.Date=DateTime.Now;
            contextAdmin.SaveChanges();
            return RedirectToAction("Index");
        }

        //tüm müşteriler
        public ActionResult ListClient()
        {
            var values = contextAdmin.Clients.ToList();
            return View(values);
        }

        public ActionResult ClientDetail(int id)
        {
            var bmiList = contextAdmin.BMIs.Where(b => b.ClientId == id).ToList();
            var findedClient = contextAdmin.Clients.Find(id);
            ViewBag.Name = findedClient.Name;
            ViewBag.Surname = findedClient.Surname;
            ViewBag.Age = findedClient.Age;
            return View("ClientDetail",bmiList);
        }
   
        
        public ActionResult CalculateBMI(int id)
        {
            var findedClient = contextAdmin.Clients.Find(id);
            var bmiList = contextAdmin.BMIs.Where(b => b.ClientId == id).ToList();
            ViewBag.BMIList = bmiList;
            var genders = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "Erkek" },
                new SelectListItem { Value = "1", Text = "Kadın" }
            }, "Value", "Text", findedClient.Gender.ToString());
            ViewBag.Gender = genders;
            return View("CalculateBMI", findedClient);
        }

        [HttpPost]
        public ActionResult CalculateBMI(int id, Gender gender, int age, double weight, double height,Client c)
        {   
            var findClient = contextAdmin.Clients.Find(c.ID);
            var bmiList = contextAdmin.BMIs.Where(b => b.ClientId == id).ToList();
            ViewBag.BMIList = bmiList;
            var genders = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "Erkek" },
                new SelectListItem { Value = "1", Text = "Kadın" }
            }, "Value", "Text", findClient.Gender.ToString());
            ViewBag.Gender = genders;
            
            if (ModelState.IsValid)
            {
                double bmi = weight / (height * height);
                double minBmi = 0;
                double maxBmi = 0;
                double MinBMI = 0;
                double MaxBMI = 0;
                double IdealWeight = 0;

                if (age >= 19 && age <= 24)
                {
                    if (gender == Gender.Female)
                    {
                        minBmi = 18;
                        maxBmi = 23;

                        MinBMI = minBmi * (height * height);
                        MaxBMI = maxBmi * (height * height);
                        IdealWeight = 20 * (height * height);
                    }
                    else if (gender == Gender.Male)
                    {
                        minBmi = 19;
                        maxBmi = 24;
                        MinBMI = minBmi * (height * height);
                        MaxBMI = maxBmi * (height * height);
                        IdealWeight = 21 * (height * height);
                    }

                }
                else if (age >= 25 && age <= 34)
                {
                    if (gender == Gender.Female)
                    {
                        minBmi = 19;
                        maxBmi = 24;
                        MinBMI = minBmi * (height * height);
                        MaxBMI = maxBmi * (height * height);
                        IdealWeight = 21 * (height * height);
                    }
                    else if (gender == Gender.Male)
                    {
                        minBmi = 20;
                        maxBmi = 25;
                        MinBMI = minBmi * (height * height);
                        MaxBMI = maxBmi * (height * height);
                        IdealWeight = 22 * (height * height);
                    }

                }
                else if (age >= 35 && age <= 44)
                {
                    if (gender == Gender.Female)
                    {
                        minBmi = 20;
                        maxBmi = 25;
                        MinBMI = minBmi * (height * height);
                        MaxBMI = maxBmi * (height * height);
                        IdealWeight = 22 * (height * height);

                    }
                    else if (gender == Gender.Male)
                    {
                        minBmi = 21;
                        maxBmi = 26;
                        MinBMI = minBmi * (height * height);
                        MaxBMI = maxBmi * (height * height);
                        IdealWeight = 23 * (height * height);

                    }

                }
                else if (age >= 45 && age <= 54)
                {
                    if (gender == Gender.Female)
                    {
                        minBmi = 21;
                        maxBmi = 26;
                        MinBMI = minBmi * (height * height);
                        MaxBMI = maxBmi * (height * height);
                        IdealWeight = 23 * (height * height);

                    }
                    else if (gender == Gender.Male)
                    {
                        minBmi = 22;
                        maxBmi = 27;
                        MinBMI = minBmi * (height * height);
                        MaxBMI = maxBmi * (height * height);
                        IdealWeight = 24 * (height * height);

                    }

                }
                else if (age >= 55 && age <= 64)
                {
                    if (gender == Gender.Female)
                    {
                        minBmi = 22;
                        maxBmi = 27;
                        MinBMI = minBmi * (height * height);
                        MaxBMI = maxBmi * (height * height);
                        IdealWeight = 24 * (height * height);

                    }
                    else if (gender == Gender.Male)
                    {
                        minBmi = 23;
                        maxBmi = 28;
                        MinBMI = minBmi * (height * height);
                        MaxBMI = maxBmi * (height * height);
                        IdealWeight = 25 * (height * height);

                    }

                }
                else if (age >= 65)
                {
                    if (gender == Gender.Female)
                    {
                        minBmi = 23;
                        maxBmi = 28;
                        MinBMI = minBmi * (height * height);
                        MaxBMI = maxBmi * (height * height);
                        IdealWeight = 25 * (height * height);

                    }
                    else if (gender == Gender.Male)
                    {
                        minBmi = 24;
                        maxBmi = 29;
                        MinBMI = minBmi * (height * height);
                        MaxBMI = maxBmi * (height * height);
                        IdealWeight = 26 * (height * height);

                    }
                }
                
                ViewBag.BMI = bmi;
                ViewBag.MinBMI = MinBMI;
                ViewBag.MaxBMI = MaxBMI;
                ViewBag.IdealWeight = IdealWeight;
                ViewBag.Weight = weight;
                ViewBag.FatMass = c.BMI.FatMass;
                ViewBag.MuscleMass = c.BMI.MuscleMass;
                ViewBag.BoneMass = c.BMI.BoneMass;
                ViewBag.LiquidMass = c.BMI.LiquidMass;
                ViewBag.InnerFat = c.BMI.InnerFat;
                ViewBag.Kcal = c.BMI.Kcal;
                ViewBag.MetabolicAge = c.BMI.MetabolicAge;
                if (findClient != null)
                {
                    var newBMI = new BMI
                    {
                     
                        MaxBMI = MaxBMI,
                        Weight=weight,
                        MinBMI = MinBMI,
                        BmiCalculation = bmi,
                        IdealWeight = IdealWeight,
                        CalculationDate = DateTime.Now,
                        ClientId = c.ID,
                        FatMass = c.BMI.FatMass,
                        MuscleMass = c.BMI.MuscleMass,
                        BoneMass = c.BMI.BoneMass,
                        LiquidMass = c.BMI.LiquidMass,
                        InnerFat = c.BMI.InnerFat,
                        Kcal = c.BMI.Kcal,
                        MetabolicAge = c.BMI.MetabolicAge
                    };

                    contextAdmin.BMIs.Add(newBMI);
                    contextAdmin.SaveChanges();
                }
   
                return View("CalculateBMI", findClient);
                //return View("AddBMI", new { MaxBMI= MaxBMI, MinBMI= MinBMI, IdealWeight= IdealWeight, weight = weight, height = height });
            }
            else
            {
                return View();
            }
        }

        public ActionResult MainCalculateBMI()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MainCalculateBMI(Gender gender, int age, double weight, double height)
        {
            // BMI hesaplama kodunu burada kullanın
            double bmi = weight / (height * height);

            ViewBag.BMI = bmi;
            double minBmi = 0;
            double maxBmi = 0;
            double MinBMI = 0;
            double MaxBMI = 0;
            double IdealWeight = 0;

            if (age >= 19 && age <= 24)
            {
                if (gender == Gender.Female)
                {
                    minBmi = 18;
                    maxBmi = 23;

                    ViewBag.MinBMI = minBmi * (height * height);
                    ViewBag.MaxBMI = maxBmi * (height * height);
                    ViewBag.IdealWeight = 20 * (height * height);
                }
                else if (gender == Gender.Male)
                {
                    minBmi = 19;
                    maxBmi = 24;
                    ViewBag.MinBMI = minBmi * (height * height);
                    ViewBag.MaxBMI = maxBmi * (height * height);
                    ViewBag.IdealWeight = 21 * (height * height);
                }

            }
            else if (age >= 25 && age <= 34)
            {
                if (gender == Gender.Female)
                {
                    minBmi = 19;
                    maxBmi = 24;
                    ViewBag.MinBMI = minBmi * (height * height);
                    ViewBag.MaxBMI = maxBmi * (height * height);
                    ViewBag.IdealWeight = 21 * (height * height);
                }
                else if (gender == Gender.Male)
                {
                    minBmi = 20;
                    maxBmi = 25;
                    ViewBag.MinBMI = minBmi * (height * height);
                    ViewBag.MaxBMI = maxBmi * (height * height);
                    ViewBag.IdealWeight = 22 * (height * height);
                }

            }
            else if (age >= 35 && age <= 44)
            {
                if (gender == Gender.Female)
                {
                    minBmi = 20;
                    maxBmi = 25;
                    ViewBag.MinBMI = minBmi * (height * height);
                    ViewBag.MaxBMI = maxBmi * (height * height);
                    ViewBag.IdealWeight = 22 * (height * height);

                }
                else if (gender == Gender.Male)
                {
                    minBmi = 21;
                    maxBmi = 26;
                    ViewBag.MinBMI = minBmi * (height * height);
                    ViewBag.MaxBMI = maxBmi * (height * height);
                    ViewBag.IdealWeight = 23 * (height * height);

                }

            }
            else if (age >= 45 && age <= 54)
            {
                if (gender == Gender.Female)
                {
                    minBmi = 21;
                    maxBmi = 26;
                    ViewBag.MinBMI = minBmi * (height * height);
                    ViewBag.MaxBMI = maxBmi * (height * height);
                    ViewBag.IdealWeight = 23 * (height * height);

                }
                else if (gender == Gender.Male)
                {
                    minBmi = 22;
                    maxBmi = 27;
                    ViewBag.MinBMI = minBmi * (height * height);
                    ViewBag.MaxBMI = maxBmi * (height * height);
                    ViewBag.IdealWeight = 24 * (height * height);

                }

            }
            else if (age >= 55 && age <= 64)
            {
                if (gender == Gender.Female)
                {
                    minBmi = 22;
                    maxBmi = 27;
                    ViewBag.MinBMI = minBmi * (height * height);
                    ViewBag.MaxBMI = maxBmi * (height * height);
                    ViewBag.IdealWeight = 24 * (height * height);

                }
                else if (gender == Gender.Male)
                {
                    minBmi = 23;
                    maxBmi = 28;
                    ViewBag.MinBMI = minBmi * (height * height);
                    ViewBag.MaxBMI = maxBmi * (height * height);
                    ViewBag.IdealWeight = 25 * (height * height);

                }

            }
            else if (age >= 65)
            {
                if (gender == Gender.Female)
                {
                    minBmi = 23;
                    maxBmi = 28;
                    ViewBag.MinBMI = minBmi * (height * height);
                    ViewBag.MaxBMI = maxBmi * (height * height);
                    ViewBag.IdealWeight = 25 * (height * height);

                }
                else if (gender == Gender.Male)
                {
                    minBmi = 24;
                    maxBmi = 29;
                    ViewBag.MinBMI = minBmi * (height * height);
                    ViewBag.MaxBMI = maxBmi * (height * height);
                    ViewBag.IdealWeight = 26 * (height * height);

                }
            }

            return View();
        }

        /*
        [HttpPost]
        public ActionResult AddBMI(int clientId,double maxBmi, double minBmi, double idealWeight, double weight, double height)
        {
            var client = contextAdmin.Clients.Find(clientId);

            if (client != null)
            {
                double bmi = weight / (height * height);

                var newBMI = new BMI
                {
                    MaxBMI = maxBmi,
                    MinBMI = minBmi,
                    BmiCalculation = bmi,
                    IdealWeight = idealWeight,
                    CalculationDate = DateTime.Now,
                    ClientId = client.ID
                };

                contextAdmin.BMIs.Add(newBMI);
                contextAdmin.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        */

    }
}