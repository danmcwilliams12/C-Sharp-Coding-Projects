using InsuranceQuotesMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceQuotesMVC.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetQuote(string firstName, string lastName, string emailAddress, DateTime dateOfBirth, int year, string make, string model, string dui, int speedingTickets, string coverageType )
        {
            //the base monthly premium
            decimal total = 50.00m;
            int age;
            //evaluates exact age based on what day of the year the user was born           
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
            {
                age = (DateTime.Now.Year - dateOfBirth.Year) - 1;
            }
            else
            {
                age = DateTime.Now.Year - dateOfBirth.Year;
            }

            //adds cost for high risk ages
            if (age < 25 && age > 18 || age > 100)
            {
                total += 25;
            }
            else if (age < 18)
            {
                total += 100;
            }

            //addition for older and newer cars
            if (year < 2000 || year > 2015)
            {
                total += 25;
            }

            //upcharge for Porsches
            if (make == "Porsche" && model == "911 Carrera")
            {
                total += 50;

            }
            else if (make == "Porsche")
            {
                total += 25;
            }

            //cost for speeding tickets          
                total += (speedingTickets * 10);
            
            // +25% for DUI
            if (dui == "Yes")
            {
                total *= 1.25m;
            }

            // +50% for full coverage
            if (coverageType == "Full")
            {
                total *= 1.50m;
            }
            decimal roundTotal = Math.Round(total, 2);
            //to pass to the view model
            var quotes = new List<Quote>();

            using (CarInsuranceEntities db = new CarInsuranceEntities())
            {
                var quote = new Quote();
                quote.FirstName = firstName;
                quote.LastName = lastName;
                quote.EmailAddress = emailAddress;
                quote.DateOfBirth = dateOfBirth;
                quote.Year = year;
                quote.Make = make;
                quote.Model = model;
                quote.DUI = dui;
                quote.SpeedingTickets = speedingTickets;
                quote.CoverageType = coverageType;
                quote.QuoteTotal = roundTotal;
                quotes.Add(quote);
                
                //update database
                db.Quotes.Add(quote);
                db.SaveChanges();                
            }
            //displays the quote
            return View("IssueQuote", quotes);
        }
    }
}