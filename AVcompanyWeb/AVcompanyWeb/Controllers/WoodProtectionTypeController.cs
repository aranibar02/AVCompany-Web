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
    public class WoodProtectionTypeController : Controller
    {

        private WoodProtectionTypeRepository woodProtectionTypeRepository;

        public WoodProtectionTypeController()
        {
            woodProtectionTypeRepository = new WoodProtectionTypeRepository();
        }
            // GET: WoodProtectionType
        public ActionResult List()
        {
            List<WoodProtectionType> woodProtectionTypes = woodProtectionTypeRepository.FindBy(x => x.isActive == true).ToList();
            return View(woodProtectionTypes);
        }

        public ActionResult Delete(int id)
        {
            WoodProtectionType woodProtectionType = woodProtectionTypeRepository.FindBy(x => x.id == id && x.isActive == true).FirstOrDefault();
            woodProtectionType.isActive = false;
            woodProtectionTypeRepository.Edit(woodProtectionType);
            woodProtectionTypeRepository.Save();

            return RedirectToAction("List", "WoodProtectionType");
        }


        [HttpPost]
        public JsonResult Create(WoodProtectionType woodProtectionType)
        {
            woodProtectionType.isActive = true;
            woodProtectionTypeRepository.Add(woodProtectionType);
            woodProtectionTypeRepository.Save();
            return Json("Ok", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetWoodProtectionType(int id)
        {
            WoodProtectionType woodProtectionType = woodProtectionTypeRepository.FindBy(x => x.id == id && x.isActive == true).FirstOrDefault();
            WoodProtectionTypeViewModel woodProtectionTypeViewModel = Mapper.Map<WoodProtectionType, WoodProtectionTypeViewModel>(woodProtectionType);
            return Json(woodProtectionTypeViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(WoodProtectionType woodProtectionType)
        {
            woodProtectionTypeRepository.Edit(woodProtectionType);
            woodProtectionTypeRepository.Save();
            return Json("Ok", JsonRequestBehavior.AllowGet);
        }

    }
}