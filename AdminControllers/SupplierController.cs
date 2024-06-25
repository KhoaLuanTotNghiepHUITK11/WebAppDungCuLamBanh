using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebDungCuLamBanh.Data;
using WebDungCuLamBanh.Models;

namespace WebDungCuLamBanh.AdminControllers
{
    public class SupplierController : Controller
    {
        private readonly AppDbContext _context;

        public SupplierController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Supplier
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("admin") == null)
            {
                return RedirectToAction("Index");
            }
            return View(await _context.NhaCungCaps.ToListAsync());
        }

        // GET: Supplier/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("admin") == null)
            {
                return RedirectToAction("Index");
            }
            if (id == null)
            {
                return NotFound();
            }

            var nhaCungCapModel = await _context.NhaCungCaps
                .FirstOrDefaultAsync(m => m.Id_NhaCungCap == id);
            if (nhaCungCapModel == null)
            {
                return NotFound();
            }

            return View(nhaCungCapModel);
        }

        // GET: Supplier/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("admin") == null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // POST: Supplier/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_NhaCungCap,TenNhaCungCap,DiaChi,SoDienThoai,Email")] NhaCungCapModel nhaCungCapModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhaCungCapModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhaCungCapModel);
        }

        // GET: Supplier/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("admin") == null)
            {
                return RedirectToAction("Index");
            }
            if (id == null)
            {
                return NotFound();
            }

            var nhaCungCapModel = await _context.NhaCungCaps.FindAsync(id);
            if (nhaCungCapModel == null)
            {
                return NotFound();
            }
            return View(nhaCungCapModel);
        }

        // POST: Supplier/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_NhaCungCap,TenNhaCungCap,DiaChi,SoDienThoai,Email")] NhaCungCapModel nhaCungCapModel)
        {
            if (id != nhaCungCapModel.Id_NhaCungCap)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhaCungCapModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhaCungCapModelExists(nhaCungCapModel.Id_NhaCungCap))
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
            return View(nhaCungCapModel);
        }

        // GET: Supplier/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("admin") == null)
            {
                return RedirectToAction("Index");
            }
            if (id == null)
            {
                return NotFound();
            }

            var nhaCungCapModel = await _context.NhaCungCaps
                .FirstOrDefaultAsync(m => m.Id_NhaCungCap == id);
            if (nhaCungCapModel == null)
            {
                return NotFound();
            }

            return View(nhaCungCapModel);
        }

        // POST: Supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhaCungCapModel = await _context.NhaCungCaps.FindAsync(id);
            if (nhaCungCapModel != null)
            {
                _context.NhaCungCaps.Remove(nhaCungCapModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhaCungCapModelExists(int id)
        {
            return _context.NhaCungCaps.Any(e => e.Id_NhaCungCap == id);
        }
    }
}
