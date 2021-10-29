using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductView_v_4.Models
{
    public class IndexModel
    {
        public List<Product> products = ProductRepository.GetProducts();
    }
}
