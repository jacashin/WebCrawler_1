using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using WebCrawler_1.Data;
using WebCrawler_1.Models;
using Dapper;
using System.Configuration;
using Quartz.Impl;
using Quartz;

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
        public IActionResult GetUrl(GetUrls search)
        {
            var itemSearch = search.NewSearch;
            var itemName = search.ItemName;
            var newestPrice = search.ItemPrice;
            var getDate = DateTime.Now;
            if (itemSearch == null)
            {
                return View();
            }
            else if (!(itemSearch.Contains(" ")))
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

                var theModel = new GetUrls
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
                 .Equals("s-item__title")).First().GetDirectInnerText();

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

                var theModel = new GetUrls
                {
                    ItemName = itemName,
                    ItemPrice = newestPrice,
                    NewSearch = itemSearch,
                    Date = getDate,
                };
                var dbTable = _repository.GetUrls;

                var dataAdded = dbTable.Add(theModel);
                _repository.SaveChanges();
                return View(theModel);
            }
        }
        [HttpGet]
        public IActionResult SaveInfo(int? id)
        {
            if (id != null)
            {
                var viewInfo = _repository.GetUrls.Where(x => x.ID == id).Select(x => new GetUrls()
                {
                    ItemName = x.ItemName,
                    ItemPrice = x.ItemPrice,
                    Date = x.Date,
                    NewSearch = x.NewSearch,
                    ID = x.ID
                }).ToList();
                return View(viewInfo);
            }
            else
            {
                var viewInfo = _repository.GetUrls;

                return View(viewInfo);
            }
        }
        [HttpPost]
        public IActionResult Chart(GetUrls getUrl)
        {

            var viewInfo = _repository.GetUrls.Where(i => i.NewSearch == getUrl.NewSearch);

            return View(viewInfo);
        }
        public IActionResult Timed(GetUrls search)
        {
            var itemSearch = search.NewSearch;
            var itemName = search.ItemName;
            var newestPrice = search.ItemPrice;
            var getDate = DateTime.Now;
            if (DateTime.Now.ToShortTimeString() == "12:18 AM")
            {
                string url = $"https://www.ebay.com/sch/i.html?_nkw=sefer+torah";

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

                var theModel = new GetUrls
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
            return null;
        }
        public IActionResult Index()
        {
            List<GetUrls> output = new List<GetUrls>();
            var sql = "select * from GetUrls where Id < 10";
            using (IDbConnection _db = new SqlConnection(@"Server=LAPTOP-GP0BMK15\SQLEXPRESS;Database=WebCrawler_1Context;Trusted_Connection=True"))
                output = _db.Query<GetUrls>(sql).ToList();

            return View(output);
        }
        [HttpPost]
        public /*List<GetUrls>*/IActionResult SaveInfo(GetUrls getUrl)
        {
            var removedItem = _repository.GetUrls.Find(getUrl);
            _repository.GetUrls.Remove(removedItem);
            _repository.SaveChanges();
            var a =  _repository.GetUrls.ToList();
            //RedirectToAction("SaveInfo");
            return View(a);

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
        [HttpGet]
        public IActionResult FindItemOnChart(GetUrls getUrl)
        {
            return View();
        }
        [HttpPost]
        public object CreateFile()
        {
            var viewInfo = _repository.GetUrls.Select(x => new
            {
                x.ID,
                x.ItemName,
                x.ItemPrice,
                x.Date
            }).ToList();

            string docPath =
              Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new(Path.Combine(docPath, "EbayPriceListTest.txt")))
            {
                foreach (var info in viewInfo)
                    outputFile.WriteLine(info);
            }
            return View("Index", docPath);
        }
        public static async Task Timer()
        {
            // Grab the Scheduler instance from the Factory
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();

            // and start it off
            await scheduler.Start();

            // some sleep to show what's happening
            await Task.Delay(TimeSpan.FromSeconds(10));

            // and last shut down the scheduler when you are ready to close your program
            await scheduler.Shutdown();
        }
    }
}

