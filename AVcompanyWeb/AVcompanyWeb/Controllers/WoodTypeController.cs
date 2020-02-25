using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AVcompanyWeb.Models;
using AVcompanyWeb.Repositories;
using AVcompanyWeb.Attributes;
using AVcompanyWeb.ViewModels;
using AutoMapper;

namespace AVcompanyWeb.Controllers
{
    [SessionTimeout]
    public class WoodTypeController : Controller
    {


        private WoodTypeRepository woodTypeRepository;
        // GET: WoodType

        public WoodTypeController()
        {
            woodTypeRepository = new WoodTypeRepository();
        }

        public ActionResult Index()
        {
            List<WoodType> woodTypes = woodTypeRepository.FindBy(x => x.isActive == true).ToList();
            return View(woodTypes);
        }

        public ActionResult Delete(int id)
        {
            WoodType woodType = woodTypeRepository.FindBy(x => x.id == id && x.isActive == true).FirstOrDefault();
            woodType.isActive = false;
            woodTypeRepository.Edit(woodType);
            woodTypeRepository.Save();

            return RedirectToAction("Index", "WoodType");
        }


        [HttpPost]
        public JsonResult Create(WoodType woodType)
        {
            woodTypeRepository.Add(woodType);
            woodTypeRepository.Save();
            return Json("Ok", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetWoodType(int id)
        {
            WoodType woodType = woodTypeRepository.FindBy(x => x.id == id && x.isActive == true).FirstOrDefault();
            WoodTypeViewModel woodTypeViewModel = Mapper.Map<WoodType, WoodTypeViewModel>(woodType);
            return Json(woodTypeViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(WoodType woodType)
        {
            woodTypeRepository.Edit(woodType);
            woodTypeRepository.Save();
            return Json("Ok", JsonRequestBehavior.AllowGet);
        }

    }
}