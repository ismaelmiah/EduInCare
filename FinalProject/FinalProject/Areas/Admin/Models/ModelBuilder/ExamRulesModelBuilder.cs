using System;
using Autofac;
using FinalProject.Web.Models;
using Foundation.Library.Services;

namespace FinalProject.Web.Areas.Admin.Models.ModelBuilder
{
    public class ExamRulesModelBuilder
    {
        private readonly IExamRuleService _examRuleService;

        public ExamRulesModelBuilder(IExamRuleService examRuleService)
        {
            _examRuleService = examRuleService;
        }

        public ExamRulesModelBuilder()
        {
            _examRuleService = Startup.AutofacContainer.Resolve<IExamRuleService>();
        }

        public ExamRulesModel BuildExamRulesModel(Guid id)
        {
            throw new NotImplementedException();
        }

        public void SaveExamRules(ExamRulesModel model)
        {
            throw new NotImplementedException();
        }

        public void UpdateExamRules(Guid id, ExamRulesModel model)
        {
            throw new NotImplementedException();
        }

        public void DeleteExamRules(Guid id)
        {
            throw new NotImplementedException();
        }

        public object GetExamRules(DataTablesAjaxRequestModel tableModel)
        {
            throw new NotImplementedException();
        }
    }
}