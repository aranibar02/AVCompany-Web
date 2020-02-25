using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AVcompanyWeb.Models;
using AVcompanyWeb.Repositories;

namespace AVcompanyWeb.ViewModels
{
    public class ProductViewModel
    {
        public int id { get; set; }
        public Nullable<int> woodTypeId { get; set; }
        //public Nullable<int> categoryId { get;set; }
        public Nullable<int> subCategoryId { get; set; }
        public Nullable<int> woodProtectionTypeId { get; set; }
        public Nullable<int> customerId { get; set; }
        public string identifierCode { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Nullable<double> width { get; set; }
        public Nullable<double> height { get; set; }
        public Nullable<double> depth { get; set; }
        public Nullable<double> weight { get; set; }
        public Nullable<int> stock { get; set; }
        public Nullable<double> manufacturingTime { get; set; }
        public Nullable<bool> isExclusive { get; set; }
        public Nullable<bool> isActive { get; set; }

        public CategoryViewModel category { get; set; }
        public SubCategoryViewModel subCategory { get; set; }

        /*data required for the form*/
        public List<WoodType> woodTypes { get; set; }
        public List<Category> categories { get; set; }
        //public List<SubCategory> subCategories { get; set; }
        public List<WoodProtectionType> woodProtectionTypes { get; set; }
        public List<Upload> uploads { get; set; }
        public List<PriceType> priceTypes { get; set;}
        public List<PriceProduct> priceProducts { get; set; }
        public List<Customer> customers { get; set; }
        /**/

        /**required repositories**/
        private WoodTypeRepository woodTypeRepository;
        private CategoryRepository categoryRepository;
        private WoodProtectionTypeRepository woodProtectionTypeRepository;
        private PriceTypeRepository priceTypeRepository;
        private CustomerRepository customerRepository;
        /**/

        public void loadData()
        {
            woodTypeRepository = new WoodTypeRepository();
            categoryRepository = new CategoryRepository();
            woodProtectionTypeRepository = new WoodProtectionTypeRepository();
            priceTypeRepository = new PriceTypeRepository();
            customerRepository = new CustomerRepository();

            this.categories = categoryRepository.FindBy(x => x.isActive == true).ToList();
            this.woodTypes = woodTypeRepository.FindBy(x => x.isActive == true).ToList();
            this.woodProtectionTypes = woodProtectionTypeRepository.FindBy(x => x.isActive == true).ToList();
            this.priceTypes = priceTypeRepository.FindBy(x => x.isActive == true).ToList();
            this.customers = customerRepository.FindBy(x => x.isActive == true).ToList();
        }



    }
}