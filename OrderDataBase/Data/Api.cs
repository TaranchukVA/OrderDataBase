using Microsoft.AspNetCore.Mvc;
using OrderDataBase.Data.Models;
using OrderDataBase.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderDataBase.Data
{
    public class Api : Controller
    {
        private readonly OrderContext context;
        public Api(OrderContext context)
        {
            this.context = context;
        }

        [Route("/")]
        public IActionResult Index()
        {
            return Ok("Welcome!");
        }

        [HttpPost()]
        [Route("/api/order")]
        public IActionResult AddOrder([FromBody] NewOrder newOrder)
        {
            try
            {
                if (newOrder == null) BadRequest("Нет данных");

                var order = new TOrder()
                {
                    Date = DateTime.Now,
                    Customer = newOrder.customer,
                    Number = newOrder.number
                };

                context.Order.Add(order);
                context.SaveChanges();

                newOrder.products.ForEach(
                    elem => context.Product.Add(
                        new TProduct()
                        {
                            OrderId = order.Id,
                            Amount = elem.Amount,
                            Price = elem.Price,
                            Title = elem.Title
                        })
                    );

                context.SaveChanges();

                return Ok("Заказ добавлен");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet()]
        [Route("/api/order/{id}")]
        public IActionResult GetOrder([FromRoute] int id)
        {
            try
            {
                context.Order.Find(id);

                var order = context.Order.Find(id);
                if (order == null) return BadRequest($"Заказ с идентефикатором {id}  не найден.");

                var productsList = new List<ProductData>();
                decimal sum = 0;

                context.Product.Where(elem => elem.OrderId == id).ToList()
                    .ForEach(elem =>
                    {
                        sum += elem.Amount * elem.Price;
                        productsList.Add(new ProductData()
                        {
                            Id = elem.Id,
                            Amount = elem.Amount,
                            Price = elem.Price,
                            Title = elem.Title
                        });
                    });

                var result = new OrderData()
                {
                    Id = order.Id,
                    Date = order.Date,
                    Number = order.Number,
                    Customer = order.Customer,
                    products = productsList,
                    total = sum
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
