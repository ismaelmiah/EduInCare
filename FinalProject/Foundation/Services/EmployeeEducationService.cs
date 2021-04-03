using System;
using System.Collections.Generic;
using System.Linq;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public class EmployeeEducationService: IEmployeeEducationService
    {
        private readonly IManagementUnitOfWork _management;

        public EmployeeEducationService(IManagementUnitOfWork management)
        {
            _management = management;
        }

        public EmployeeEducation GetEmployeeEducation(Guid id)
        {
            return _management.EmployeeEducationRepository.GetById(id);
        }

        public void DeleteEmployeeEducation(Guid id)
        {
            _management.EmployeeEducationRepository.Remove(id);
        }

        public void UpdateEmployeeEducation(EmployeeEducation employee)
        {
            throw new NotImplementedException();
        }

        public void AddEmployeeEducation(EmployeeEducation employee)
        {
            _management.EmployeeEducationRepository.Add(employee);
            _management.Save();
        }

        public IList<EmployeeEducation> GetEducations()
        {
            return _management.EmployeeEducationRepository.GetAll();
        }

        public (int total, int totalDisplay, IList<EmployeeEducation> records) GetEmployeeEducationList(int pageIndex, int pageSize, string searchText,
            string orderBy)
        {
            (IList<EmployeeEducation> data, int total, int totalDisplay) result;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _management.EmployeeEducationRepository.GetDynamic(null,
                    orderBy, "Employee", pageIndex, pageSize);
            }
            else
            {
                result = _management.EmployeeEducationRepository.GetDynamic(x => x.Major == searchText, orderBy, "Employee", pageIndex, pageSize);
            }

            var data = (from x in result.data
                select new EmployeeEducation
                {
                    Id = x.Id,
                    EducationLevel = x.EducationLevel,
                    ExamTitle = x.ExamTitle,
                    Major = x.Major,
                    InstituteName = x.InstituteName,
                    ResultType = x.ResultType,
                    Cgpa = x.Cgpa,
                    Scale = x.Scale,
                    Marks = x.Marks,
                    PassingYear = x.PassingYear,
                    Duration = x.Duration,
                    //Employee = x.Employee
                }).ToList();

            return (result.total, result.totalDisplay, data);
        }
    }
}