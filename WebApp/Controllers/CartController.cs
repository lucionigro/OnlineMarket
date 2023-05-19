using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public static string Message;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            decimal totalPrice = 0;

            foreach (Cart cart in LocalData.Cart)
            {
                totalPrice += cart.Product.Price * cart.Amount;
            }

            ViewBag.TotalPrice = totalPrice;
            ViewBag.Message = Message;

            return View(LocalData.Cart);
        }

        public ActionResult Remove(int id)
        {
            var cart = LocalData.Cart.Where(i => i.Product.Id == id).FirstOrDefault();

            if (cart == null)
            {
                return RedirectToAction("Index");
            }

            if (cart.Amount == 1)
            {
                LocalData.Cart.Remove(cart);
            }
            else
            {
                cart.Amount -= 1;
            }

            return RedirectToAction("Index");
        }


        public ActionResult CheckOut()
        {
            decimal totalPrice = 0;

            foreach (Cart cart in LocalData.Cart)
            {
                totalPrice += cart.Product.Price * cart.Amount;
            }


            Order order = new Order
            {
                Paid = true,
                Price = totalPrice,
            };

            _context.Order.Add(order);
            _context.SaveChanges();

            foreach (Cart cart in LocalData.Cart)
            {
                OrderDetails orderDetails = new OrderDetails
                {
                    OrderId = order.Id,
                    ProductId = cart.Product.Id,
                    Amount = cart.Amount
                };

                _context.OrderDetails.Add(orderDetails);

            }

            _context.SaveChanges();
            LocalData.Cart.Clear();
            

            return RedirectToAction("SuccessBuy");
        }

        public ActionResult SuccessBuy()
        {
            return View();
        }


    }
}
