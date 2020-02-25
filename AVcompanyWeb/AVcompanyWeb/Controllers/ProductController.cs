using AVcompanyWeb.Models;
using AVcompanyWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AVcompanyWeb.ViewModels;
using AutoMapper;
using System.IO;
using AVcompanyWeb.Attributes;

namespace AVcompanyWeb.Controllers
{
    [SessionTimeout]
    public class ProductController : Controller
    {
        // GET: Product
        //private PriceTypeRepository priceTypeRepository;
        private ProductRepository productRepository;
        private SubCategoryRepository subCategoryRepository;
        private CategoryRepository categoryRepository;
        private UploadRepository uploadRepository;
        private PriceProductRepository priceProductRepository;
        private ParameterRepository parameterRepository;

        public ProductController()
        {
            // priceTypeRepository = new PriceTypeRepository();
            uploadRepository = new UploadRepository();
            productRepository = new ProductRepository();
            priceProductRepository = new PriceProductRepository();
            parameterRepository = new ParameterRepository();
            subCategoryRepository = new SubCategoryRepository();
            categoryRepository = new CategoryRepository();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<Product> products = productRepository.FindBy(x => x.isActive == true).ToList();
            return View(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Igv = Convert.ToDouble(parameterRepository.FindBy(x => x.name == "IGV").FirstOrDefault().value) + 1;
            //List<PriceType> model = new List<PriceType>();
            ProductViewModel model = new ProductViewModel();
            model.loadData();
            //model = priceTypeRepository.GetAll().ToList();
            return View(model);
        }

        [HttpPost]
        public JsonResult Save(ProductViewModel product)
        {
            try
            {
                product.isActive = true;
                productRepository = new ProductRepository();
                Product productEntity = Mapper.Map<Product>(product);
                productRepository.Add(productEntity);
                productRepository.Save();

                return Json(productEntity.id, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public JsonResult SaveProductPrices(List<PriceProduct> productPrices)
        {
            try
            {
                PriceProduct priceProduct = null;

                foreach (var item in productPrices)
                {
                    priceProduct = new PriceProduct();
                    priceProduct.productId = item.productId;
                    priceProduct.priceTypeId = item.priceTypeId;
                    priceProduct.priceWithoutIGV = item.priceWithoutIGV;
                    priceProduct.priceWithIGV = item.priceWithIGV;
                    priceProduct.isActive = true;

                    priceProductRepository.Add(priceProduct);
                }

                priceProductRepository.Save();
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
; }



        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {

            Product product = productRepository.FindBy(x => x.isActive == true).OrderByDescending(x => x.id).Take(1).Single();
            string fName = "";
            string fExtension = "";
            int numImages = 0;
            Upload upload;
            foreach (string fileName in Request.Files)
            {
                numImages++;
                HttpPostedFileBase file = Request.Files[fileName];
                fName = $"{product.identifierCode}-{numImages}";
                fExtension = Path.GetExtension(file.FileName);

                if (file != null && file.ContentLength > 0)
                {
                    string path = Server.MapPath("~/Uploads/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    file.SaveAs(path + fName + fExtension);

                    /*Save path on table Uploads*/
                    upload = new Upload();
                    upload.locationPath = path + fName + fExtension;
                    upload.name = fName;
                    upload.productId = product.id;
                    upload.isActive = true;
                    upload.srcImage = $"/Uploads/{fName}{fExtension}";


                    uploadRepository.Add(upload);
                    uploadRepository.Save();

                }
            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public JsonResult GetSubCategories(int categoryId)
        {
            subCategoryRepository = new SubCategoryRepository();
            var subCategories = subCategoryRepository.FindBy(x => x.categoryId == categoryId && x.isActive == true)
                .Select(e => new {
                    id = e.id,
                    name = e.name,
                    description = e.description,
                    categoryId = e.categoryId
                }).ToList();
            return Json(subCategories, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetIdentifierCode(int categoryId)
        {
            categoryRepository = new CategoryRepository();
            var category = categoryRepository.FindBy(x => x.id == categoryId && x.isActive == true).FirstOrDefault();
            string identifierCode = $"{category.abbreviation}{category.quantity + 1}";
            return Json(identifierCode, JsonRequestBehavior.AllowGet);
        }



        [HttpGet]
        public ActionResult Details(int id)
        {
            ViewBag.Igv = Convert.ToDouble(parameterRepository.FindBy(x => x.name == "IGV").FirstOrDefault().value) + 1;
            Product product = productRepository.FindBy(x => x.id == id && x.isActive == true).FirstOrDefault();
            ProductViewModel productViewModel = Mapper.Map<Product, ProductViewModel>(product);

            int? categoryId = subCategoryRepository.FindBy(x => x.id == productViewModel.subCategoryId && x.isActive == true).FirstOrDefault().categoryId;
            productViewModel.category = Mapper.Map<Category, CategoryViewModel>(categoryRepository.FindBy(x => x.id == categoryId && x.isActive == true).FirstOrDefault());

            productViewModel.loadData();
            productViewModel.uploads = uploadRepository.FindBy(x => x.productId == id && x.isActive == true).ToList();
            return View(productViewModel);
        }


        [HttpGet]
        public ActionResult _DetailsImage(ProductViewModel product)
        {
            return PartialView(product);
        }

        [HttpGet]
        public ActionResult _TechnicalDetail(ProductViewModel product)
        {
            return PartialView(product);
        }


        [HttpPost]
        public ActionResult DeleteFile(int uploadId)
        {

            Upload upload = uploadRepository.FindBy(x => x.id == uploadId && x.isActive == true).FirstOrDefault();

            string filePath = upload.locationPath;
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            /*delete from table Uploads*/
            upload.isActive = false;


            uploadRepository.Edit(upload);
            uploadRepository.Save();

            Product product = productRepository.FindBy(x => x.id == upload.productId && x.isActive == true).FirstOrDefault();
            ProductViewModel productViewModel = Mapper.Map<Product, ProductViewModel>(product);
            productViewModel.loadData();

            return PartialView("_DetailsImage", productViewModel);
        }


        [HttpGet]
        public ActionResult _ListProducts(List<Product> products)
        {
            return PartialView(products);
        }


        [HttpGet]
        public ActionResult Search(string text)
        {
            List<Product> products = new List<Product>();
            if (text.Equals(""))
            {
                products = productRepository.FindBy(x => x.isActive == true).ToList();
            }
            else {
                products = productRepository.FindBy(x => x.isActive == true &&
                (x.name.IndexOf(text) >= 0 || x.description.IndexOf(text) >= 0 || x.SubCategory.Category.name.IndexOf(text) >= 0)).ToList();

            }

            return PartialView("_ListProducts", products);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Product product = productRepository.FindBy(x => x.id == id && x.isActive == true).FirstOrDefault();
            uploadRepository.Context = productRepository.Context;


            //remove images associated with the product
            string filePath = "";

            foreach (var item in product.Uploads)
            {
                filePath = item.locationPath;

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                //upload logical delete
                item.isActive = false;
                uploadRepository.Edit(item);
                uploadRepository.Save();
            }

            //product logical delete
            product.isActive = false;
            productRepository.Edit(product);
            productRepository.Save();

            //return List of Product
            List<Product> products = productRepository.FindBy(x => x.isActive == true).ToList();

            return PartialView("_ListProducts", products);

        }


        [HttpPost]
        public ActionResult InsertFile(int productId)
        {
            int lastNumberUpload;
            string fName = "";
            string fExtension = "";
            Upload upload;

            Product product = productRepository.FindBy(x => x.id == productId && x.isActive == true).FirstOrDefault();
            HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            string lastUploadName = product.Uploads.OrderByDescending(x => x.id).FirstOrDefault().name;
            lastNumberUpload = Convert.ToInt32(lastUploadName.Substring(lastUploadName.Length - 1, 1));


            foreach (string fileName in files)
            {
                lastNumberUpload++;
                HttpPostedFile file = files[fileName];
                fName = $"{product.identifierCode}-{lastNumberUpload}";
                fExtension = Path.GetExtension(file.FileName);
                string path = Server.MapPath("~/Uploads/");
                if (file != null && file.ContentLength > 0)
                {
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    file.SaveAs(path + fName + fExtension);
                }

                upload = new Upload();
                upload.isActive = true;
                upload.productId = product.id;
                upload.locationPath = path + fName + fExtension;
                upload.srcImage = $"/Uploads/{fName}{fExtension}";
                upload.name = fName;

                uploadRepository.Add(upload);
                uploadRepository.Save();
            }

            productRepository = new ProductRepository();
            product = productRepository.FindBy(x => x.id == productId && x.isActive == true).FirstOrDefault();
            ProductViewModel productViewModel = Mapper.Map<Product, ProductViewModel>(product);
            productViewModel.loadData();


            return PartialView("_DetailsImage", productViewModel);
        }


        [HttpGet]
        public ActionResult _PriceDetails(ProductViewModel product)
        {
            return PartialView(product);
        }


        [HttpPost]
        public JsonResult UpdateProductPrices(List<PriceProduct> productPrices)
        {
            double igv = Convert.ToDouble(parameterRepository.FindBy(x => x.name == "IGV").FirstOrDefault().value) + 1;
            foreach (var item in productPrices)
            {
                item.priceWithIGV = item.priceWithoutIGV * igv;
                item.isActive = true;
                priceProductRepository.Edit(item);
            }
            priceProductRepository.Save();

            MessageViewModel message = new MessageViewModel();
            message.heading = "Operación Completada Satisfactoriamente.";
            message.text = "Se actualizaron los precios del producto.";
            message.position = "top-center";
            message.loaderBg = "#ff6849";
            message.icon = "info";
            message.hideAfter = 3000;
            message.stack = 6;

            return Json(message, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateTechnicalDetails(ProductViewModel productViewModel)
        {

            Product product = Mapper.Map<ProductViewModel, Product>(productViewModel);
            if ((bool)!product.isExclusive)
            {
                product.customerId = null;
            }

            product.isActive = true;
            productRepository.Edit(product);
            productRepository.Save();

            MessageViewModel message = new MessageViewModel();
            message.heading = "Operación Completada Satisfactoriamente.";
            message.text = "Se actualizó el producto con código " +  product.identifierCode + ".";
            message.position = "top-center";
            message.loaderBg = "#ff6849";
            message.icon = "info";
            message.hideAfter = 3000;
            message.stack = 6;
            return Json(message, JsonRequestBehavior.AllowGet);
        }
        
    }


    

}