using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AVcompanyWeb.Models;
using AVcompanyWeb.ViewModels;
using AVcompanyWeb.Repositories;
using AutoMapper;
using AVcompanyWeb.Attributes;

namespace AVcompanyWeb.Controllers
{
    [SessionTimeout]
    public class SubCategoryController : Controller
    {


        private SubCategoryRepository subCategoryRepository;
        private CategoryRepository categoryRepository;

        public SubCategoryController()
        {
            subCategoryRepository = new SubCategoryRepository();
            categoryRepository = new CategoryRepository();
        }

        // GET: SubCategory
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            List<SubCategory> subCategories = subCategoryRepository.FindBy(x => x.isActive == true).ToList();
            List<SubCategoryViewModel> subCategoriesViewModel = subCategories.Select(Mapper.Map<SubCategory, SubCategoryViewModel>).ToList();


            return View(subCategoriesViewModel);
        }

        public JsonResult GetCategories()
        {
            List<Category> categories = categoryRepository.FindBy(x => x.isActive == true).ToList();
            List<CategoryViewModel> categoryViewModel = categories.Select(Mapper.Map<Category, CategoryViewModel>).ToList();

            return Json(categoryViewModel, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetSubCategory(int id)
        {
            SubCategory subCategory = subCategoryRepository.FindBy(x => x.isActive == true && x.id == id).FirstOrDefault();
            SubCategoryViewModel subCategoryViewModel = Mapper.Map<SubCategory, SubCategoryViewModel>(subCategory);
            subCategoryViewModel.LoadData();
            return Json(subCategoryViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(SubCategory subCategory)
        {
            subCategoryRepository.Edit(subCategory);
            subCategoryRepository.Save();
            return Json("Ok", JsonRequestBehavior.AllowGet);
        }


        public ActionResult Delete(int id)
        {
            SubCategory subCategory = subCategoryRepository.FindBy(x => x.id == id && x.isActive == true).FirstOrDefault();
            subCategory.isActive = false;
            subCategoryRepository.Edit(subCategory);
            subCategoryRepository.Save();

            return RedirectToAction("List", "SubCategory");
        }

        [HttpPost]
        public JsonResult Create(SubCategory subCategory)
        {

            subCategory.isActive = true;
            subCategoryRepository.Add(subCategory);
            subCategoryRepository.Save();
            return Json("Ok", JsonRequestBehavior.AllowGet);
        }

    }
}