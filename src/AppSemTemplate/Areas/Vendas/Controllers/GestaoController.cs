using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AppSemTemplate.Areas.Vendas.Controllers{

    [Area("Vendas")]
    public class GestaoController : Controller{

        public IActionResult Index(){
            return View();
        }
    }
}