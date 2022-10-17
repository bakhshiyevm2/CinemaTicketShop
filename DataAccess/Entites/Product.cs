using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entites
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string ImgPath { get; set; }
        public double Price { get; set; }
        public string Note { get; set; }
        public List<Cart> Cart { get; set; }
    }
}
