using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using System.Transactions;

namespace Presentation.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("Product/Get/{id}")]
        public IActionResult Get(int id, string message = null, bool isSuccess = true)
        {
            if (!string.IsNullOrEmpty(message))
            {
                if (isSuccess)
                    ViewBag.Success = message;
                else
                    ViewBag.Error = message;
            }


            var res = _productService.Get(id);
            
            if (res == null)
            {
                ViewBag.Error = "Not Found!";
                return View();
            }
            return View(res);
        }

        [HttpGet]
        public IActionResult GetAll(int page = 1, int pageSize = 4, ProductSortOrder order = ProductSortOrder.NameAsc, string search = null,bool changeSort = false)
        {
            if (!string.IsNullOrEmpty(search))
                ViewBag.Search = search;
            //to save search text in input

            int allProductsCount;
            var res = _productService.GetFilter(out allProductsCount, page, pageSize, order, search);

            ViewBag.HasPrevious = true;
            ViewBag.HasNext = true;

            if (page <= 1)
            {
                ViewBag.HasPrevious = false;
            }
            if (page * pageSize >= allProductsCount)
            {
                ViewBag.HasNext = false;
            }

            if (changeSort)
            {
                ViewBag.NameSort = order == ProductSortOrder.NameAsc ? ProductSortOrder.NameDesc : ProductSortOrder.NameAsc;
                ViewBag.PriceSort = order == ProductSortOrder.PriceAsc ? ProductSortOrder.PriceDesc : ProductSortOrder.PriceAsc;
            }
            else
            {
                ViewBag.NameSort = order;
                ViewBag.PriceSort = order;
            }

            var pagedRs = new PagedResponseDTO<ProductDTO>(page, pageSize, res);

            return View(pagedRs);
        }

        [HttpPost]
        public IActionResult AddToCart(CartDTO dto)
        {
            bool isSuccess;
            string mes;
            try
            {
                dto.UserId = Convert.ToInt32(HttpContext.User.FindFirst(x => x.Type == "Id")?.Value);

                _productService.AddToCart(dto);
                mes = "Succesfuly added!";
                isSuccess = true;
            }
            catch (Exception ex)
            {
                mes = ex.Message;
                isSuccess = false;
            }

            return RedirectToAction("Get", 
                new { 
                    id = dto.ProductId,
                    message = mes,
                    isSuccess = isSuccess
                    });
        }

        [HttpGet]
        public IActionResult GetCart(string message = null, bool isSuccess = true)
        {
            if (!string.IsNullOrEmpty(message))
            {
                if (isSuccess)
                    ViewBag.Success = message;
                else
                    ViewBag.Error = message;
            }

            var userId = Convert.ToInt32(HttpContext.User.FindFirst(x => x.Type == "Id")?.Value);

            var res = _productService.GetCart(userId);
            
            return View(res);

        }

        [HttpPost]
        public IActionResult Buy(PayDTO dto) 
        {
            _productService.Buy(dto.CartId);

            return RedirectToAction("GetCart",
                new
                {
                    message = "Success! You paid " + dto.Sum + "$!",
                    isSuccess = true
                });
        }

        [HttpPost]
        public IActionResult DeleteFromCart(int cartId)
        {
            _productService.DeleteFromCart(cartId);

            return RedirectToAction("GetCart",
                new
                {
                    message = "Success! Deleted from cart!",
                    isSuccess = true
                });
        }

    }
}
