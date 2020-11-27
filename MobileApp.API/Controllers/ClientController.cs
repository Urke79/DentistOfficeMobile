using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobileApp.API.Data;
using MobileApp.API.Data.Interfaces;

namespace MobileApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IBaseRepository<Client> _repository;

        public ClientController(ILogger<ClientController> logger, IBaseRepository<Client> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Client> GetAll()
        {
            return _repository.GetAll();
        }

        [HttpPost]
        public void Post(Client client)
        {
            _repository.SaveEntity(client);
        }

        [HttpDelete]
        public void Delete(Client client)
        {
            _repository.DeleteEntity(client);
        }

        [HttpPut]
        public void Put(Client client)
        {
            _repository.UpdateEntity(client);
        }
    }
}
