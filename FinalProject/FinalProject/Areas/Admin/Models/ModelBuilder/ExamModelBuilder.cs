using System;
using Autofac;
using FinalProject.Web.Models;
using Foundation.Library.Services;

namespace FinalProject.Web.Areas.Admin.Models.ModelBuilder
{
    public class ExamModelBuilder
    {
        private readonly IExamService _examService;

        public ExamModelBuilder(IExamService examService)
        {
            _examService = examService;
        }

        public ExamModelBuilder()
        {
            _examService = Startup.AutofacContainer.Resolve<IExamService>();
        }
        public ExamModel BuildExamModel(Guid id)
        {
            throw new NotImplementedException();
        }

        public void SaveExam(ExamModel model)
        {
            throw new NotImplementedException();
        }

        public void UpdateExam(Guid modelId, ExamModel model)
        {
            throw new NotImplementedException();
        }

        public object GetExams(DataTablesAjaxRequestModel tableModel)
        {
            throw new NotImplementedException();
        }

        public void DeleteExam(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}