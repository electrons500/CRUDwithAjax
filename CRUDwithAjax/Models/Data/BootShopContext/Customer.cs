using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CRUDwithAjax.Models.Data.BootShopContext
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAge { get; set; }
        public string CustomerLocation { get; set; }
        public string CustomerContact { get; set; }
    }
}
