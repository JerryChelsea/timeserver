using System;
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

        [Route("/projects/{id}")]
        [HttpGet()]
        public List<Project> GetProjects(int id)
        {
            return _service.GetProjects(id);
        }

        [Route("/project/{id}")]
        [HttpGet()]
        public Project GetProject(int id)
        {
            return _service.GetProject(id);
        }

        [Route("/features/{id}")]
        [HttpGet()]
        public List<Feature> GetFeatures(int id)
        {
            return _service.GetFeatures(id);
        }

        [Route("/feature/{id}")]
        [HttpGet()]
        public Feature GetFeature(int id)
        {
            return _service.GetFeature(id);
        }

        [Route("/worklogs/{id}")]
        [HttpGet()]
        public List<WorkLog> GetWorkLogs(int id)
        {
            return _service.GetWorkLogs(id);
        }

        [Route("/worklog/{id}")]
        [HttpGet()]
        public WorkLog GetWorkLog(int id)
        {
            return _service.GetWorkLog(id);
        }

        [Route("/projectwork/{id}/{start}/{end}")]
        [HttpGet()]
        public Project GetProjectWorkLog(int id, DateTime start, DateTime end)
        {
            return _service.GetProjectWork(id, start, end);
        }

        [Route("/workreport/{id}/{start}/{end}")]
        [HttpGet()]
        public List<WorkReport> GetWorkReport(int id, DateTime start, DateTime end)
        {
            return _service.GetWorkReport(id, start, end);
        }


    }
}
