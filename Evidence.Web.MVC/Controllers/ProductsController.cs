using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Evidence.BLL;
using Evidence.DAL;
using Evidence.DTO;

namespace Evidence.Web.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IManager<Product> _productsManager;
        private readonly IManager<Category> _categoriesManager;
        private readonly IReadManager<ProductView> _productsViewManager;

        public ProductsController(IManager<Product> productsManager, IManager<Category> categoriesManager, IReadManager<ProductView> productsViewManager)
        {
            _productsManager = productsManager;
            _categoriesManager = categoriesManager;
            _productsViewManager = productsViewManager;
        }
        
        // GET: Products
        public ActionResult Index(int? page)
        {
            var pg = page ?? 1;

            var productsViews =
                _productsViewManager.Get(pg, 3, p => p.OrderBy(order => order.Id), out var pageCount);

            ViewBag.Pages = pageCount;

            return View(productsViews);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _productsManager.Get((int)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            var categories = _categoriesManager.Get();
            ViewBag.Categories = categories;

            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Product product, int catId)
        {
            product.Category = _categoriesManager.Get(catId);

            ModelState.Clear();
            TryValidateModel(product);


            if (ModelState.IsValid)
            {
                _productsManager.Save(product);
                TempData["message-sucess"] = product.Category.Name + " " + product.Name + " úspěšně přidáno.";
                return RedirectToAction("Index");
            }

            ViewBag.Categories = _categoriesManager.Get();

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _productsManager.Get((int)id);
            if (product == null)
            {
                return HttpNotFound();
            }

            ViewBag.Categories = _categoriesManager.Get();
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Author,Description")] Product product, int ddlCategoryId)
        {
            product.CategoryId = ddlCategoryId;

            if (ModelState.IsValid)
            {
                _productsManager.Save(product);
                return RedirectToAction("Index");
            }
            
            ViewBag.Categories = _categoriesManager.Get();
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _productsManager.Get((int)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _productsManager.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
