using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceOrderManagerV3.Data;
using ServiceOrderManagerV3.Models;
using ServiceOrderManagerV3.Models.Entities;
using System.Runtime.CompilerServices;

namespace ServiceOrderManagerV3.Controllers
{
    public class ClientsController : Controller
    {
       
        private readonly AppDbContext dbContext;

        public ClientsController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
     
        [HttpPost]
        public async Task<IActionResult> Add(AddClientViewModel viewModel)
        {
            var client = new Client
            {
                Name = viewModel.Name,
                Cnpj = viewModel.Cnpj,
                Email = viewModel.Email,
                Address = viewModel.Address
            };
            await dbContext.Clients.AddAsync(client);
            await dbContext.SaveChangesAsync();
            return View();
        }
        //1. Fazer nova pagina com lista dos clientes adicionados
        //2. Fazer a rota para nova pagina
        //3. Fazer a action para nova pagina
        [HttpGet]
         public async Task <IActionResult> List()
        {
            var client = await dbContext.Clients.ToListAsync();

            return View(client);
        }
    }
}
