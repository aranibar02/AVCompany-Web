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
    public class PriceTypeController : Controller
    {
        private PriceTypeRepository priceTypeRepository;


        public PriceTypeController()
        {
            priceTypeRepository = new PriceTypeRepository();
        }

        // GET: PriceType
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            List<PriceType> priceTypes = priceTypeRepository.FindBy(x => x.isActive == true).ToList();
            return View(priceTypes);
        }


        public ActionResult Delete(int id)
        {
            PriceType priceType = priceTypeRepository.FindBy(x => x.id == id && x.isActive == true).FirstOrDefault();
            priceType.isActive = false;
            priceTypeRepository.Edit(priceType);
            priceTypeRepository.Save();

            return RedirectToAction("List", "PriceType");
        }


        [HttpPost]
        public JsonResult Create(PriceType priceType)
        {
            priceTypeRepository.Add(priceType);
            priceTypeRepository.Save();
            return Json("Ok", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetPriceType(int id)
        {
            PriceType priceType = priceTypeRepository.FindBy(x => x.id == id && x.isActive == true).FirstOrDefault();
            PriceTypeViewModel priceTypeViewModel = Mapper.Map<PriceType, PriceTypeViewModel>(priceType);
            return Json(priceTypeViewModel, JsonRequestBehavior.AllowGet);
        }
        
       [HttpPost]
        public JsonResult Edit(PriceType priceType)
        {
            priceTypeRepository.Edit(priceType);
            priceTypeRepository.Save();
            return Json("Ok", JsonRequestBehavior.AllowGet);
        }

    }
}