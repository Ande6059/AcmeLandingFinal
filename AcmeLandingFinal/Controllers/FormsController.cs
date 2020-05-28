using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AcmeLandingFinal.Data;
using AcmeLandingFinal.Models;
using Microsoft.AspNetCore.Authorization;

namespace AcmeLandingFinal.Controllers
{
    public class FormsController : Controller
    {
        private readonly ApplicationDbContext _context;


        public FormsController(ApplicationDbContext context)
        {
            _context = context;
        }




        // GET: Forms
        public async Task<IActionResult> Index()
        {
            return View(await _context.Form.ToListAsync());
        }

        // GET: Forms/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var form = await _context.Form
                .FirstOrDefaultAsync(m => m.FormId == id);
            if (form == null)
            {
                return NotFound();
            }
            using (_context)

                return View(form);
        }

        // GET: Forms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Forms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FormId,FirstName,Lastname,DateOfBirth,EmailAddress,ProductSerialNumber")] Form form)
        {
            Form duplicateKey = await _context.Form.FirstOrDefaultAsync(f => f.ProductSerialNumber == form.ProductSerialNumber);
            var validKey = await _context.SerialKey.FirstOrDefaultAsync(s => s.KeyCode.ToString() == form.ProductSerialNumber.ToString());



            if (duplicateKey != null)
            {
                ModelState.AddModelError(string.Empty, "This code has already been used 2 times.");
            }
            if (validKey == null)
            {
                ModelState.AddModelError(string.Empty, "This code is not valid");
            }

            if (ModelState.IsValid)
            {

                _context.Add(form);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(form);
        }

        [Authorize(Roles = "Admin")]
        // GET: Forms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var form = await _context.Form.FindAsync(id);
            if (form == null)
            {
                return NotFound();
            }
            return View(form);
        }

        // POST: Forms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FormId,FirstName,Lastname,DateOfBirth,EmailAddress,ProductSerialNumber")] Form form)
        {
            if (id != form.FormId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(form);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormExists(form.FormId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(form);
        }

        // GET: Forms/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var form = await _context.Form
                .FirstOrDefaultAsync(m => m.FormId == id);
            if (form == null)
            {
                return NotFound();
            }

            return View(form);
        }

        // POST: Forms/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var form = await _context.Form.FindAsync(id);
            _context.Form.Remove(form);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormExists(int id)
        {
            return _context.Form.Any(e => e.FormId == id);
        }

    }
}
