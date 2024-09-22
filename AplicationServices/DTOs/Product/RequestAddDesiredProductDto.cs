using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationServices.DTOs.Product
{
    public class RequestAddDesiredProductDto
    {
        public Guid IdProduct { get; set; }
        public Guid IdUser { get; set; }
    }
}
