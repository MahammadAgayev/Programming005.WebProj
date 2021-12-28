using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Programming005.WebProj.DataAccessLayer.Abstraction;
using Programming005.WebProj.DataAccessLayer.Domain.Entities;
using Programming005.WebProj.Helpers.Abstraction;
using Programming005.WebProj.Models.Customers;
using System.Collections.Generic;

namespace Programming005.WebProj.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CustomersController : BaseController
    {
        private readonly IDatabaseLogHelper _databaseLogHelper;

        public CustomersController(IDatabase db, IDatabaseLogHelper databaseLogHelper) : base(db)
        {
            _databaseLogHelper = databaseLogHelper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //ViewBag.HeaderText = "Customers list";
            //ViewData["HeaderText2"] = "Customers list 2";

            //var message = TempData["Message"];
            //ViewBag.Message = message;

            ViewData["Message"] = "Message from viewdata, Hellooo";
            ViewBag.Message = "Message from viewbag, Hellooo"; //--> ViewData["Message"] = "Message from viewbag, Hellooo"

            var customers = DB.Get();

            var models = new List<CustomerModel>();
            foreach (var c in customers)
            {
                var model = new CustomerModel
                {
                    Id = c.Id,
                    Email = c.Email,
                    Firstname = c.Firstname,
                    Lastname = c.Lastname,
                    PhoneNumber = c.PhoneNumber
                };

                models.Add(model);
            }

            return View(models);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            var entity = new Customer
            {
                Email = model.Email,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                PhoneNumber = model.PhoneNumber
            };

            DB.Add(entity);

            TempData["Message"] = "Create successfully completed";
            //ViewBag.Message = "Create successfully completed";

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var entity = DB.Get(id);

            var model = new CustomerModel
            {
                Id = entity.Id,
                Email = entity.Email,
                Firstname = entity.Firstname,
                Lastname = entity.Lastname,
                PhoneNumber = entity.PhoneNumber
            };

            _databaseLogHelper.AddOpertionLog("Updated users data");

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(CustomerModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            var entity = DB.Get(model.Id);
            entity.Firstname = model.Firstname;
            entity.Lastname = model.Lastname;
            entity.Email = model.Email;
            entity.PhoneNumber = model.PhoneNumber;

            DB.Update(entity);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            DB.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
