using System.Drawing.Drawing2D;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System_Manage.Models;

namespace System_Manage.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustumersController : Controller
    {
        private readonly SystemManageContext _db;
        private readonly INotyfService _notyf;

        public CustumersController(SystemManageContext db, INotyfService notyf)
        {
            _db = db;
            _notyf = notyf;
        }
        [Route("/Admin/Customer")]
        public async Task<IActionResult> Index()
        {
            var Custumer = await _db.Custumers
                .OrderByDescending(x => x.Id)
                .ToListAsync();

            return View(Custumer);
        }

        [Route("/Admin/Customer/Create")]
        public IActionResult Create()
        {
          
            return View();
        }

        [HttpPost]
        [Route("/Admin/Customer/Create")]
        public IActionResult Create(Custumer model)
        {

            if (ModelState.IsValid)
            {
                

                Custumer custumer = new Custumer
                {
                    Name = model.Name,
                    Address = model.Address,
                    Phone = model.Phone,
                    Mst = model.Mst,
                    
                };

                _db.Custumers.Add(custumer);
                _db.SaveChanges();
                _notyf.Success("Create Success");
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [Route("/Admin/Customer/Edit/{id:}")]
        public IActionResult Edit(int id)
        {
            Custumer custumer = _db.Custumers.Find(id);

            if (custumer == null)
            {
                _notyf.Error("Find Not Success");
                return RedirectToAction("Index");
            }


          
            return View(custumer);
        }

        [HttpPost]
        [Route("/Admin/Customer/Edit/{id:}")]
        public IActionResult Edit(int id, Custumer model)
        {
           
            if (ModelState.IsValid)
            {
                try
                {
                    var cus = _db.Custumers.Find(id);

                   


                    if (cus != null)
                    {
                        cus.Name = model.Name;
                        cus.Address = model.Address;
                        cus.Phone = model.Phone;
                        cus.Mst = model.Mst;
                       


                        _db.Custumers.Update(cus);
                        _db.SaveChanges();
                        _notyf.Success("Update Success");

                       
                        return RedirectToAction("Index");
                    }

                }
                catch
                {
                   
                    _notyf.Success("Update Faill");
                    return View(model);

                }



            }
            return View(model);
        }

        [Route("/Admin/Custumer/Delete/{id:}")]
        public ActionResult Delete(int id)
        {
            Custumer cus = _db.Custumers.Find(id);
            if (cus == null)
            {
                return RedirectToAction("Index");
                _notyf.Success("Update Faill");
            }
            else
            {
               

                _db.Custumers.Remove(cus);
                _db.SaveChanges();
                _notyf.Success("Delete Success");
                return RedirectToAction("Index");
            }
        }
    }
}
