using System;
using System.Collections.Generic;
using System.Linq;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public class ApplicantsService : IApplicantsService
    {
        private readonly IManagementUnitOfWork _management;

        public ApplicantsService(IManagementUnitOfWork management)
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
                    orderBy, "", pageIndex, pageSize);

            }
            else
            {
                result = _management.ApplicantRepository.GetDynamic(x => x.FirstName == searchText,
                    orderBy, "", pageIndex, pageSize);
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
    }
}