using ClassLibrary1;
using Library2.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_Consume.Controllers
{
    [Authorize]
    public class CrudController : Controller
    {
        private readonly Interface_Api_Service db;
        public CrudController(Interface_Api_Service Db)
        {
            db = Db;
        }
        public async Task<IActionResult> Index()
        {
            var list = await db.GetAllAsync();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Invest pd)
        {
            if (ModelState.IsValid)
            {
                bool resp = await db.AddAsync(pd);
                if (resp)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(pd);
        }
    }
}
