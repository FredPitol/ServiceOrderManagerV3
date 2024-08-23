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

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var client = await dbContext.Clients.ToListAsync();

            return View(client);
        }
        // Editando cliente
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await dbContext.Clients.FindAsync(id);
            // Seleciona view e clica e addView
            return View();
        }

        // A ediçao irá seguir a mesma lógica do adicionar, pegando os dados do relátorio, vamos fazer o post para salvar as alterações
        [HttpPost]
        public async Task<IActionResult> Edit(Client viewModel)
        {
            // Recebe valores inseridos no formulário
            var client = await dbContext.Clients.FindAsync(viewModel.Id);
            // Checar informaçoes inseridas  
            if (client is not null)
            {
                client.Name = viewModel.Name;
                client.Cnpj = viewModel.Cnpj;
                client.Email = viewModel.Email;
                client.Address = viewModel.Address;

                // Salva alterações
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Clients");
        }
    }
}
