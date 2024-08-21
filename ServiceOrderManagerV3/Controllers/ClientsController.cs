using Microsoft.AspNetCore.Mvc;
using ServiceOrderManagerV3.Data;
using ServiceOrderManagerV3.Models;
using ServiceOrderManagerV3.Models.Entities;
using System.Runtime.CompilerServices;

namespace ServiceOrderManagerV3.Controllers
{
    public class ClientsController : Controller
    {
        // Criado pelo create assign, nao e necessario estanciar objeto, a injecao de dependencia faz esse trabalho
        private readonly AppDbContext dbContext;

        // Injetando db context, apos fazer o construtor clicamos na var dbContext -> ctrl + . -> Create and assign this field
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
        public async Task<IActionResult> Add(AddClientViewModel viewModel)
        {
            //Objeto que sera enviado para o banco de dados
            var client = new Client
            {
                // Nao necessita do id devido ao entity framework
                Name = viewModel.Name,
                Cnpj = viewModel.Cnpj,
                Email = viewModel.Email,
                Address = viewModel.Address

            };

            // Adiciona o cliente no banco de dados
            await dbContext.Clients.AddAsync(client);
            await dbContext.SaveChangesAsync();

            return View();
        }
        // Trazemos as informacoes do formulario da view para memoria temporaria do programa para enviar para o banco de dados
        // Para isso precismos injetar a dbcontext no controller, vamos criar um construtor para isso(ClientsController)
    }
}
