using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using FinalProject.Web.Models;
using Foundation.Library.Entities;
using Foundation.Library.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace FinalProject.Web.Areas.Admin.Models.ModelBuilder
{
    public class ExamRulesModelBuilder
    {
        private readonly IExamRuleService _examRuleService;
        private readonly IGradeService _gradeService;
        private readonly ICourseService _courseService;
        private readonly IExamService _examService;
        private readonly ISubjectService _subjectService;

        public ExamRulesModelBuilder(
            IExamRuleService examRuleService,
            IGradeService gradeService,
            ICourseService courseService,
            IExamService examService,
            ISubjectService subjectService)
        {
            _examRuleService = examRuleService;
            _gradeService = gradeService;
            _courseService = courseService;
            _examService = examService;
            _subjectService = subjectService;
        }

        public ExamRulesModelBuilder()
        {
            _gradeService = Startup.AutofacContainer.Resolve<IGradeService>(); ;
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>(); ;
            _examService = Startup.AutofacContainer.Resolve<IExamService>(); ;
            _subjectService = Startup.AutofacContainer.Resolve<ISubjectService>(); ;
            _examRuleService = Startup.AutofacContainer.Resolve<IExamRuleService>();
        }

        public ExamRulesModel BuildExamRulesModel(Guid id)
        {
            var examRules = _examRuleService.GetExamRule(id);
            return new ExamRulesModel()
            {
                Id = examRules.Id,
                CourseList = GetCourseList(examRules.CourseId),
                SubjectList = GetSubjectList(examRules.CourseId, examRules.SubjectId),
                GradeList = GetGradeList(examRules.GradeId),
                ExamList = GetExamList(examRules.CourseId, examRules.ExamId),
                TotalExamMarks = examRules.TotalExamMarks,
                PassMarks = examRules.PassMarks,
                DistributionModels = JsonConvert.DeserializeObject<List<DistributionModel>>(examRules.MarksDistribution)
            };
        }

        internal SelectList GetExamList(Guid courseId, object selectedItem = null)
        {
            return new SelectList(_examService.GetExams(courseId), "Id", "Name", selectedItem);
        }

        internal SelectList GetGradeList(object selectedItem = null)
        {
            return new SelectList(_gradeService.GetGrades(), "Id", "Name", selectedItem);
        }

        internal SelectList GetSubjectList(Guid courseId, object selectedItem = null)
        {
            return new SelectList(_subjectService.GetSubjects(courseId), "Id", "Name", selectedItem);
        }

        internal SelectList GetCourseList(object selectedItem = null)
        {
            return new SelectList(_courseService.GetCourses(), "Id", "Name", selectedItem);
        }

        public void SaveExamRules(ExamRulesModel model)
        {
            var examRules = ConvertToEntity(model);
            _examRuleService.AddExamRule(examRules);
        }

        private ExamRules ConvertToEntity(ExamRulesModel model) 
            => new ExamRules
            {
                CourseId = model.CourseId,
                SubjectId = model.SubjectId,
                GradeId = model.GradeId,
                ExamId = model.ExamId,
                TotalExamMarks = model.TotalExamMarks,
                PassMarks = model.PassMarks,
                MarksDistribution = JsonConvert.SerializeObject(model.DistributionModels)
            };

        public void UpdateExamRules(Guid id, ExamRulesModel model)
        {
            var examRules = _examRuleService.GetExamRule(id);

            examRules.CourseId = model.CourseId;
            examRules.SubjectId = model.SubjectId;
            examRules.GradeId = model.GradeId;
            examRules.ExamId = model.ExamId;
            examRules.TotalExamMarks = model.TotalExamMarks;
            examRules.PassMarks = model.PassMarks;
            examRules.MarksDistribution = JsonConvert.SerializeObject(model.DistributionModels);

            _examRuleService.Update(examRules);
        }

        public void DeleteExamRules(Guid id)
        {
            _examRuleService.Delete(id);
        }

        public object GetExamRules(DataTablesAjaxRequestModel tableModel)
        {
            var (total, totalDisplay, records) = _examRuleService.GetExamRuleList(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new[]
                {
                    "Subject",
                    "Grade",
                    "TotalExamMarks",
                    "PassMarks"
                }));

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalDisplay,
                data = (from record in records
                        select new object[]
                        {
                            record.Subject?.Name,
                            record.Grade.Name,
                            record.MarksDistribution,
                            record.TotalExamMarks,
                            record.PassMarks,
                            record.Id.ToString(),
                        }
                    ).ToArray()
            };
        }

        public object GetMarksDistributions(Guid examId)
        {
            return _examService.GetExam(examId);
        }
    }
}