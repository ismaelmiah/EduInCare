using System;
using System.Collections.Generic;
using System.Linq;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IManagementUnitOfWork _management;

        public ApplicantService(IManagementUnitOfWork management)
        {
            _management = management;
        }

        public void AddApplicant(Applicants applicants)
        {
            _management.ApplicantRepository.Add(applicants);
            _management.Save();
        }

        public (int total, int totalDisplay, IList<Applicants> records) GetApplicantsList(int pageIndex, int pageSize, string searchText,
            string orderBy)
        {
            (IList<Applicants> data, int total, int totalDisplay) result;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _management.ApplicantRepository.GetDynamic(null,
                    orderBy, "Course,RecordMeta", pageIndex, pageSize);

            }
            else
            {
                result = _management.ApplicantRepository.GetDynamic(x => x.MobileNo == searchText,
                    orderBy, "Course,RecordMeta", pageIndex, pageSize);
            }

            var data = (from x in result.data
                select new Applicants
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    LastName = x.LastName,
                    Gender = x.Gender,
                    MobileNo = x.MobileNo,
                    DateOfBirth = x.DateOfBirth,
                    BirthCertificateNo = x.BirthCertificateNo,
                    NationalIdentificationNo = x.NationalIdentificationNo,
                    Nationality = x.Nationality,
                    CourseId = x.CourseId,
                    Course = x.Course,
                    RecordMeta = x.RecordMeta,
                    Status = x.Status
                }).ToList();

            return (result.total, result.totalDisplay, data);
        }

        public void Delete(Guid id)
        {
            _management.StudentRepository.Remove(id);
            _management.Save();
        }

        public Applicants GetApplicant(Guid id)
        {
            return _management.ApplicantRepository.GetById(id);
        }

        public void Update(Applicants applicants)
        {
            _management.ApplicantRepository.Edit(applicants);
            _management.Save();
        }

        public IList<Applicants> GetApplicants()
        {
            return _management.ApplicantRepository.GetAll();
        }

        public void ApproveApplication(Applicants applicants)
        {
            _management.ApplicantRepository.Edit(applicants);
            _management.Save();
        }

        public void RejectApplication(Applicants applicants)
        {
            _management.ApplicantRepository.Edit(applicants);
            _management.Save();
        }
    }
}