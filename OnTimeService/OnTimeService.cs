using System;
using System.Collections.Generic;
using System.Linq;
using OnTimeClasses;
using OnTimeData;


namespace OnTimeService
{
    public class OnTimeService
    {
        private TimeDataContext _context;

        public OnTimeService(string conn)
        {
            _context = new TimeDataContext();
        }

        public List<Customer> GetCustomers()
        {
            try
            {
               return  _context.OnTimeCustomers.Select(x => 
                     new Customer
                     {
                         CustomerId = x.CustomerId,
                         CustomerName = x.CompanyName
                     }).ToList();
            }
            catch (Exception ex)
            {
                return new List<Customer>();
            }
        }

        public Customer GetCustomer(int id)
        {
            var  C = new Customer();
            var cust = _context.OnTimeCustomers.Where(x => x.CustomerId == id).FirstOrDefault();
            if (cust != null)
            {
                C.CustomerId = cust.CustomerId;
                C.CustomerName = cust.CompanyName;
            }

            return C;
        }

        public List<Project> GetProjects(int customerId)
        {
            
            var query = (from c in _context.OnTimeCustomersProjects
                join p in _context.OnTimeProjects on c.ProjectId equals p.ProjectId
                where c.CustomerId == customerId
                select new Project
                {
                    ProjectId = p.ProjectId,
                    ProjectName = p.Name,
                    CustomerId = c.CustomerId,
                    Description = p.Description,
                    StartDate = p.StartDate,
                    DueDate = p.DueDate,
                    IsActive = p.IsActive
                });
            return query.ToList();
        }

        public Project GetProject(int id)
        {
            var query = (from p in _context.OnTimeProjects
                join c in _context.OnTimeCustomersProjects on p.ProjectId equals c.ProjectId
                where p.ProjectId == id
                select new Project
                {
                    ProjectId = p.ProjectId,
                    ProjectName = p.Name,
                    CustomerId = c.CustomerId,
                    Description = p.Description,
                    StartDate = p.StartDate,
                    DueDate = p.DueDate,
                    IsActive = p.IsActive
                });
            return query.FirstOrDefault();
        }

        public List<Feature> GetFeatures(int project)
        {
            return _context.OnTimeFeatures.Where(x => x.ProjectId == project)
                .Select(x => new Feature
                {
                    ProjectId = x.ProjectId,
                    FeatureId = x.FeatureId,
                    Description = x.Description,
                    Name = x.Name
                }).ToList();
        }

        public Feature GetFeature(int id)
        {
            return  _context.OnTimeFeatures.Where(x => x.FeatureId == id)
                .Select(x => new Feature
                {
                    ProjectId = x.ProjectId,
                    FeatureId = x.FeatureId,
                    Description = x.Description
                }).FirstOrDefault();
        }

        public List<WorkLog> GetWorkLogs(int feature)
        {
            return _context.OnTimeWorkLogs.Where(x => x.ItemId == feature)
                .Select(x => new WorkLog
                {
                    WorkLogId = x.WorkLogId,
                    FeatureId = x.ItemId,
                    Description = x.Description,
                    WorkDone = x.WorkDone,
                    WorkLogDate = x.WorkLogDateTime,
                    WorkTypeId = x.WorkLogTypeId

                }).ToList();
        }

        public WorkLog GetWorkLog(int id)
        {
            return _context.OnTimeWorkLogs.Where(x => x.WorkLogId == id)
                .Select(x => new WorkLog
                {
                    WorkLogId = x.WorkLogId,
                    FeatureId = x.ItemId,
                    Description = x.Description,
                    WorkDone = x.WorkDone,
                    WorkLogDate = x.WorkLogDateTime,
                    WorkTypeId = x.WorkLogTypeId

                }).FirstOrDefault();
        }

        public Project GetProjectWork(int projectid, DateTime start, DateTime end)
        {
                var query = (from p in _context.OnTimeProjects
                    join f in _context.OnTimeFeatures on p.ProjectId equals f.ProjectId
                    join w in _context.OnTimeWorkLogs on f.FeatureId equals w.ItemId
                    join c in _context.OnTimeCustomersProjects on p.ProjectId equals c.ProjectId
                    where w.WorkLogDateTime >= start && w.WorkLogDateTime <= end
                    orderby w.WorkLogDateTime
                    select new Project
                    {
                        CustomerId = c.CustomerId,
                        ProjectId = p.ProjectId,
                        Description = p.Description,
                    }).FirstOrDefault();

                   query.Features = GetFullFeatures(query.ProjectId, start, end );

                return query;
         
        }

        private List<Feature> GetFullFeatures(int id, DateTime start, DateTime end)
        {
            var query = (from f in _context.OnTimeFeatures
                join w in _context.OnTimeWorkLogs on f.FeatureId equals w.ItemId
                where w.WorkLogDateTime >= start && w.WorkLogDateTime <= end
                orderby w.WorkLogDateTime
                select new Feature
                {
                    FeatureId = f.FeatureId,
                    Description = f.Description,
                    ProjectId = f.ProjectId,
                    WorkLogs = GetWorkLogs(f.FeatureId, start, end)                    
                }).ToList();
            return query;
        }

        private List<WorkLog> GetWorkLogs(int id, DateTime start, DateTime end)
        {
            return _context.OnTimeWorkLogs
                .Where(x => x.ItemId == id && x.WorkLogDateTime >= start && x.WorkLogDateTime <= end)
                .Select(x => new WorkLog
                {
                    FeatureId = id,
                    WorkLogId = x.WorkLogId,
                    Description = x.Description,
                    WorkDone = x.WorkDone,
                    WorkLogDate = x.WorkLogDateTime,
                    WorkTypeId = x.WorkLogTypeId
                }).ToList();
        }

        public List<WorkReport> GetWorkReport(int id, DateTime start, DateTime end)
        {
            var query = (from p in _context.OnTimeProjects
                join f in _context.OnTimeFeatures on p.ProjectId equals f.ProjectId
                join w in _context.OnTimeWorkLogs on f.FeatureId equals w.ItemId
                join c in _context.OnTimeCustomersProjects on p.ProjectId equals c.ProjectId
                join cm in _context.OnTimeCustomers on c.CustomerId equals cm.CustomerId
                where w.WorkLogDateTime >= start && w.WorkLogDateTime <= end
                && c.CustomerId == id
                select new WorkReport
                {
                    CustomerName = cm.CompanyName,
                    ProjectName = p.Name,
                    FeatureName = f.Name,
                    Description = w.Description,
                    WorkDate = w.WorkLogDateTime,
                    WorkDay = (int)w.WorkLogDateTime.DayOfWeek,
                    WorkDone = w.WorkDone,
                    WorkTypeId = w.WorkLogTypeId.HasValue ? w.WorkLogTypeId.Value : 0

                }).OrderBy(x => x.WorkDate).ToList();

            return query;
         
        }
    }
}
