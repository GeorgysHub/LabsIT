using PagedList;
using ShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopMVC.Controllers.Front
{
    public class ProductController : Controller
    {
        [HttpGet]
        public ActionResult ProductsFront(int? page, int? catId)
        {
            List<ProductVM> listOfProductVM;
            var pageNumber = page ?? 1;
            using (DB db = new DB())
            {
                listOfProductVM = db.productsDTO.ToArray()
                    .Where(x => catId == null || catId == 0)
                    .Select(x => new ProductVM(x)).ToList();

            }
            var onePageOfProducts = listOfProductVM.ToPagedList(pageNumber, 10);
            ViewBag.onePageOfProducts = onePageOfProducts;
            
            return View(listOfProductVM);
        }

        public ActionResult _CardPartial()
        {
            CardVM model = new CardVM();
            int qty = 0;
            decimal prise = 0m;
            if (Session["cart"] != null)
            {
                var list = (List<CardVM>)Session["cart"];
                foreach(var item in list)
                {
                    qty += item.Quantity;
                    prise += item.Quantity * item.Prise;
                }

                model.Quantity = qty;
                model.Prise = prise;
            }
            else 
            {
                model.Prise = 0m;
                model.Quantity = 0;
            }
            return PartialView("_CardPartial",model);
        }
        public ActionResult CardProduct()
        {
            var cart = Session["cart"] as List<CardVM> ?? new List<CardVM>();
            if(cart.Count==0||Session["cart"]==null)
            {
                ViewBag.Message = "Ваша корзина пуста";
                return View();
            }
            decimal tot = 0m;
            foreach(var item in cart)
            {
                tot += item.TotalPrise;
            }
            ViewBag.GrandTotal = tot;
            return View(cart);
        }
        public ActionResult AddToCartPartial(int id)
        {
            List<CardVM> cards = Session["cart"] as List<CardVM> ?? new List<CardVM>();
            CardVM model = new CardVM();
            using(DB db = new DB())
            {
                ProductsDTO pr = db.productsDTO.Find(id);
                var productInCart = cards.FirstOrDefault(x => x.ProductID == id);
                if(productInCart == null && pr.Kol>0)
                {
                    
                    cards.Add(new CardVM()
                    {
                        ProductID = pr.Id,
                        ProductName = pr.Name,
                        Quantity = 1,
                        Prise = pr.Prise
                        
                    }) ;
                }
                else
                {
                    if(productInCart != null)
                    if( pr.Kol > productInCart.Quantity)
                    {
                        productInCart.Quantity++;
                    }
                    
                }
            }
            int qty = 0;
            decimal prise = 0m;

            foreach(var item in cards)
            {
                qty += item.Quantity;
                prise += item.Prise*item.Quantity;
            }
            model.Quantity = qty;
            model.Prise = prise;
            Session["cart"] = cards;

            return RedirectToAction("ProductsFront");
        }
        public ActionResult RemoveToCartPartial(int id)
        {
            List<CardVM> cards = Session["cart"] as List<CardVM>;
            CardVM model = new CardVM();
            using (DB db = new DB())
            {
               
                ProductsDTO pr = db.productsDTO.Find(id);
                var productInCart = cards.FirstOrDefault(x => x.ProductID == id);
                if (productInCart != null)
                {
                    cards.Remove(productInCart);
                }
              
            }
            
            Session["cart"] = cards;

            return RedirectToAction("CardProduct");
        }
        [HttpGet]
        public ActionResult CreateZakaz()
        {
            ZakazVM1 z=new ZakazVM1();
            return View(z);
        }
        [HttpPost]
        public ActionResult CreateZakaz(ZakazVM1 modul)
        {
            if (!ModelState.IsValid)
            {
                return View(modul);
            }
            List<CardVM> cards = Session["cart"] as List<CardVM>;
           
            
            using (DB db =new DB())
            {
                decimal k = 0m;
                ZakazDTO zakazDTO = new ZakazDTO();
                zakazDTO.Name = modul.Name;
                zakazDTO.Surname = modul.Surname;
                zakazDTO.Phone = modul.Phone;
                zakazDTO.Lastname = modul.Lastname;
                zakazDTO.Email = modul.Email;
                foreach (var item in cards)
                {
                    k += item.Quantity * item.Prise;
                } 
                zakazDTO.TotalPrise = k;
                db.ZakazDTO.Add(zakazDTO);
                db.SaveChanges();
                foreach (var item in cards)
                {
                    k += item.Quantity * item.Prise;
                    ProductsDTO pr = db.productsDTO.Find(item.ProductID);
                    pr.Kol -= item.Quantity;
                    SootDTO soot = new SootDTO();
                    soot.Zakaz = zakazDTO.Id;
                    soot.Tovar = item.ProductID;
                    soot.Kol = item.Quantity;
                    db.SootDTO.Add(soot);
                    db.SaveChanges();
                }
                Session["cart"] = null;
                
            }
            return RedirectToAction("ProductsFront");
        }
    }
}