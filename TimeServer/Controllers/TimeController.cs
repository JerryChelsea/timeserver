using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnTimeClasses;
using System.Collections.Generic;
using OnTimeService;

namespace TimeServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeController : ControllerBase
    {
        private OnTimeService.OnTimeService _service;


        private readonly ILogger<TimeController> _logger;

        public TimeController(ILogger<TimeController> logger)
        {
            _logger = logger;
            _service = new OnTimeService.OnTimeService();
        }

        [HttpGet()]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("/customers")]
        [HttpGet()]
        public List<Customer> GetCustomers()
        {
            return _service.GetCustomers();
        }

        [Route("/customer/{id}")]
        [HttpGet()]
        public Customer GetCustomer(int id)
        {
            return _service.GetCustomer(id);
        }
    }
}
