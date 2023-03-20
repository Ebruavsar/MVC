﻿using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm =new CategoryManager();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList() 
        {
            var categoryvalues = cm.GetAllBL();
            return View(categoryvalues);
        }
    }
}