using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationServices.DTOs.Category
{
    public class ResponseQueryCategoriesDto
    {
        public Guid IdCategory { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public bool State { get; set; }
    }
}
