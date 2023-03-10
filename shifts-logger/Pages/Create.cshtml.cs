using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using shifts_logger.Data;
using shifts_logger.Models;

namespace shifts_logger.Pages
{
    public class CreateModel : PageModel
    {
        private readonly shifts_logger.Data.ShiftLogsContext _context;

        public CreateModel(shifts_logger.Data.ShiftLogsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ShiftLogs ShiftLogs { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.shiftLogs == null || ShiftLogs == null)
            {
                return Page();
            }

            _context.shiftLogs.Add(ShiftLogs);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
