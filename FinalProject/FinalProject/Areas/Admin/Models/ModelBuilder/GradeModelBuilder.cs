using System;
using Autofac;
using FinalProject.Web.Models;
using Foundation.Library.Services;

namespace FinalProject.Web.Areas.Admin.Models.ModelBuilder
{
    public class GradeModelBuilder
    {
        private readonly IGradeService _gradeService;

        public GradeModelBuilder(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        public GradeModelBuilder()
        {
            _gradeService = Startup.AutofacContainer.Resolve<IGradeService>();
        }
        public void SaveGrade(GradeModel model)
        {
            throw new NotImplementedException();
        }

        public void UpdateGrade(Guid id, GradeModel model)
        {
            throw new NotImplementedException();
        }

        public void DeleteGrade(Guid id)
        {
            throw new NotImplementedException();
        }

        public object GetGrades(DataTablesAjaxRequestModel tableModel)
        {
            throw new NotImplementedException();
        }

        public GradeModel BuildGradeModel(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}