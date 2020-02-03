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
            var dbData = new WebCrawler_1Context();

            var itemSearch = search.NewSearch;
            var itemName = search.ItemName;
            var newestPrice = search.ItemPrice;
            var getDate = DateTime.Now;
            search.Date = getDate;
                                             
            if (!(itemSearch.Contains(" ")))
            {
                string url = $"https://www.ebay.com/sch/i.html?_nkw={itemSearch}";
                
                var web = new HtmlWeb();
                var document = web.Load(url);

                var docNodes = document.DocumentNode.Descendants("ul")
                     .Where(node => node.GetAttributeValue("class", "")
                 .Equals("srp-results srp-list clearfix")).FirstOrDefault();

                var idSet = search.NewSearch;

                for (int i = 1; i < 7; i++)
                {
                    idSet = $"srp-river-results-listing{i}";
                }
                var newDocs = docNodes.ChildNodes
                     .Where(node => node.GetAttributeValue("id", "")
                     .Equals(idSet)).FirstOrDefault();

                if (newDocs == null)
                {
                    return View("GetPage");
                }

                var itemPrice_1 = newDocs.ChildNodes
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("s-item__wrapper clearfix")).FirstOrDefault();

                var itemPrice_2 = itemPrice_1.ChildNodes
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("s-item__info clearfix")).FirstOrDefault();

                var itemPrice_3 = itemPrice_2.ChildNodes
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("s-item__details clearfix")).FirstOrDefault();

                var itemPrice_4 = itemPrice_3.ChildNodes
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("s-item__detail s-item__detail--primary")).FirstOrDefault();

                var itemTitle = itemPrice_2.ChildNodes
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("s-item__link")).FirstOrDefault();

                var itemTitle_1 = itemTitle.ChildNodes
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("s-item__title")).FirstOrDefault();

                itemName = itemTitle_1.InnerText.ToString();

                var itemPrice = itemPrice_4.InnerText.ToString();
                var newItemPrice = itemPrice.Replace("$", "");
                decimal.TryParse(newItemPrice, out newestPrice);

                var theModel = new GetUrl
                {
                    ItemName = itemName,
                    ItemPrice = newestPrice,
                    NewSearch = itemSearch,
                    Date = getDate
                };
                var qwerty = _repository.GetUrls;

                var dataAdded = qwerty.Add(theModel);
                _repository.SaveChanges();

                return View(theModel);
            } 
            else
            {               
                var addPlus = itemSearch.Replace(" ", "+");

                var urlWithMultiple = $"https://www.ebay.com/sch/i.html?_nkw={addPlus}";

                var web = new HtmlWeb();
                var document = web.Load(urlWithMultiple);

                var docNodes = document.DocumentNode.Descendants("ul")
                    .Where(node => node.GetAttributeValue("class", "")
                .Equals("srp-results srp-list clearfix")).FirstOrDefault();

                var idSet = search.NewSearch;

                for (int i = 1; i < 7; i++)
                {
                    idSet = $"srp-river-results-listing{i}";                   
                }
                var newDocs = docNodes.ChildNodes
                     .Where(node => node.GetAttributeValue("id", "")
                     .Equals(idSet)).FirstOrDefault();

                if (newDocs == null)
                {
                    return View("GetPage");
                }

                var itemPrice_1 = newDocs.ChildNodes
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("s-item__wrapper clearfix")).FirstOrDefault();

                var itemPrice_2 = itemPrice_1.ChildNodes
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("s-item__info clearfix")).FirstOrDefault();

                var itemPrice_3 = itemPrice_2.ChildNodes
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("s-item__details clearfix")).FirstOrDefault();

                var itemPrice_4 = itemPrice_3.ChildNodes
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("s-item__detail s-item__detail--primary")).FirstOrDefault();

                var itemTitle = itemPrice_2.ChildNodes
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("s-item__link")).FirstOrDefault();

                var itemTitle_1 = itemTitle.ChildNodes
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("s-item__title")).FirstOrDefault();

                itemName = itemTitle_1.InnerText.ToString();

                var itemPrice = itemPrice_4.InnerText.ToString();

                var newItemPrice = itemPrice.Replace("$", "");

                decimal.TryParse(newItemPrice, out newestPrice);

                var theModel = new GetUrl
                {
                    ItemName = itemName,
                    ItemPrice = newestPrice,
                    NewSearch = itemSearch,
                    Date = getDate
                };
                var qwerty = _repository.GetUrls;

                var dataAdded = qwerty.Add(theModel);
                _repository.SaveChanges();

                return View(theModel);
            }

        }
        //[HttpPost]
        public IActionResult SaveInfo(GetUrl search)
        {
            //    if (!(ModelState.IsValid))
            //    {
            //        return View("Index");
            //    }
            //    _repository.Add(search);


            //    //_repository.Add(search.ItemName);
            //    //_repository.Add(search.ItemPrice);
            //    //_repository.Add(search.Date);
            //    //_repository.Add(search.NewSearch);

            //    _repository.SaveChanges();
            return View();
        }

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
