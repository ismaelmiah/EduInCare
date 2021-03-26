using System;
using Autofac;
using Foundation.Library.Entities;
using Foundation.Library.Services;

namespace FinalProject.Web.Areas.Employee.Models
{
    public class ExamModelBuilder
    {
        private readonly IExamTitleService _examTitleService;

        public ExamModelBuilder(IExamTitleService examTitleService)
        {
            _examTitleService = examTitleService;
        }

        public ExamModelBuilder()
        {
            _examTitleService = Startup.AutofacContainer.Resolve<IExamTitleService>();
        }
        public void SaveExamModel(ExamModel model)
        {
            var entity = ConvertToEntity(model);
            _examTitleService.AddExamTitle(entity);
        }

        private ExamTitle ConvertToEntity(ExamModel model)
        {
            return new ExamTitle
            {
                TitleName = model.ExamTitle,
                EducationLevelId = model.EducationLevelId
            };
        }

        public void UpdateExamModel(Guid id, ExamModel model)
        {
            throw new System.NotImplementedException();
        }

        public ExamModel BuildExamModel(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}