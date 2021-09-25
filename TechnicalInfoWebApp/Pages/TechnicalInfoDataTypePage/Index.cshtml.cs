﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TechnicalInfoWebApp.Models;

namespace TechnicalInfoWebApp.Pages.TechnicalInfoDataTypePage
{
    public class IndexModel : PageModel
    {
        private readonly TechnicalInfoWebApp.Models.TechnicalInfoDBContext _context;

        public IndexModel(TechnicalInfoWebApp.Models.TechnicalInfoDBContext context)
        {
            _context = context;
        }

        public IList<TblTechnicalInfoDataType> TblTechnicalInfoDataType { get;set; }

        public async Task OnGetAsync()
        {
            TblTechnicalInfoDataType = await _context.TblTechnicalInfoDataTypes
                .Include(t => t.FldDataDisplayType)
                .Include(t => t.FldParameters).ToListAsync();
        }
    }
}
