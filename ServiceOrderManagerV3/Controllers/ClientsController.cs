using Microsoft.AspNetCore.Mvc;
using ServiceOrderManagerV3.Data;
using ServiceOrderManagerV3.Models;

namespace ServiceOrderManagerV3.Controllers
{
    public class ClientsController : Controller
    {
        private readonly AppDbContext dbContext;

        public ClientsController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // Adiciona novo cliente
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        // Metodo Que acessa o formulario no navegador e envia as informacoes 
        // Adiciona uma nova classe no dir models add
        //
        [HttpPost]
        public IActionResult Add(AddClientViewModel viewModel)
        {
            return View();
        }
    }
}
