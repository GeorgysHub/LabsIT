using PagedList;
using ShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopMVC.Controllers
{
    [Authorize]
    public class ShopADController : Controller
    {
        [HttpGet]
        public ActionResult AddProduct()
        {
            ProductVM model = new ProductVM();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddProduct(ProductVM model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            using(DB db =new DB())
            {
                if (db.productsDTO.Any(x => x.Name == model.Name))
                {
                    ModelState.AddModelError("", "Этот товар уже присутствует!");
                    return View(model);
                }
            }
           
            using (DB db = new DB())
            {
                ProductsDTO productsDTO = new ProductsDTO();
                productsDTO.Name = model.Name;
                productsDTO.Prise = model.Prise;
                productsDTO.Kol = model.Kol;
                productsDTO.Opis = model.Opis;

                db.productsDTO.Add(productsDTO);
                db.SaveChanges();
            }

            TempData["SM"] = "Вы успешно добавили продукт!";
            return RedirectToAction("AddProduct");
        }

        [HttpGet]
        public ActionResult Products(int? page, int? catId)
        {
            List<ProductVM> listOfProductVM;
            var pageNumber = page ?? 1;
            using(DB db = new DB())
            {
                listOfProductVM = db.productsDTO.ToArray()
                    .Where(x => catId == null || catId == 0)
                    .Select(x => new ProductVM(x)).ToList();
                
            }
            var onePageOfProducts = listOfProductVM.ToPagedList(pageNumber, 5);
            ViewBag.onePageOfProducts = onePageOfProducts;
            return View(listOfProductVM);
        }

        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            ProductVM modul;
            using(DB db = new DB())
            {
                ProductsDTO dTO = db.productsDTO.Find(id);
                if(dTO == null)
                {
                    return Content("Этот продукт не найден!");
                }
                modul = new ProductVM(dTO);
            }
            return View(modul);
        }
        [HttpPost]
        public ActionResult EditProduct(ProductVM model)
        {
            int id = model.Id;
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            using(DB db = new DB())
            {
                if (db.productsDTO.Where(x => x.Id != id).Any(x=>x.Name==model.Name))
                {
                    ModelState.AddModelError("", "Этот товар уже присутствует!");
                    return View(model);
                }
            }

            using (DB db = new DB())
            {
                ProductsDTO productsDTO = db.productsDTO.Find(id);
                productsDTO.Name = model.Name;
                productsDTO.Prise = model.Prise;
                productsDTO.Kol = model.Kol;
                productsDTO.Opis = model.Opis;

               
                db.SaveChanges();
            }

            TempData["SM"] = "Вы успешно обновили продукт!";
            return RedirectToAction("EditProduct");

           
        }

        
        public ActionResult DeleteProduct(int id)
        {
            using(DB db=new DB())
            {
                ProductsDTO dTO=  db.productsDTO.Find(id);
                db.productsDTO.Remove(dTO);
                db.SaveChanges();
            }
            return RedirectToAction("Products");
        }
        [HttpGet]
        public ActionResult ZakazAD(int? page, int? catId)
        {
            List<ZakazVM1> listOfProductVM;
            var pageNumber = page ?? 1;
            using (DB db = new DB())
            {
                listOfProductVM = db.ZakazDTO.ToArray()
                    .Where(x => catId == null || catId == 0)
                    .Select(x => new ZakazVM1(x)).ToList();

            }
            var onePageOfProducts = listOfProductVM.ToPagedList(pageNumber, 3);
            ViewBag.onePageOfProducts = onePageOfProducts;
            return PartialView(listOfProductVM);
        }
        [HttpGet]
        public ActionResult ZakazADV(int id)
        {
            List<ProductVM> listOfProductVM;
           
            using (DB db = new DB())
            {
                listOfProductVM = db.productsDTO.ToArray()
                    .Where(x => x.Id==id)
                    .Select(x => new ProductVM()).ToList();

            }
          
            return PartialView(listOfProductVM);
        }
    }
}