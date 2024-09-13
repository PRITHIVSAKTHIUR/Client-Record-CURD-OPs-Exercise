using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ClientsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public List<Client> GetClients()
        {
            return context.Clients.OrderBy(c => c.Id).ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetClients(int id)
        {
            var client = context.Clients.Find(id);
            if (client == null)

            {
                return NotFound();
            }
            return Ok(client);
        }



        [HttpPost]
        public IActionResult CreateClient(ClientDto clientDto)
        {
            var otherClient = context.Clients.FirstOrDefault(c => c.Email == clientDto.Email);
            if (otherClient != null)
            {
                ModelState.AddModelError("Email", errorMessage: "The Email Address Used is already have an account, Try Different Email Account");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }

            var client = new Client
            {
                FirstName = clientDto.FirstName,
                LastName = clientDto.LastName,
                Email = clientDto.Email,
                Phone = clientDto.Phone?? "",
                Address = clientDto.Address?? "",
                Status = clientDto.Status,
                CreateAt = DateTime.Now,
            };


            context.Clients.Add(client);    
            context.SaveChanges();      
            return Ok(client);
        }
       

        [HttpPut("{id}")]
        public IActionResult EditClient(int id, ClientDto clientDto)
        {
            var otherClient = context.Clients.FirstOrDefault(c => c.Id != id && c.Email == clientDto.Email);
            if (otherClient != null)
            {
                ModelState.AddModelError("Email", "The Email Address Used is already have an account, Try Different Account");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }

            var client = context.Clients.Find(id); 
            if (client == null)
            {
               return NotFound();
            }

            client.FirstName = clientDto.FirstName;
            client.LastName = clientDto.LastName;
            client.Email = clientDto.Email;
            client.Phone = clientDto.Phone ?? "";
            client.Address = clientDto.Address ?? "";
            client.Status = clientDto.Status;

            context.SaveChanges();
            return Ok(client);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            var client = context.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            context.Clients.Remove(client);
            context.SaveChanges();

            return Ok();
        }
    }
}
