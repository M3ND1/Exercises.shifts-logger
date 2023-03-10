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
    public class DetailsModel : PageModel
    {
        private readonly shifts_logger.Data.ShiftLogsContext _context;

        public DetailsModel(shifts_logger.Data.ShiftLogsContext context)
        {
            _context = context;
        }

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
    }
}
