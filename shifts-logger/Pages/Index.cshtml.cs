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
    public class IndexModel : PageModel
    {
        private readonly shifts_logger.Data.ShiftLogsContext _context;

        public IndexModel(shifts_logger.Data.ShiftLogsContext context)
        {
            _context = context;
        }

        public IList<ShiftLogs> ShiftLogs { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.shiftLogs != null)
            {
                ShiftLogs = await _context.shiftLogs.ToListAsync();
            }
        }
    }
}
