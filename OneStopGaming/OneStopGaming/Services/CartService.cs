using OneStopGaming.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace OneStopGaming.Services
{
    //Class for a Cart Service
    //This class contains the business logic for fetching information from the Cart Table
    public class CartService : ICartService
    {
        //Instance variable for the unit of work, so that we look at the same database context each time
        private IUnitOfWork _unitOfWork;

        //Constructor
        //unitOfWork - The unit of work object that maintains the single connection to the database
        public CartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Get Cart
        //This takes a status and a user id and returns the cart or null if one is not found
        public Cart GetCart(string status, int userId)
        {
            // There should only be a single cart related to a user so first will work
           Cart cart = _unitOfWork.CartRepository.Where(u => u.UserID == userId && u.Status == status).First();

            //If there is no cart then return null
            if(cart == null)
            {
                return null;
            }
            else
            {
                return cart;
            }
        }

        public Cart CreateCart(int userId, int zip = 0)
        {
            Cart cart = new Cart();
            cart.Zip = zip;
            if(userId == -1)
            {
                UserService userService = new UserService();
                userId = CreateUser().ID;
            }
            cart.UserID = userId;
            _unitOfWork.CartRepository.Add(cart);
            _unitOfWork.Save();
            return cart;
        }

        public CartsProduct UpdateCart(int cartId, int productId, int quantity = 1)
        {
            CartsProduct cartsProduct = _unitOfWork.CartsProductRepository.Where(c => c.CartID == cartId && c.ProductID == productId).FirstOrDefault();
            if(cartsProduct == null)
            {
                if(quantity > 1)
                {
                    cartsProduct = new CartsProduct();
                    cartsProduct.CartID = cartId;
                    cartsProduct.ProductID = productId;
                    cartsProduct.Quantity = quantity;
                    _unitOfWork.CartsProductRepository.Add(cartsProduct);
                }
            }
            else
            {
                if(quantity == 0)
                {
                    _unitOfWork.CartsProductRepository.Delete(cartsProduct);
                }
                else if(quantity != cartsProduct.Quantity)
                {
                    _unitOfWork.CartsProductRepository.Delete(cartsProduct);
                    cartsProduct = new CartsProduct();
                    cartsProduct.CartID = cartId;
                    cartsProduct.ProductID = productId;
                    cartsProduct.Quantity = quantity;
                    _unitOfWork.CartsProductRepository.Add(cartsProduct);
                }
            }
            _unitOfWork.Save();
            return cartsProduct;
        }
    }
}