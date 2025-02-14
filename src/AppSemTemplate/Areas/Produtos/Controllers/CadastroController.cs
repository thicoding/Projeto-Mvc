using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AppSemTemplate.Areas.Vendas.Controllers{

    [Area("Produtos")]
    public class CadastroController : Controller{

        public IActionResult Index(){
            return View();
        }
    }
}