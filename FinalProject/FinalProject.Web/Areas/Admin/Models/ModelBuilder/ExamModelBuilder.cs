using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using FinalProject.Web.Models;
using Foundation.Library.Entities;
using Foundation.Library.Enums;
using Foundation.Library.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Web.Areas.Admin.Models.ModelBuilder
{
    public class ExamModelBuilder
    {
        private readonly IExamService _examService;
        private readonly ICourseService _courseService;

        public ExamModelBuilder(IExamService examService, ICourseService courseService)
        {
            _examService = examService;
            _courseService = courseService;
        }

        public ExamModelBuilder()
        {
            _examService = Startup.AutofacContainer.Resolve<IExamService>();
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
        }

        public ExamModel BuildExamModel(Guid id)
        {
            var exam = _examService.GetExam(id);
            return new ExamModel
            {
                Name = exam.Name,
                MarksDistributionTypes = GetMarksDistributionTypeList(exam.MarksDistributionTypes),
                Status = exam.Status,
                Course = exam.Course.Name,
                Id = exam.Id,
                CourseList = GetCourseList(exam.CourseId)
            };
        }

        private IList<int> GetMarksDistributionTypeList(string list)
        {
            var data = list.Split(',')
                .Select(x => (int)EnumHelper<MarksDistribution>.Parse(x)).ToList();
            return data;
        }

        public void SaveExam(ExamModel model)
        {
            var examEntity = ConvertToEntity(model);
            _examService.AddExam(examEntity);
        }

        private Exam ConvertToEntity(ExamModel model)
            => new Exam()
            {
                Name = model.Name,
                CourseId = model.CourseId,
                MarksDistributionTypes = string.Join(",", model.MarksDistributionTypes.Select(i => (QualificationType)i).ToList()
                    .Select(s => Enum.GetName(typeof(MarksDistribution), s))),
                Status = model.Status
            };

        public void UpdateExam(Guid id, ExamModel model)
        {
            var existExam = _examService.GetExam(id);
            existExam.Status = model.Status;
            existExam.CourseId = model.CourseId;
            existExam.MarksDistributionTypes = string.Join(",", model.MarksDistributionTypes.Select(i => (QualificationType) i).ToList()
                    .Select(s => Enum.GetName(typeof(MarksDistribution), s)));
            existExam.Name = model.Name;

            _examService.Update(existExam);
        }

        public object GetExams(DataTablesAjaxRequestModel tableModel)
        {

            var (total, totalDisplay, records) = _examService.GetExamList(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new[]
                {
                    "Course",
                    "Name",
                    "MarksDistributionTypes",
                    "Status"
                }));

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalDisplay,
                data = (from record in records
                        select new object[]
                        {
                            record.Course?.Name,
                            record.Name,
                            record.MarksDistributionTypes,
                            record.Status,
                            record.Id.ToString(),
                        }
                    ).ToArray()
            };
        }

        public void DeleteExam(Guid id)
        {
            _examService.Delete(id);
        }

        public SelectList GetCourseList(object selectedItem = null)
            => new SelectList(_courseService.GetCourses(), "Id", "Name", selectedItem);

        public List<SelectListItem> GetMarksDistributionTypes()
        {
            return Enum.GetValues(typeof(MarksDistribution))
                .Cast<MarksDistribution>().Select(x => new SelectListItem()
                {
                    Text = x.ToString(),
                    Value = ((int)x).ToString()
                }).ToList();
        }
    }
}