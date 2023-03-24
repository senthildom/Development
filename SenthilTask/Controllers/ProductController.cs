using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SenthilTask.Models;

namespace SenthilTask.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationUserClass _auc;
        public ProductController(ApplicationUserClass auc)
        {
            _auc = auc;
        }
        public IActionResult ProductList()
        {
            try
            {
                var PrdLIst = _auc.tbl_Product.ToList();
                return View(PrdLIst);

            }
            catch(Exception ex)
            {
                return View();
            }
            
        }


        public IActionResult UserProductList()
        {
            try
            {
                var PrdLIst = _auc.tbl_Product.ToList();
                return View(PrdLIst);

            }
            catch (Exception ex)
            {
                return View();
            }

        }

        public IActionResult Create(Product P)
        {
            return View(P);

        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(int id ,Product P)
        {
            try 
            {
                if(ModelState.IsValid)
                {
                    if( P.ProductID== 0)
                    { 
                    _auc.tbl_Product.Add(P);
                    await _auc.SaveChangesAsync();
                    }
                    else
                    {
                        _auc.Entry(P).State = EntityState.Modified;
                        await _auc.SaveChangesAsync();
                    }

                    return RedirectToAction("ProductList");
                }

                return View();
            }
            catch(Exception ex)
            {
                return RedirectToAction("ProductList");
            }
            

        }

        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                var std = await _auc.tbl_Product.FindAsync(id);
                if(std!=null)
                {
                    _auc.tbl_Product.Remove(std);
                    await _auc.SaveChangesAsync();
                }
                return RedirectToAction("ProductList");
            }
            catch(Exception ex)
            {
                return RedirectToAction("ProductList");
            }
        }



        //public ActionResult InsertData()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult InsertData(Product P)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _auc.tbl_Product.Add(P);
        //        _auc.SaveChanges();
        //        if (P.ProductID > 0)
        //        {
        //            ViewBag.Success = "Inserted";

        //        }
        //        ModelState.Clear();
        //    }
        //    return View();
        //}

        //public ActionResult EditProduct(Int32 ProductID)
        //{
        //    var ProductData = _auc.tbl_Product.Where(x => x.ProductID == ProductID).FirstOrDefault();
        //    if (ProductData != null)
        //    {
        //        TempData["ProductID"] = ProductID;
        //        TempData.Keep();
        //        return View(ProductData);
        //    }
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult EditStudent(Product P)
        //{
        //    Int32 ProductID = (int)TempData["ProductID"];
        //    var ProductData = _auc.tbl_Product.Where(x => x.ProductID == ProductID).FirstOrDefault();
        //    if (ProductData != null)
        //    {
        //        ProductData.ProductName = P.ProductName;
        //        ProductData.ProductQuantity = P.ProductQuantity;
        //        ProductData.ProductPrice = P.ProductPrice;
                
        //        _auc.Entry(ProductData).State = EntityState.Modified;
        //        _auc.SaveChanges();
        //    }
        //    return RedirectToAction("Index");
        //}



    }
}
