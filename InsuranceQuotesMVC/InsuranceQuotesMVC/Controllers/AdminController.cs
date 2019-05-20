using InsuranceQuotesMVC.Models;
using InsuranceQuotesMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceQuotesMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()

        {
            using(CarInsuranceEntities db = new CarInsuranceEntities())
            {
                var quotes = db.Quotes;
                var quoteVms = new List<QuoteVm>();

                foreach (var quote in quotes)
                {
                    var quoteVm = new QuoteVm();

                    quoteVm.FirstName = quote.FirstName;
                    quoteVm.LastName = quote.LastName;
                    quoteVm.EmailAddress = quote.EmailAddress;
                    quoteVm.QuoteTotal = quote.QuoteTotal;
                    quoteVms.Add(quoteVm);
                }
                return View(quoteVms);
            }            
        }
    }
}