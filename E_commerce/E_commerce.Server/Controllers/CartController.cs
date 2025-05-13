using E_commerce.Bll.Dtos.CartDto;
using E_commerce.Bll.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Server.Controllers;

[Route("api/cart")]
[ApiController]
public class CartController : ControllerBase
{
    private readonly ICartService CartService;
    private readonly ILogger<CartController> Logger;

    public CartController(ICartService cartService, ILogger<CartController> logger)
    {
        CartService = cartService;
        Logger = logger;
    }

    [HttpPost("add")]
    public async Task AddProduct(long customerId, long productId, int quantity)
        {
        await CartService.AddProductToCartAsync(customerId, productId, quantity);
    }

    [HttpGet("get")]
    public async Task<GetCartDto> GetCart(long customerId)
    {
        Logger.LogInformation("hello getCart is called");

        return await CartService.GetCartByCustomerId(customerId);
    }
}
