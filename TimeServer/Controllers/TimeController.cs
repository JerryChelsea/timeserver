using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnTimeClasses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeServer.Controllers
{
    [ApiController]
    [EnableCors("AllPolicy")]
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

        [Route("/time/customers")]
        [EnableCors("AllPolicy")]
        [HttpGet()]
        [AllowAnonymous]
        public async Task<List<Customer>> GetCustomers()
        {
            return  await _service.GetCustomers();
        }

        [Route("/time/customer/{id}")]
        [HttpGet()]
        public Customer GetCustomer(int id)
        {
            return _service.GetCustomer(id);
        }

        [Route("/time/customer/")]
        [HttpPost()]
        public async Task<IActionResult> SaveCustomer([FromBody] Customer cust)
        {
            try
            {
                await _service.SaveCustomer(cust);
                return Ok();
            }
            catch (Exception ex)
            {
                var p = new BadRequestObjectResult(ex);
                p.Value = ex.Message;
                return p;
            }
        }

        [Route("/time/customer/")]
        [HttpPut()]
        public async Task<IActionResult> UpdateCustomer([FromBody] Customer cust)
        {
            try
            {
                await _service.UpdateCustomer(cust);
                return Ok();
            }
            catch (Exception ex)
            {
                var p = new BadRequestObjectResult(ex);
                p.Value = ex.Message;
                return p;
            }
        }

        [Route("/time/projects/{id}")]
        [HttpGet()]
        public List<Project> GetProjects(int id)
        {
            return _service.GetProjects(id);
        }

        [Route("/time/project/{id}")]
        [HttpGet()]
        public Project GetProject(int id)
        {
            return _service.GetProject(id);
        }

        [Route("/time/project/{id}")]
        [HttpPost()]
        public async Task<IActionResult> SaveProject([FromBody] Project project, int id)
        {
            try
            {
                await _service.SaveProject(project, id);
                return Ok();
            }
            catch (Exception ex)
            {
                var p = new BadRequestObjectResult(ex);
                p.Value = ex.Message;
                return p;
            }
        }

        [Route("/time/project/")]
        [HttpPut()]
        public async Task<IActionResult> UpdateProject([FromBody] Project project)
        {
            try
            {
                await _service.UpdateProject(project);
                return Ok();
            }
            catch (Exception ex)
            {
                var p = new BadRequestObjectResult(ex);
                p.Value = ex.Message;
                return p;
            }
        }


        [Route("/time/features/{id}")]
        [HttpGet()]
        public List<Feature> GetFeatures(int id)
        {
            return _service.GetFeatures(id);
        }

        [Route("/time/feature/{id}")]
        [HttpGet()]
        public Feature GetFeature(int id)
        {
            return _service.GetFeature(id);
        }

        [Route("/time/savefeature/")]
        [HttpPost()]
        public async Task<IActionResult> SaveFeature([FromBody] Feature feature)
        {
            try
            {
                await _service.SaveFeature(feature);
                return Ok();
            }
            catch (Exception ex)
            {
                var p = new BadRequestObjectResult(ex);
                p.Value = ex.Message;
                return p;
            }
        }

        [Route("/time/feature/")]
        [HttpPut()]
        public async Task<IActionResult> UpdateFeature([FromBody] Feature feature)
        {
            try
            {
                await _service.UpdateFeature(feature);
                return Ok();
            }
            catch (Exception ex)
            {
                var p = new BadRequestObjectResult(ex);
                p.Value = ex.Message;
                return p;
            }
        }

        [Route("/time/feature/{id}")]
        [HttpDelete()]
        public IActionResult DeleteFeature(int id)
        {
            try
            {
                _service.DeleteFeature(id);
                return Ok();
            }
            catch (Exception ex)
            {
                var p = new BadRequestObjectResult(ex);
                p.Value = ex.Message;
                return p;
            }
        }

        [Route("/time/custfeatures/{id}")]
        [HttpGet()]
        public async Task<List<Feature>> GetCustomerFeatures(int id)
        {
            try
            {
                return await _service.GetCustomerFeatures(id);
            }
            catch (Exception ex)
            {
                return new List<Feature>();
            }
        }

        [Route("/time/worklogs/{id}")]
        [HttpGet()]
        public List<WorkLog> GetWorkLogs(int id)
        {
            return _service.GetWorkLogs(id);
        }

        [Route("/time/worklog/{id}")]
        [HttpGet()]
        public WorkLog GetWorkLog(int id)
        {
            return _service.GetWorkLog(id);
        }

        [Route("/time/worklog")]
        [HttpPost()]
        public async Task<IActionResult> SaveWorklog([FromBody] WorkLog worklog)
        {
            try
            {
                await _service.SaveWorkLog(worklog);
                return Ok();
            }
            catch (Exception ex)
            {
                var p = new BadRequestObjectResult(ex);
                p.Value = ex.Message;
                return p;
            }
        }

        [Route("/time/worklog")]
        [HttpPut()]
        public async Task<IActionResult> UpdateWorklog([FromBody] WorkLog worklog)
        {
            try
            {
                await _service.UpdateWorkLog(worklog);
                return Ok();
            }
            catch (Exception ex)
            {
                var p = new BadRequestObjectResult(ex);
                p.Value = ex.Message;
                return p;
            }
        }

        [Route("/time/worklog/{id}")]
        [HttpDelete()]
        public ActionResult DeleteWorkLog(int id)
        {
            try
            { 
                _service.DeleteWorkLog(id);
                return Ok();
            }
            catch (Exception ex)
            {
                var p = new BadRequestObjectResult(ex);
                p.Value = ex.Message;
                return p;
            }
        }

        [Route("/time/projectwork/{id}/{start}/{end}")]
        [HttpGet()]
        public Project GetProjectWorkLog(int id, DateTime start, DateTime end)
        {
            return _service.GetProjectWork(id, start, end);
        }

        [Route("/time/worklogs/{id}/{start}/{end}")]
        [HttpGet()]
        public List<WorkReport> GetWorkReport(int id, DateTime start, DateTime end)
        {
            return _service.GetWorkReport(id, start, end);
        }


    }
}
