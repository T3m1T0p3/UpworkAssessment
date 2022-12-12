using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpworkAssessment.Model
{
    public class ProductDto
    {
        public string Name { get; set; }
        //public Guid ProductId { get; set; } = Guid.NewGuid();
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
