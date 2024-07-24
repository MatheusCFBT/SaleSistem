using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SaleSistemMvc.Data;
using SaleSistemMvc.Models;

namespace SaleSistemMvc.Controllers
{
    [Route("usuarios")]
    public class UserAccountsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserAccountsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.UserAccount.ToListAsync());
        }

        [HttpGet("{id:int}/detalhes")]
        public async Task<IActionResult> Details(int id)
        {
            var userAccount = await _context.UserAccount
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userAccount == null)
            {
                return NotFound();
            }

            return View(userAccount);
        }

        [HttpGet("criar-conta")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("criar-conta")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,BirthDate,Email,Phone,PostalCode")] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userAccount);
        }

        [HttpGet("{id:int}/editar")]
        public async Task<IActionResult> Edit(int id)
        {
            var userAccount = await _context.UserAccount.FindAsync(id);
            if (userAccount == null)
            {
                return NotFound();
            }
            return View(userAccount);
        }

        [HttpPost("{id:int}/editar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,BirthDate,Email,Phone,PostalCode")] UserAccount userAccount)
        {
            if (id != userAccount.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserAccountExists(userAccount.Id))
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
            return View(userAccount);
        }

        [HttpGet("{id:int}/apagar-conta")]
        public async Task<IActionResult> Delete(int id)
        {
            var userAccount = await _context.UserAccount
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userAccount == null)
            {
                return NotFound();
            }

            return View(userAccount);
        }

        [HttpPost("{id:int}/apagar-conta"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userAccount = await _context.UserAccount.FindAsync(id);
            if (userAccount != null)
            {
                _context.UserAccount.Remove(userAccount);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserAccountExists(int id)
        {
            return _context.UserAccount.Any(e => e.Id == id);
        }
    }
}
