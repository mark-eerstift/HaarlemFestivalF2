using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectWebApplicatie.Models;

namespace ProjectWebApplicatie.Logic
{
    public class ShoppingCartActions
    {
        public string ShoppingCartId { get; set; }

        private ProjectWebApplicatieContextDB db = new ProjectWebApplicatieContextDB();

        public const string CartSessionId = "CardId";

        public void AddToCart(int id)
        {
            // Retrieve the product from the database.           
            ShoppingCartId = GetCartId();

            var cartItem = db.CartItems.SingleOrDefault(
                c => c.CartId == ShoppingCartId
                && c. == id);
            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists.                 
                cartItem = new CartItem
                {
                    ItemId = Guid.NewGuid().ToString(),
                    ProductId = id,
                    CartId = ShoppingCartId,
                    Product = _db.Products.SingleOrDefault(
                   p => p.ProductID == id),
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };

                db.CartItems.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart,                  
                // then add one to the quantity.                 
                cartItem.Quantity++;
            }
            db.SaveChanges();
        }

        public void Dispose()
        {
            if (db != null)
            {
                db.Dispose();
                db = null;
            }
        }

        public string GetCartId()
        {
            if (HttpContext.Current.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class.     
                    Guid tempCartId = Guid.NewGuid();
                    HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return HttpContext.Current.Session[CartSessionKey].ToString();
        }

        public List<CartItem> GetCartItems()
        {
            ShoppingCartId = GetCartId();

            return db.CartItems.Where(
                c => c.CartId == ShoppingCartId).ToList();
        }
    }
}