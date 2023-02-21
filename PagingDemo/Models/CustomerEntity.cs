using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PagingDemo.Models
{
    public class CustomerEntity
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string ContactTitle { get; set; }

        public string ContactName { get; set; }

        public string Country { get; set; }
    }
}
