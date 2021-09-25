using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalInfoWebApp.Components
{
    public class TechnicalGroupRefComponents : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Pages/Components/_TechnicalGroupRef.cshtml","farhad");
        }
    }
}
