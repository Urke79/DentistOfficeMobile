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
    public class InterventionController : ControllerBase
    {
        private readonly ILogger<InterventionController> _logger;
        private readonly IInterventionRepository _repository;

        public InterventionController(ILogger<InterventionController> logger, IInterventionRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        [Route("{clientId}")]
        public IEnumerable<Intervention> GetAllForClient(int clientId)
        {
            return _repository.GetInterventions(clientId);
        }

        [HttpGet]
        [Route("GetPayedAmmountForCurrentMonth/{dateFrom}/{dateTo}")]
        public decimal GetPayedAmmountForCurrentMonth(DateTime dateFrom, DateTime dateTo)
        {
            return _repository.GetPayedAmmountForCurrentMonth(dateFrom, dateTo);
        }

        [HttpGet]
        public Intervention Get(object id)
        {
            return _repository.GetById(id);
        }

        [HttpPost]
        public void Post(Intervention intervention)
        {
            _repository.SaveEntity(intervention);
        }

        [HttpDelete]
        public void Delete(Intervention intervention)
        {
            _repository.DeleteEntity(intervention);
        }

        [HttpPut]
        public void Put(Intervention intervention)
        {
            _repository.UpdateEntity(intervention);
        }
    }
}
