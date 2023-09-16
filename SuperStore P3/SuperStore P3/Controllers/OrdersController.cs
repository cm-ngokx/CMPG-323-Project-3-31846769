using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using EcoPower_Logistics.Repository;
using System.Linq.Expressions;
using NuGet.Protocol;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrdersController(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        // GET: Orders
        public IActionResult Index()
        {
            var orders = _ordersRepository.GetAll();
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _ordersRepository.GetById(id.Value);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,OrderDate,CustomerID,DeliveryAddress")] Order order)
        {
            if (ModelState.IsValid)
            {
                _ordersRepository.Add(order);
                // You might want to add error handling and validation here.
                // Also, consider returning a different view or redirecting to a different action on failure.
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Order/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _ordersRepository.GetById(id.Value);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Oders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(" CustomerID,CustomerID,order.CustomerID")] Order order)
        {
            if (id != order.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ordersRepository.Update(order);

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _ordersRepository.GetById(id.Value);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var order = _ordersRepository.GetById(id);

            if (order != null)
            {
                _ordersRepository.Remove(order);
                // Handle exceptions and validation if necessary.
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }


        private bool OrderExists(int id)
        {
            return _ordersRepository.GetById(id) != null;
        }


    }
}
