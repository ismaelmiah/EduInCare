using System;
using System.Collections.Generic;
using Foundation.Library.Entities;

namespace Foundation.Library.Services
{
    public interface IJobInfoService
    {
        JobInfo GetJobInfoWithoutTrack(Guid id);
        JobInfo GetJobInfo(Guid id);
        void Delete(Guid id);
        void Update(JobInfo jobInfo);
        void AddEmployee(JobInfo jobInfo);

        (int total, int totalDisplay, IList<JobInfo> records) GetEmployeeList(int pageIndex, int pageSize, string searchText, string orderBy);

        IList<JobInfo> GetAllJobInfos();
    }
}