using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationServices.DTOs.Product
{
    public class ResponseQueryProductDetailsDto
    {
        public Guid? IdProduct { get; set; }
        public Guid? IdProductDetail { get; set; }
        public decimal? Price { get; set; }
        public int? Stock { get; set; }
        public string? Color { get; set; }
        public string? Size { get; set; }
    }
}
