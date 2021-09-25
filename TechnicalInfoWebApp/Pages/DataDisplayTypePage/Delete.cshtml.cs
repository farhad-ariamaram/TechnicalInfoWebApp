using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TechnicalInfoWebApp.Models;

namespace TechnicalInfoWebApp.Pages.DataDisplayTypePage
{
    public class DeleteModel : PageModel
    {
        private readonly TechnicalInfoWebApp.Models.TechnicalInfoDBContext _context;

        public DeleteModel(TechnicalInfoWebApp.Models.TechnicalInfoDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblDataDisplayType TblDataDisplayType { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblDataDisplayType = await _context.TblDataDisplayTypes.FirstOrDefaultAsync(m => m.FldDataDisplayTypeId == id);

            if (TblDataDisplayType == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblDataDisplayType = await _context.TblDataDisplayTypes.FindAsync(id);

            if (TblDataDisplayType != null)
            {
                _context.TblDataDisplayTypes.Remove(TblDataDisplayType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
