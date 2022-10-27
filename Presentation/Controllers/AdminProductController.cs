using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using Services;
using Services.Abstract;
using System.Diagnostics;

namespace Presentation.Controllers
{
    [Authorize]
    public class AdminProductController : Controller
    {
        private readonly IProductService productService;

        public AdminProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll(int page = 1, int pageSize = 4, ProductSortOrder order = ProductSortOrder.NameAsc, string search = null, bool changeSort = false)
        {
            if (!string.IsNullOrEmpty(search))
                ViewBag.Search = search;
            //to save search text in input

            int allProductsCount;
            var res = productService.GetFilter(out allProductsCount, page, pageSize, order, search);

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

    }
}