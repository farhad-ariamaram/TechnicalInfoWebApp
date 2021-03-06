using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechnicalInfoWebApp.Models;

namespace TechnicalInfoWebApp.Pages.TechnicalInfoDataTypesValuePage
{
    public class CreateModel : PageModel
    {
        private readonly TechnicalInfoWebApp.Models.TechnicalInfoDBContext _context;

        public CreateModel(TechnicalInfoWebApp.Models.TechnicalInfoDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FldTechnicalInfoDataTypesId"] = new SelectList(_context.TblTechnicalInfoDataTypes, "FldTechnicalInfoDataTypesId", "FldTechnicalInfoDataTypesTxt");
            return Page();
        }

        [BindProperty]
        public TblTechnicalInfoDataTypesValue TblTechnicalInfoDataTypesValue { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TblTechnicalInfoDataTypesValues.Add(TblTechnicalInfoDataTypesValue);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
