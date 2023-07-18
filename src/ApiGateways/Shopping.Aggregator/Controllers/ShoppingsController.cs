using Microsoft.AspNetCore.Mvc;
using Shopping.Aggregator.Models;
using Shopping.Aggregator.Services;
using System;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingsController : ControllerBase
    {
        private readonly ICatalogService _catalogService;
        private readonly IBasketService _basketService;
        private readonly IOrderingService _orderingService;

        public ShoppingsController(ICatalogService catalogService,
                                   IBasketService basketService,
                                   IOrderingService orderingService)
        {
            _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
            _orderingService = orderingService ?? throw new ArgumentNullException(nameof(orderingService));
        }

        [HttpGet("{userName}", Name = nameof(GetShopping))]
        public async Task<ActionResult<ShoppingModel>> GetShopping(string userName)
        {
            // get basket with username
            // iterate basket items and consume products with basket item productId member
            // map product related memebers into BasketItemDto with extended columns
            // consume ordering microservice in order to retrieve order list
            // return root shopping model dto class including all response

            var basket = await _basketService.GetBasket(userName);
            var orders = await _orderingService.GetOrdersByUserName(userName);
            foreach (var item in basket.Items)
            {
                var product = await _catalogService.GetCatalogById(item.ProductId);

                // set additional product fields into basket item
                item.ProductName = product.Name;
                item.Category = product.Category;
                item.Summary = product.Summary;
                item.Description = product.Description;
                item.ImageFile = product.ImageFile;
            }

            var shoppingModel = new ShoppingModel
            {
                UserName = userName,
                BasketWithProducts = basket,
                Orders = orders
            };

            return shoppingModel;
        }
    }
}