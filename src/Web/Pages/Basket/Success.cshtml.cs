using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Microsoft.eShopWeb.Web.Pages.Basket;

[Authorize]
public class SuccessModel : PageModel
{
    public void OnGet()
    {
        // Сторінка успішного оформлення замовлення не потребує додаткової логіки,
        // лише відображає інформацію про успішне завершення покупки.
    }
}
