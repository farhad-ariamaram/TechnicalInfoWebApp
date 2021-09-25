﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechnicalInfoWebApp.Models;

namespace TechnicalInfoWebApp.Pages.TechnicalInfoPage
{
    public class EditModel : PageModel
    {
        private readonly TechnicalInfoWebApp.Models.TechnicalInfoDBContext _context;

        public EditModel(TechnicalInfoWebApp.Models.TechnicalInfoDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblTechnicalInfo TblTechnicalInfo { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblTechnicalInfo = await _context.TblTechnicalInfos
                .Include(t => t.FldTechnicalInfoDataTypes)
                .Include(t => t.FldTechnicalInfoGroup).FirstOrDefaultAsync(m => m.FldTechnicalInfoId == id);

            if (TblTechnicalInfo == null)
            {
                return NotFound();
            }
           ViewData["FldTechnicalInfoDataTypesId"] = new SelectList(_context.TblTechnicalInfoDataTypes, "FldTechnicalInfoDataTypesId", "FldTechnicalInfoDataTypesTxt");
           ViewData["FldTechnicalInfoGroupId"] = new SelectList(_context.TblTechnicalInfoGroups, "FldTechnicalInfoGroupId", "FldTechnicalInfoGroupTxt");
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

            _context.Attach(TblTechnicalInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblTechnicalInfoExists(TblTechnicalInfo.FldTechnicalInfoId))
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

        private bool TblTechnicalInfoExists(Guid id)
        {
            return _context.TblTechnicalInfos.Any(e => e.FldTechnicalInfoId == id);
        }
    }
}
