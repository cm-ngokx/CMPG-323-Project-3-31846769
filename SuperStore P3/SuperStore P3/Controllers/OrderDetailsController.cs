using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using EcoPower_Logistics.Repository;

namespace Controllers
{
    [Authorize]
    public class OrderDetailsController : Controller
    {
        private readonly IOrderDetailsRepository _OrderDetailsRepository;

        public OrderDetailsController(IOrderDetailsRepository OrderDetailsRepository)
        {
            _OrderDetailsRepository = OrderDetailsRepository;
        }

        // GET: OrderDetails
        public IActionResult Index()
        {
            var orderDetails = _OrderDetailsRepository.GetAll();
            return View(orderDetails.ToList());
        }

        // GET: OrderDetails/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = _OrderDetailsRepository.GetById(id.Value);

            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // GET: OrderDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderDetails/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderDetailsId,OrderId,ProductId,Quantity,Discount")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                _OrderDetailsRepository.Add(orderDetail);
                return RedirectToAction(nameof(Index));
            }
            return View(orderDetail);
        }

        // GET: OrderDetails/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = _OrderDetailsRepository.GetById(id.Value);

            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // POST: OrderDetails/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderDetailId,OrderDetailTitle,OrderDetailName,OrderDetailSurname,CellPhone")] OrderDetail orderDetail)
        {
            if (id != orderDetail.OrderDetailsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _OrderDetailsRepository.Update(orderDetail);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return View(orderDetail);
        }

        // GET: OrderDetails/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = _OrderDetailsRepository.GetById(id.Value);

            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // POST: OrderDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = _OrderDetailsRepository.GetById(id);

            if (orderDetail != null)
            {
                _OrderDetailsRepository.Remove(orderDetail);
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }

        private bool OrderDetailExists(int id)
        {
            return _OrderDetailsRepository.GetById(id) != null;
        }
    }
}