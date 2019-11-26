using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using WebCrawler_1.Models;

namespace WebCrawler_1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult GetPage()
        {
            return View();
        }

        //srp-results srp-list clearfix

        public async Task<IActionResult> GetUrl(GetUrl search)
        {
            var httpClient = new HttpClient();

            var itemSearch = search.NewSearch;

            if (!(itemSearch.Contains(" ")))
            {
                string url = $"https://www.ebay.com/sch/i.html?_nkw={itemSearch}";
                
                var web = new HtmlWeb();
                var document = web.Load(url);

                var docNodes = document.DocumentNode.Descendants("ul")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("srp-results srp-list clearfix")).FirstOrDefault();

                var newDocs = docNodes.ChildNodes
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("s-item   ")).FirstOrDefault();

                return View(model: docNodes.InnerText);
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


                var newDocs = docNodes.ChildNodes
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("s-item   ")).FirstOrDefault();

                return View(model: newDocs.InnerText);
            }
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
