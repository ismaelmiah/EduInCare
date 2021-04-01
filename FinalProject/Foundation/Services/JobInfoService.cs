using System;
using System.Collections.Generic;
using System.Linq;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public class JobInfoService : IJobInfoService
    {
        private readonly IManagementUnitOfWork _management;

        public JobInfoService(IManagementUnitOfWork management)
        {
            _management = management;
        }
        public JobInfo GetJobInfoWithoutTrack(Guid id)
        {
            return _management.JobInfoRepository
                .Get(x => x.Id == id, null, "", false).FirstOrDefault();
        }

        public JobInfo GetJobInfo(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(JobInfo jobInfo)
        {
            throw new NotImplementedException();
        }

        public void AddEmployee(JobInfo jobInfo)
        {
            _management.JobInfoRepository.Add(jobInfo);
            _management.Save();
        }

        public (int total, int totalDisplay, IList<JobInfo> records) GetEmployeeList(int pageIndex, int pageSize, string searchText,
            string orderBy)
        {
            (IList<JobInfo> data, int total, int totalDisplay) result;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _management.JobInfoRepository.GetDynamic(null,
                    orderBy, "Employee,Designation", pageIndex, pageSize, false);
            }
            else
            {
                result = _management.JobInfoRepository.GetDynamic(x => x.Salary.ToString() == searchText,
                    orderBy, "Employee,Designation", pageIndex, pageSize, false);
            }

            var data = (from x in result.data
                select new JobInfo
                {
                    Id = x.Id,
                    //Employee = x.Employee,
                    Appointment = x.Appointment,
                    //Designation = x.Designation,
                    //DesignationId = x.DesignationId,
                    //EmployeeId = x.EmployeeId,
                    JoiningDate = x.JoiningDate,
                    Salary = x.Salary,
                    TotalLeave = x.TotalLeave
                }).ToList();

            return (result.total, result.totalDisplay, data);
        }

        public IList<JobInfo> GetAllJobInfos()
        {
            throw new NotImplementedException();
        }
    }
}