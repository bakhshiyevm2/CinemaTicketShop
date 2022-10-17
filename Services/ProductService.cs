using AutoMapper;
using DataAccess;
using DataAccess.Entites;
using DTO;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : BaseService<ProductDTO, Product, ProductDTO>, IProductService
    {
        public ProductService(AppDbContext db, IMapper mapper) : base(db, mapper)
        {

        }


        public void Buy(int cartId)
        {
            var cart = _db.Carts.Find(cartId);

            _db.Carts.Remove(cart);
            _db.SaveChanges();
        }

        public void AddToCart(CartDTO dto) 
        {
            var user = _db.Users.Find(dto.UserId);
            
            if (user == null)
                throw new Exception("User not found!");

            var ent = _mapper.Map<Cart>(dto);
            
            user.Cart.Add(ent);

            _db.SaveChanges();

        }

        public IEnumerable<CartDTO> GetCart(int userId)
        {
            var user = _db.Users
                .Where(u => u.Id == userId)
                .Include(x => x.Cart)
                .ThenInclude(x => x.Product)
                .First();
            //joins            

            if (user == null)
                throw new Exception("User not found!");

            var res = _mapper.Map<IEnumerable<CartDTO>>(user.Cart);

            return res;
        }

        public IEnumerable<ProductDTO> GetFilter(int page = 1, int pageSize = 16, ProductSortOrder order = ProductSortOrder.NameAsc, string search = null) 
        {
            //doing it in code, but need in db
            var res = Get();

            if (!string.IsNullOrEmpty(search))
                res = res.Where(pr => pr.Name.ToLower().Contains(search.ToLower()));

            res = order switch
            {
                ProductSortOrder.NameDesc => res.OrderByDescending(s => s.Name),
                ProductSortOrder.PriceAsc => res.OrderBy(s => s.Price),
                ProductSortOrder.PriceDesc => res.OrderByDescending(s => s.Price),

                _ => res.OrderBy(s => s.Name),
            };

            var prods = res.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return prods;
        }
    }
}
