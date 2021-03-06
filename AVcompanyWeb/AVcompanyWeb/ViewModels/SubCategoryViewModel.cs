﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AVcompanyWeb.Models;
using AVcompanyWeb.Repositories;
using AutoMapper;

namespace AVcompanyWeb.ViewModels
{
    public class SubCategoryViewModel
    {
        public int id { get; set; }
        public Nullable<int> categoryId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Nullable<bool> isActive { get; set; }

        public CategoryViewModel category { get; set; }


        public List<CategoryViewModel> categories { get; set; }

        private CategoryRepository categoryRepository;


        public void LoadData()
        {
            categoryRepository = new CategoryRepository();
            this.categories = (categoryRepository.FindBy(x => x.isActive == true).ToList()).Select(Mapper.Map<Category,CategoryViewModel>).ToList();
        }

    }
}