using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AVcompanyWeb.Models;
using AVcompanyWeb.ViewModels;
using AVcompanyWeb.Repositories;

namespace AVcompanyWeb.Controllers
{
    public class SubCategoryController : Controller
    {


        private SubCategoryRepository subCategoryRepository;

        public SubCategoryController()
        {
            subCategoryRepository = new SubCategoryRepository();
        }

        // GET: SubCategory
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            List<SubCategory> subCategories = subCategoryRepository.FindBy(x => x.isActive == true).ToList();
            return View(subCategories);
        }



    }
}