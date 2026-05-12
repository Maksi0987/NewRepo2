using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication9.Data;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class AiPromptsController : Controller
    {
        private readonly AppDbContext _context;

        public AiPromptsController(AppDbContext context)
        {
            _context = context;
        }

     
        public async Task<IActionResult> Index()
        {
            return View(await _context.AiPrompts.ToListAsync());
        }

     
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aiPrompt = await _context.AiPrompts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aiPrompt == null)
            {
                return NotFound();
            }

            return View(aiPrompt);
        }

        
        public IActionResult Create()
        {
            return View();
        }

    
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,PromptText,NeuralNetwork,Price")] AiPrompt aiPrompt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aiPrompt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aiPrompt);
        }

      
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aiPrompt = await _context.AiPrompts.FindAsync(id);
            if (aiPrompt == null)
            {
                return NotFound();
            }
            return View(aiPrompt);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,PromptText,NeuralNetwork,Price")] AiPrompt aiPrompt)
        {
            if (id != aiPrompt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aiPrompt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AiPromptExists(aiPrompt.Id))
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
            return View(aiPrompt);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aiPrompt = await _context.AiPrompts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aiPrompt == null)
            {
                return NotFound();
            }

            return View(aiPrompt);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aiPrompt = await _context.AiPrompts.FindAsync(id);
            if (aiPrompt != null)
            {
                _context.AiPrompts.Remove(aiPrompt);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AiPromptExists(int id)
        {
            return _context.AiPrompts.Any(e => e.Id == id);
        }
    }
}
