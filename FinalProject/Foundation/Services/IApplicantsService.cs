using System;
using System.Collections.Generic;
using Foundation.Library.Entities;

namespace Foundation.Library.Services
{
    public interface IApplicantService
    {
        void AddApplicant(Applicants applicants);
        (int total, int totalDisplay, IList<Applicants> records) GetApplicantsList(int pageIndex, int pageSize, string searchText, string orderBy);

        void Delete(Guid id);
        Applicants GetApplicant(Guid id);
        void Update(Applicants applicants);
        IList<Applicants> GetApplicants();

        void ApproveApplication(Applicants applicants);
        void RejectApplication(Applicants applicants);
    }
}