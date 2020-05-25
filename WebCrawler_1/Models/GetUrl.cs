using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCrawler_1.Models
{
    public class GetUrl
    {
        public int ID { get; set; }
        public string NewSearch { get; set; }
        public string ItemName { get; set; }
        [Range(0.01, 100000.00,
            ErrorMessage = "Price must be between 0.01 and 10000.00")]
        public decimal ItemPrice { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
