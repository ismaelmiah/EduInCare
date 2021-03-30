using System;
using FinalProject.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Web.Areas.Course.Models.ModelBuilder
{
    public class RegistrationModelBuilder
    {
        public object GetRegisteredData(DataTablesAjaxRequestModel tableModel)
        {
            throw new System.NotImplementedException();
        }

        public RegistrationModel BuildRegistrationModel(Guid id)
        {
            throw new NotImplementedException();
        }

        public void SaveRegistration(RegistrationModel model)
        {
            throw new NotImplementedException();
        }

        public void UpdateRegistration(Guid modelId, RegistrationModel model)
        {
            throw new NotImplementedException();
        }

        public void DeleteRegistration(Guid id)
        {
            throw new NotImplementedException();
        }

        public SelectList GetCourseList()
        {
            throw new NotImplementedException();
        }

        public SelectList GetSectionList()
        {
            throw new NotImplementedException();
        }

        public SelectList GetAcademicYearList()
        {
            throw new NotImplementedException();
        }

        public SelectList GetStudentList()
        {
            throw new NotImplementedException();
        }
    }
}