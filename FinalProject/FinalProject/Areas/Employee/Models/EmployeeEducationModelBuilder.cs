using System;
using Autofac;
using Foundation.Library.Entities;
using Foundation.Library.Services;

namespace FinalProject.Web.Areas.Employee.Models
{
    public class EmployeeEducationModelBuilder
    {
        private readonly IEmployeeEducationService _employeeEducationService;

        public EmployeeEducationModelBuilder(IEmployeeEducationService employeeEducationService)
        {
            _employeeEducationService = employeeEducationService;
        }
        public EmployeeEducationModelBuilder()
        {
            _employeeEducationService = Startup.AutofacContainer.Resolve<IEmployeeEducationService>();
        }
        public void UpdateEmployeeEducation(object id, EmployeeEducationModel model)
        {
            throw new System.NotImplementedException();
        }

        public void SaveEmployeeEducation(EmployeeEducationModel model)
        {
            EmployeeEducation entity = ConvertToEntity(model);
            _employeeEducationService.AddEmployeeEducation(entity);
        }

        private EmployeeEducation ConvertToEntity(EmployeeEducationModel model)
        {
            return new EmployeeEducation
            {
                //EmployeeId = model.EmployeeId,
                ExamTitleId = model.ExamTitleId,
                EducationLevelId = model.EducationLevelId,
                Achievement = model.Achievement,
                Cgpa = model.Cgpa,
                Duration = model.Duration,
                Major = model.Major,
                Scale = model.Scale,
                InstituteName = model.InstituteName,
                ResultType = model.ResultType,
                Marks = model.Marks,
                PassingYear = model.PassingYear
            };
        }

        public EmployeeEducationModel BuildEmployeeEducationModel(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}