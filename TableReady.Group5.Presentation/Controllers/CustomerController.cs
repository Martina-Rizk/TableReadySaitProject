/// <summary>
/// Customer Sign Up controller
/// Create new customer
/// Ckeck there is no registered customer with the same email before adding new account
/// Author: Martina Rizk
/// Date: August 7, 2020
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using TableReady.Group5.BLL;
using TableReady.Group5.Domain;

namespace TableReady.Group5.Presentation.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            try
            {
                CustomerManager.Add(customer);
                return RedirectToAction("Login", "HomePage");
            }
            catch
            {
                return View();
            }
        }
    }
}
