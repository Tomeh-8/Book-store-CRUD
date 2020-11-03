using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCollectionCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCollectionCRUD.Controllers
{
    public class BookController : Controller
    {
        private readonly AppDbContext _db;

        public BookController(AppDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            var displayData = _db.BookTable.ToList();
            return View(displayData);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(NewSubscriber nag)
        {
            if (ModelState.IsValid)
            {
                _db.Add(nag);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nag);
        }

       public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var getBookDetails = await _db.BookTable.FindAsync(id);
            return View(getBookDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(NewSubscriber nec)
        {
            if(ModelState.IsValid)
            {
                _db.Update(nec);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(nec);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var getBookDetails = await _db.BookTable.FindAsync(id);
            return View(getBookDetails);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var getBookDetails = await _db.BookTable.FindAsync(id);
            return View(getBookDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var getBookDetails = await _db.BookTable.FindAsync(id);
            _db.BookTable.Remove(getBookDetails);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }





    }

}
