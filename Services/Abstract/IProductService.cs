using DataAccess.Entites;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IProductService : IBaseService<ProductDTO, Product,ProductDTO>
    {
        public IEnumerable<ProductDTO> GetFilter(int page = 1, int pageSize = 16, ProductSortOrder order = ProductSortOrder.NameAsc, string search = null);   
        public void AddToCart(CartDTO dto);
        public IEnumerable<CartDTO> GetCart(int userId);
        public void DeleteFromCart(int cartId);
        public void Buy(int cartId);
    }
}
