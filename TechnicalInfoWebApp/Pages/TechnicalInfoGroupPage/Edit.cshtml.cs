﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechnicalInfoWebApp.Models;

namespace TechnicalInfoWebApp.Pages.TechnicalInfoGroupPage
{
    public class EditModel : PageModel
    {
        private readonly TechnicalInfoWebApp.Models.TechnicalInfoDBContext _context;

        public EditModel(TechnicalInfoWebApp.Models.TechnicalInfoDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblTechnicalInfoGroup TblTechnicalInfoGroup { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblTechnicalInfoGroup = await _context.TblTechnicalInfoGroups
                .Include(t => t.FldReference).FirstOrDefaultAsync(m => m.FldTechnicalInfoGroupId == id);

            if (TblTechnicalInfoGroup == null)
            {
                return NotFound();
            }
           ViewData["FldReferenceId"] = new SelectList(_context.TblReferences, "FldReferenceId", "FldReferenceTxt");
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

            _context.Attach(TblTechnicalInfoGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblTechnicalInfoGroupExists(TblTechnicalInfoGroup.FldTechnicalInfoGroupId))
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

        private bool TblTechnicalInfoGroupExists(Guid id)
        {
            return _context.TblTechnicalInfoGroups.Any(e => e.FldTechnicalInfoGroupId == id);
        }
    }
}
