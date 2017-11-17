using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneStopGaming.Services
{
    //Interface for a Cart Service
    public interface ICartService
    {
        Cart GetCart(string status, int userId);
        Cart CreateCart(int userId, int zip);
        CartsProduct UpdateCart(int cartId, int productId, int quantity);
    }
}