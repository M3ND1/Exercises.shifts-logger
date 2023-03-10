using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using shifts_logger.Data;
using shifts_logger.Models;

namespace shifts_logger.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly shifts_logger.Data.ShiftLogsContext _context;

        public DeleteModel(shifts_logger.Data.ShiftLogsContext context)
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

            var shiftlogs = await _context.shiftLogs.FirstOrDefaultAsync(m => m.ID == id);

            if (shiftlogs == null)
            {
                return NotFound();
            }
            else 
            {
                ShiftLogs = shiftlogs;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.shiftLogs == null)
            {
                return NotFound();
            }
            var shiftlogs = await _context.shiftLogs.FindAsync(id);

            if (shiftlogs != null)
            {
                ShiftLogs = shiftlogs;
                _context.shiftLogs.Remove(ShiftLogs);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
