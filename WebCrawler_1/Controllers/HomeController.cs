using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using WebCrawler_1.Data;
using WebCrawler_1.Models;

namespace WebCrawler_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebCrawler_1Context _repository;
        public HomeController(WebCrawler_1Context repository)
        {
            _repository = repository;
        }
        public IActionResult GetPage()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult GetUrl(GetUrl search)
        {
            var itemSearch = search.NewSearch;
            var itemName = search.ItemName;
            var newestPrice = search.ItemPrice;
            var getDate = DateTime.Today;
            search.Date = getDate;

            if (!(itemSearch.Contains(" ")))
            {
                string url = $"https://www.ebay.com/sch/i.html?_nkw={itemSearch}";

                var web = new HtmlWeb();
                var document = web.Load(url);

                var listingTitle = document.DocumentNode.Descendants("h3")
                     .Where(node => node.GetAttributeValue("class", "")
                 .Equals("s-item__title")).FirstOrDefault().GetDirectInnerText();

                var price = document.DocumentNode.Descendants("span")
                     .Where(node => node.GetAttributeValue("class", "")
                 .Equals("s-item__price")).FirstOrDefault().GetDirectInnerText();
                
                var idSet = search.NewSearch;

                if (listingTitle == null || price == null)
                {
                    return View("GetPage");
                }

                itemName = listingTitle.ToString();

                var itemPrice = price.ToString();
                var newItemPrice = itemPrice.Replace("$", "");
                decimal.TryParse(newItemPrice, out newestPrice);

                var theModel = new GetUrl
                {
                    ItemName = itemName,
                    ItemPrice = newestPrice,
                    NewSearch = itemSearch,
                    Date = getDate
                };
                var dbTable = _repository.GetUrls;

                var dataAdded = dbTable.Add(theModel);
                _repository.SaveChanges();

                return View(theModel);
            }
            else
            {
                var addPlus = itemSearch.Replace(" ", "+");

                var urlWithMultiple = $"https://www.ebay.com/sch/i.html?_nkw={addPlus}";

                var web = new HtmlWeb();
                var document = web.Load(urlWithMultiple);

                var listingTitle = document.DocumentNode.Descendants("h3")
                     .Where(node => node.GetAttributeValue("class", "")
                 .Equals("s-item__title")).FirstOrDefault().GetDirectInnerText();

                var price = document.DocumentNode.Descendants("span")
                     .Where(node => node.GetAttributeValue("class", "")
                 .Equals("s-item__price")).FirstOrDefault().GetDirectInnerText();
                
                if (listingTitle == null || price == null)
                {
                    return View("GetPage");
                }

                itemName = listingTitle.ToString();

                var itemPrice = price.ToString();
                var newItemPrice = itemPrice.Replace("$", "");
                decimal.TryParse(newItemPrice, out newestPrice);

                var theModel = new GetUrl
                {
                    ItemName = itemName,
                    ItemPrice = newestPrice,
                    NewSearch = itemSearch,
                    Date = getDate
                };
                var dbTable = _repository.GetUrls;

                var dataAdded = dbTable.Add(theModel);
                _repository.SaveChanges();
                

                return View(theModel);
            }

        }
        [HttpGet]
        public IActionResult SaveInfo(int key, GetUrl getUrl)
        {
            var viewInfo = _repository.GetUrls;

            return View(viewInfo);
        }
        
        public IActionResult Chart()
        {
            var chartInfo = new GetUrl();
            var viewInfo = _repository.GetUrls.Where(i => i.NewSearch == "xbox");

            return View(viewInfo);
        }
        //public IActionResult GetChart(Chart chart, GetUrl getUrl)
        //{
        //    var itemLookup = chart.VariableSearched;
        //    //var returnItem = ;
        //   var returnedItem = _repository.GetUrls.Where(s => s.NewSearch == itemLookup).Select(x => new { x.Date, x.ItemPrice }).ToList();
        //    return View("Chart", returnedItem);

        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

