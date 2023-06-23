using System.ComponentModel.DataAnnotations;

namespace CRUDwithAjax.Models.Data.ViewModel
{
    public class CustomerViewModel
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAge { get; set; }
        public string CustomerLocation { get; set; }
        public string CustomerContact { get; set; }
    }
}
