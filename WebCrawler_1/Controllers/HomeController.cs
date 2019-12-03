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

        public IActionResult GetUrl(GetUrl search)
        {
            var itemSearch = search.NewSearch;
            var itemName = search.ItemName;
            var itemPrice = search.ItemPrice;

            if (!(itemSearch.Contains(" ")))
            {
                string url = $"https://www.ebay.com/sch/i.html?_nkw={itemSearch}";
                
                var web = new HtmlWeb();
                var document = web.Load(url);

                var docNodes = document.DocumentNode.Descendants("ul")
                     .Where(node => node.GetAttributeValue("class", "")
                 .Equals("srp-results srp-list clearfix")).FirstOrDefault();

                var idSet = search.NewSearch;

                for (int i = 1; i < 10; i++)
                {
                    idSet = $"srp-river-results-listing{i}";
                }
                var newDocs = docNodes.ChildNodes
                     .Where(node => node.GetAttributeValue("id", "")
                     .Equals(idSet)).FirstOrDefault();

                var itemPrice_1 = newDocs.ChildNodes
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("s-item__wrapper clearfix")).FirstOrDefault();

                var itemPrice_2 = itemPrice_1.ChildNodes
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("s-item__info clearfix")).FirstOrDefault();

                var itemTitle = itemPrice_2.ChildNodes
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("s-item__link")).FirstOrDefault();

                var itemTitle_1 = itemTitle.ChildNodes
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("s-item__title")).FirstOrDefault();

                var itemPrice_3 = itemPrice_2.ChildNodes
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("s-item__details clearfix")).FirstOrDefault();

                var itemPrice_4 = itemPrice_3.ChildNodes
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("s-item__detail s-item__detail--primary")).FirstOrDefault();
               
                itemName = itemTitle_1.InnerText.ToString();

                int.TryParse(itemPrice_4.InnerText.ToString(), out itemPrice);
                // needs to be able to pass both, check this out? https://stackoverflow.com/questions/54285717/how-to-pass-multiple-objects-from-controller-action-to-view-in-mvc
                return View(model: itemName);
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

                for (int i = 1; i < 10; i++)
                {
                    idSet = $"srp-river-results-listing{i}";                   
                }
                var newDocs = docNodes.ChildNodes
                     .Where(node => node.GetAttributeValue("id", "")
                     .Equals(idSet)).FirstOrDefault();

                var itemPrice_1 = newDocs.ChildNodes
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("s-item__wrapper clearfix")).FirstOrDefault();

                var itemPrice_2 = itemPrice_1.ChildNodes
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("s-item__info clearfix")).FirstOrDefault();

                var itemTitle = itemPrice_2.ChildNodes
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("s-item__link")).FirstOrDefault();

                var itemTitle_1 = itemTitle.ChildNodes
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("s-item__title")).FirstOrDefault();

                var itemPrice_3 = itemPrice_2.ChildNodes
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("s-item__details clearfix")).FirstOrDefault();

                var itemPrice_4 = itemPrice_3.ChildNodes
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("s-item__detail s-item__detail--primary")).FirstOrDefault();

                   itemName = itemTitle_1.InnerText.ToString();

                return View(model: itemName);
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
