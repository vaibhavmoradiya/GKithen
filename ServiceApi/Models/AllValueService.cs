using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceApi.Models
{
    public class AllValueService
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string Location { get; set;}
        public string ServiceType1 { get; set; }
        public double? Price { get; set; }
        public string AeraToSupport { get; set; }
    }
}