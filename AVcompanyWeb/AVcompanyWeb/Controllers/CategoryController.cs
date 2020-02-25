using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AVcompanyWeb.Models;
using AVcompanyWeb.Repositories;
using AVcompanyWeb.ViewModels;
using AutoMapper;
using AVcompanyWeb.Attributes;

namespace AVcompanyWeb.Controllers
{
    [SessionTimeout]
    public class CategoryController : Controller
    {
        private CategoryRepository categoryRepository;

        public CategoryController()
        {
            this.categoryRepository = new CategoryRepository();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create(CategoryViewModel category)
        {
            Category categoryInsert = Mapper.Map<CategoryViewModel, Category>(category);
            categoryInsert.isActive = true;
            categoryInsert.quantity = 0;
            categoryRepository.Add(categoryInsert);
            categoryRepository.Save();
            return Json("Ok", JsonRequestBehavior.AllowGet);
        }


        public ActionResult List()
        {
            List<CategoryViewModel> categories = categoryRepository.FindBy(x => x.isActive == true).Select(Mapper.Map<Category, CategoryViewModel>).ToList();
            return View(categories);
        }


        public ActionResult _Create()
        {
            return PartialView("_Create");
        }

        [HttpGet]
        public JsonResult GetCategory(int id)
        {
            Category category = categoryRepository.FindBy(x => x.id == id && x.isActive == true).FirstOrDefault();
            CategoryViewModel categoryViewModel = Mapper.Map<Category, CategoryViewModel>(category);
            return Json(categoryViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(Category category)
        {
            categoryRepository.Edit(category);
            categoryRepository.Save();
            return Json("Ok", JsonRequestBehavior.AllowGet);
        }


        public ActionResult Delete(int id)
        {
            Category category = categoryRepository.FindBy(x => x.id == id && x.isActive == true).FirstOrDefault();
            category.isActive = false;
            categoryRepository.Edit(category);
            categoryRepository.Save();

            return RedirectToAction("List", "Category");
        }

    }
}