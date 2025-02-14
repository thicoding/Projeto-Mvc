using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AppSemTemplate.Controllers{

    public class CounterViewComponent : ViewComponent{

        public async Task<IViewComponentResult> InvokeAsync(int modelCounter)
        {
            return View(modelCounter);


        }

    }
}