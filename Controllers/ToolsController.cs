using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToolMvc;
using ToolMvc.Models;

namespace ToolMvc.Controllers
{
    public class ToolsController : Controller
    {
        private readonly ToolMvcContext _context;

        public ToolsController(ToolMvcContext context)
        {
            _context = context;
        }

        // GET: Tools
        public async Task<IActionResult> Index(string toolType, string searchString, string placeAdress)
        {
            IQueryable<string> typeQuery = from t in _context.Tools
                                           orderby t.Type
                                           select t.Type;
            IQueryable<string> placeQuery = from p in _context.Places
                                            select p.PlaceAdress;
            var tools = from t in _context.Tools
                        select t;
            var places = from p in _context.Places
                         select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                tools = tools.Where(a => a.Description.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(toolType))
            {
                tools = tools.Where(x => x.Type == toolType);
            }
            if (!String.IsNullOrEmpty(placeAdress))
            {
                tools = tools.Where(x => x.Place.PlaceAdress == placeAdress);
            }
            var toolTypeVM = new ToolTypeViewModel();
            toolTypeVM.Types = new SelectList(await typeQuery.Distinct().ToListAsync());
            toolTypeVM.Tools = await tools.ToListAsync();
            toolTypeVM.PlaceAdresses = new SelectList(await placeQuery.Distinct().ToListAsync());
            toolTypeVM.Places = await places.ToListAsync();
            toolTypeVM.SearchString = searchString;

            return View(toolTypeVM);
        }

        // GET: Tools/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tool = await _context.Tools
                .Include(p => p.Place)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ToolID == id);
            if (tool == null)
            {
                return NotFound();
            }

            return View(tool);
        }

        // GET: Tools/Create
        public IActionResult Create()
        {
            PlaceList();
            return View();
        }

        // POST: Tools/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ToolID,Type,Description,PlaceID")] Tool tool)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tool);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PlaceList(tool.PlaceID);
            return View(tool);
        }

        // GET: Tools/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tool = await _context.Tools
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ToolID == id);
            if (tool == null)
            {
                return NotFound();
            }
            PlaceList(tool.PlaceID);
            return View(tool);
        }

        // POST: Tools/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ToolID,Type,Description, PlaceID")] Tool tool)
        {
            if (id != tool.ToolID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tool);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToolExists(tool.ToolID))
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
            PlaceList();
            return View(tool);
        }
        private void PlaceList(object selectedPlace = null)
        {
            var placesQuery = from p in _context.Places
                              orderby p.PlaceAdress
                              select p;
            ViewBag.PlaceID = new SelectList(placesQuery.AsNoTracking(), "PlaceID", "PlaceAdress", selectedPlace);
        }

        // GET: Tools/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tool = await _context.Tools
                .Include(c => c.Place)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ToolID == id);
            if (tool == null)
            {
                return NotFound();
            }

            return View(tool);
        }

        // POST: Tools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tool = await _context.Tools.FindAsync(id);
            _context.Tools.Remove(tool);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToolExists(int id)
        {
            return _context.Tools.Any(e => e.ToolID == id);
        }
    }
}
