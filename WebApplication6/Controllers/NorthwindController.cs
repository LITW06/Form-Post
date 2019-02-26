using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class NorthwindController : Controller
    {
        public ActionResult SearchResults(int? minStock, int? maxStock)
        {
            NorthwindManager manager = new NorthwindManager(Properties.Settings.Default.ConStr);
            if (minStock == null)
            {
                minStock = 1;
            }

            if (maxStock == null)
            {
                maxStock = 20;
            }
            IEnumerable<Product> products = manager.GetProducts(minStock.Value, maxStock.Value);
            SearchResultsViewModel svm = new SearchResultsViewModel
            {
                Products = products,
                MinStock = minStock.Value,
                MaxStock = maxStock.Value
            };
            return View(svm);
        }
    }
}