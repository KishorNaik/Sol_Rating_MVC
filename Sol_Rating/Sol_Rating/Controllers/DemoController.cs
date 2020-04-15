using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sol_Rating.Models;

namespace Sol_Rating.Controllers
{
    public class DemoController : Controller
    {

        public DemoController()
        {
            Products = new ProductModel();
        }

        [BindProperty]
        public ProductModel Products { get; set; }

        public IActionResult Index()
        {
            // Set Defualt Rating Value
            Products.Rating = 0;

            return View(Products);
        }

        public IActionResult OnSubmit()
        {
            // using Model
            // Note :get Rating Model using asp-for tag helper and name attribute in hidden value. 
            //<input id="hidRatingServerValue" type="hidden" asp-for="@Model.Rating.Model" name="@Model.Rating.Name" />
            int ratingServerValue = Products.Rating;

            // Or We can extract data from using Request.Form
            int ratingClientValue2 = Convert.ToInt32( HttpContext.Request.Form["hidRatingClientValue"][0]);

            return View("Index",Products);
        }
    }
}