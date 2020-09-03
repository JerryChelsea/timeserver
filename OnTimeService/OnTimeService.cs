using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.XPath;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using OnTimeClasses;
using OnTimeData;
using OnTimeData.Data;


namespace OnTimeService
{
    public class OnTimeService
    {
        private TimeDataContext _context;

        public OnTimeService()
        {
            _context = new TimeDataContext();
        }

        public async Task<List<Customer>> GetCustomers()
        {
            try
            {
                return await _context.OnTimeCustomers.Select(x =>
                    new Customer
                    {
                        CustomerId = x.CustomerId,
                        CustomerName = x.CompanyName
                    }).OrderBy(c =>c.CustomerName).ToListAsync();
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

        public async Task SaveCustomer(Customer customer)
        {
            var C = new TimeData.OnTimeCustomers();
            C.CompanyName = customer.CustomerName;
            _context.OnTimeCustomers.Add(C);
           await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomer(Customer customer)
        {
            var C = _context.OnTimeCustomers.FirstOrDefault(x => x.CustomerId == customer.CustomerId);
            if (C != null)
            {
                C.CompanyName = customer.CustomerName;
                _context.OnTimeCustomers.Update(C);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("No Customer found");
            }
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
            return query.OrderBy(x => x.ProjectName).ToList();
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

        public async Task SaveProject(Project project, int customerId)
        {
            var projId = _context.OnTimeProjects.Max(x => x.ProjectId) + 1;
            var F = new TimeData.OnTimeProjects();
            F.Description = project.Description;
            F.Name = project.ProjectName;
            F.ProjectId = projId;
            _context.OnTimeProjects.Add(F);

            var T = new TimeData.OnTimeCustomersProjects();
            T.CustomerId = customerId;
            T.ProjectId = F.ProjectId;
            _context.OnTimeCustomersProjects.Add(T);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProject(Project project)
        {
            var F = _context.OnTimeProjects.FirstOrDefault(p => p.ProjectId == project.ProjectId);
            try
            {
                if (F != null)
                {
                    F.Description = project.Description;
                    F.Name = project.ProjectName;
                    _context.OnTimeProjects.Update(F);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Project not in database");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Feature> GetFeatures(int project)
        {
            var fs = _context.OnTimeFeatures.Where(x => x.ProjectId == project)
                .Select(x => new Feature
                {
                    ProjectId = x.ProjectId,
                    FeatureId = x.FeatureId,
                    Description = x.Description,
                    Name = x.Name
                }).ToList();
            return fs.OrderBy(x => x.Name).ToList();
        }

        public Feature GetFeature(int id)
        {
            return  _context.OnTimeFeatures.Where(x => x.FeatureId == id)
                .Select(x => new Feature
                {
                    ProjectId = x.ProjectId,
                    FeatureId = x.FeatureId,
                    Description = x.Description,
                    Name = x.Name
                }).FirstOrDefault();
        }

        public async Task SaveFeature(Feature feature)
        {
            var id = _context.OnTimeFeatures.Max(x => x.FeatureId) + 1;
            var F = new TimeData.OnTimeFeatures();
            F.Description = feature.Description;
            F.FeatureId = id;
            F.ProjectId = feature.ProjectId;
            F.Name = feature.Name;

            _context.OnTimeFeatures.Add(F);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFeature(Feature feature)
        {
            var F = _context.OnTimeFeatures.FirstOrDefault(x => x.FeatureId == feature.FeatureId);
            if (F != null)
            {
                F.Description = feature.Description;
                F.ProjectId = feature.ProjectId;
                F.Name = feature.Name;

                _context.OnTimeFeatures.Update(F);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Feature not found");
            }
        }

        public void DeleteFeature(int id)
        {
            var links = _context.OnTimeWorkLog.FirstOrDefault(x => x.ItemId == id);
            if (links != null)
            {
                throw new Exception("Cannot delete this Feature - it is linked to Work items");
            }

            var f = _context.OnTimeFeatures.FirstOrDefault(x => x.FeatureId == id);
            if (f != null)
            {
                _context.OnTimeFeatures.Remove(f);
                _context.SaveChanges();
            }
        }

        public List<WorkLog> GetWorkLogs(int feature)
        {
            return _context.OnTimeWorkLog.Where(x => x.ItemId == feature)
                .Select(x => new WorkLog
                {
                    WorkLogId = x.WorkLogId,
                    FeatureId = x.ItemId,
                    Description = x.Description,
                    WorkDone = x.WorkDone,
                    WorkLogDate = x.WorkLogDateTime,
                    WorkTypeId = x.WorkLogTypeId

                }).OrderBy(x => x.WorkLogDate).ToList();
        }

        public WorkLog GetWorkLog(int id)
        {
            return _context.OnTimeWorkLog.Where(x => x.WorkLogId == id)
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

        public async Task SaveWorkLog(WorkLog worklog)
        {
            var F = new TimeData.OnTimeWorkLog();

            F.Description = worklog.Description;
            F.WorkDone = worklog.WorkDone;
            F.WorkLogDateTime = worklog.WorkLogDate;
            F.ItemId = worklog.FeatureId;

            _context.OnTimeWorkLog.Add(F);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateWorkLog(WorkLog worklog)
        {
            var F = _context.OnTimeWorkLog.FirstOrDefault(x => x.WorkLogId == worklog.WorkLogId);
            if (F != null)
            {
                F.Description = worklog.Description;
                F.WorkDone = worklog.WorkDone;
                F.WorkLogDateTime = worklog.WorkLogDate;

                _context.OnTimeWorkLog.Update(F);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Worklog  not found");
            }
        }

        public void DeleteWorkLog(int workId)
        {
            var w = _context.OnTimeWorkLog.FirstOrDefault(x => x.WorkLogId == workId);
            if (w != null)
            {
                _context.OnTimeWorkLog.Remove(w);
                _context.SaveChanges();
            }
        }


        public Project GetProjectWork(int projectid, DateTime start, DateTime end)
        {
                var query = (from p in _context.OnTimeProjects
                    join f in _context.OnTimeFeatures on p.ProjectId equals f.ProjectId
                    join w in _context.OnTimeWorkLog on f.FeatureId equals w.ItemId
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

        public async Task<List<Feature>> GetCustomerFeatures(int custId)
        {
            var query = (from p in _context.OnTimeProjects
                join f in _context.OnTimeFeatures on p.ProjectId equals f.ProjectId
                join cp in _context.OnTimeCustomersProjects on p.ProjectId equals cp.ProjectId
                where cp.CustomerId == custId
                select new Feature
                {
                    FeatureId = f.FeatureId,
                    ProjectId = cp.ProjectId,
                    ProjectName = p.Name,
                    Name = f.Name,
                    Description = f.Description
                });
            return await query.OrderBy(f => f.Name).ToListAsync();
        }


        private List<Feature> GetFullFeatures(int id, DateTime start, DateTime end)
        {
            var query = (from f in _context.OnTimeFeatures
                join w in _context.OnTimeWorkLog on f.FeatureId equals w.ItemId
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
            return _context.OnTimeWorkLog
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
                join w in _context.OnTimeWorkLog on f.FeatureId equals w.ItemId
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

                }).OrderBy(x => x.WorkDate).ThenBy(x => x.FeatureName).ToList();

            return query;
         
        }

        public OnTimeUserDefaults GeTimeUserDefaults(Guid userid)
        {
            return _context.OnTimeUserDefaults.FirstOrDefault();
        }
    }
}
