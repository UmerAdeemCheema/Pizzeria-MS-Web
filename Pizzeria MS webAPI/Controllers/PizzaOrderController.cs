using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pizzeria_MS_webAPI.Models;
using Pizzeria_MS_webAPI.Models.Interface;
using Pizzeria_MS_webAPI.Models.Implementation;
using Pizzeria_MS_webAPI.Models.Implementation.Decorator;
using Pizzeria_MS_webAPI.Models.Implementation.Decorator.Base;

namespace Pizzeria_MS_webAPI.Controllers
{
    public class PizzaOrderController : Controller
    {
        IPizza pizza = null;
        private PizzeriaEntities db = new PizzeriaEntities();
        public void createthincrust()
        {
            pizza = ThinCrust.create(pizza);
        }
        public void createstuffedcrust()
        {
            pizza = StuffedCrust.create(pizza);
        }
        public void createExtraToppings()
        {
            pizza = Extra_Toppings.create(pizza);
        }
        public void createExtracheese()
        {
            pizza = Extra_Cheese.create(pizza);
        }
        public int getpizzaprice()
        {
            if (pizza == null)
            {
                pizza = new PizzaDecorator(pizza);
                return pizza.getPrice();
            }
            else
            {
                return pizza.getPrice();
            }
        }
        // GET: PizzaOrder
        public ActionResult Index()
        {
            var pizzaOrders = db.PizzaOrders.Include(p => p.Customer);
            return View(pizzaOrders.ToList());
        }

        // GET: PizzaOrder/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PizzaOrder pizzaOrder = db.PizzaOrders.Find(id);
            if (pizzaOrder == null)
            {
                return HttpNotFound();
            }
            return View(pizzaOrder);
        }

        // GET: PizzaOrder/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Name");
            return View();
        }

        // POST: PizzaOrder/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,CustomerID,PizzaName,UnitPrice,Qty,Price")] PizzaOrder pizzaOrder)
        {
            if (ModelState.IsValid)
            {
                db.PizzaOrders.Add(pizzaOrder);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Record Saved Successfully";
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Name", pizzaOrder.CustomerID);
            return View(pizzaOrder);
        }

        // GET: PizzaOrder/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PizzaOrder pizzaOrder = db.PizzaOrders.Find(id);
            if (pizzaOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Name", pizzaOrder.CustomerID);
            return View(pizzaOrder);
        }

        // POST: PizzaOrder/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,CustomerID,PizzaName,UnitPrice,Qty,Price")] PizzaOrder pizzaOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pizzaOrder).State = EntityState.Modified;
                db.SaveChanges(); 
                TempData["SuccessMessage"] = "Record Editted Successfully";
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Name", pizzaOrder.CustomerID);
            return View(pizzaOrder);
        }

        // GET: PizzaOrder/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PizzaOrder pizzaOrder = db.PizzaOrders.Find(id);
            if (pizzaOrder == null)
            {
                return HttpNotFound();
            }
            return View(pizzaOrder);
        }

        // POST: PizzaOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PizzaOrder pizzaOrder = db.PizzaOrders.Find(id);
            db.PizzaOrders.Remove(pizzaOrder);
            db.SaveChanges(); 
            TempData["SuccessMessage"] = "Record Deleted Successfully";
            return RedirectToAction("Index");
        }

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
