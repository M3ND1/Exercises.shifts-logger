using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using shifts_logger.Data;
using shifts_logger.Models;

namespace shifts_logger.Pages
{
    public class EditModel : PageModel
    {
        private readonly shifts_logger.Data.ShiftLogsContext _context;

        public EditModel(shifts_logger.Data.ShiftLogsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ShiftLogs ShiftLogs { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.shiftLogs == null)
            {
                return NotFound();
            }

            var shiftlogs =  await _context.shiftLogs.FirstOrDefaultAsync(m => m.ID == id);
            if (shiftlogs == null)
            {
                return NotFound();
            }
            ShiftLogs = shiftlogs;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ShiftLogs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShiftLogsExists(ShiftLogs.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ShiftLogsExists(int id)
        {
          return (_context.shiftLogs?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
