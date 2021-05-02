using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using FinalProject.Web.Areas.Admin.Controllers;
using FinalProject.Web.Models;
using Foundation.Library.Entities;
using Foundation.Library.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json;

namespace FinalProject.Web.Areas.Admin.Models.ModelBuilder
{
    public class MarksModelBuilder
    {
        private readonly IMarkService _markService;
        private readonly ISectionService _sectionService;
        private readonly IExamRuleService _examRuleService;
        private readonly ICourseService _courseService;
        private readonly IExamService _examService;
        private readonly ISubjectService _subjectService;
        private readonly IAcademicYearService _academic;
        private readonly IRegistrationStudentService _registrationStudent;
        private readonly IGradeService _gradeService;

        public MarksModelBuilder(
            IExamRuleService examRuleService,
            ICourseService courseService,
            IExamService examService,
            ISubjectService subjectService,
            IMarkService markService,
            ISectionService sectionService,
            IAcademicYearService academic,
            IRegistrationStudentService registrationStudent,
            IGradeService gradeService)
        {
            _examRuleService = examRuleService;
            _courseService = courseService;
            _examService = examService;
            _subjectService = subjectService;
            _markService = markService;
            _sectionService = sectionService;
            _academic = academic;
            _registrationStudent = registrationStudent;
            _gradeService = gradeService;
        }

        public MarksModelBuilder()
        {
            _gradeService = Startup.AutofacContainer.Resolve<IGradeService>();
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
            _examService = Startup.AutofacContainer.Resolve<IExamService>();
            _subjectService = Startup.AutofacContainer.Resolve<ISubjectService>();
            _examRuleService = Startup.AutofacContainer.Resolve<IExamRuleService>();
            _markService = Startup.AutofacContainer.Resolve<IMarkService>();
            _sectionService = Startup.AutofacContainer.Resolve<ISectionService>();
            _academic = Startup.AutofacContainer.Resolve<IAcademicYearService>();
            _registrationStudent = Startup.AutofacContainer.Resolve<IRegistrationStudentService>();
        }

        public MarksModel BuildMarksModel(Guid id)
        {
            var exMark = _markService.GetMark(id);
            return new MarksModel
            {

            };
        }

        public void Save(MarksModel model)
        {
            var markEntity = ConvertToEntity(model);
            _markService.AddMark(markEntity);
        }

        private Mark ConvertToEntity(MarksModel model)
        {
            throw new NotImplementedException();
        }

        public void Update(Guid id, MarksModel model)
        {
            var exMark = _markService.GetMark(id);

        }

        public void Delete(Guid id)
        {
            _markService.DeleteMark(id);
        }

        public object GetMarksResult(DataTablesAjaxRequestModel tableModel)
        {

            var (total, totalDisplay, records) = _markService.GetMarkList(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new[]
                {
                    "Name"
                }));

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalDisplay,
                data = (from record in records
                        select new object[]
                        {
                            record.Marks,
                            record.Id.ToString(),
                        }
                    ).ToArray()
            };
        }
        public SelectList GetAcademicYearList(object selectedItem = null)
        {
            return new SelectList(_academic.GetAcademicYears(), "Id", "Title", selectedItem);
        }
        
        internal SelectList GetCourseList(object selectedItem = null)
        {
            return new SelectList(_courseService.GetCourses(), "Id", "Name", selectedItem);
        }

        public SelectList GetSectionList(object selectedItem = null)
        {
            return new SelectList(_sectionService.GetSections(), "Id", "Name", selectedItem);
        }

        public List<StudentMarks> BuildStudentMarksList(Guid academicYearId, Guid courseId, Guid sectionId, Guid examId, bool isMarkSet = false)
        {

            var students = _markService.GetMarks(x => x.AcademicYearId == academicYearId 
                    && x.CourseId == courseId && x.SectionId == sectionId && x.IsMarkSet == isMarkSet,
                "Student,Section,Course,Subject,Exam,AcademicYear");
            if (isMarkSet)
            {
                var studentMarksList = students.Select(x => new StudentMarks
                {
                    StudentName = x.Student.FirstName + ' ' + x.Student.MiddleName + ' ' + x.Student.LastName,
                    RollNo = x.Student.RollNo,
                    Present = x.Present,
                    TotalMark = GetTotalMarks(x.Marks),
                    Grade = x.Grade,
                    Point = x.Point,
                    StudentMark = BuildStudentMarks(x.Marks)
                }).ToList();
                return studentMarksList;
            }
            else
            {
                var examRule = _examRuleService.GetExamRules().FirstOrDefault(x => x.ExamId == examId);
                var studentMarksList = students.Select(x => new StudentMarks
                {
                    StudentId = x.StudentId,
                    StudentName = x.Student.FirstName + ' ' + x.Student.MiddleName + ' ' + x.Student.LastName,
                    RollNo = x.Student.RollNo,
                    AcademicYearId = x.AcademicYearId,
                    Present = x.Present,
                    SectionId = x.SectionId,
                    StudentMark = BuildStudentMarks(examRule.MarksDistribution, true)
                }).ToList();
                return studentMarksList;
            }
        }

        /// <summary>
        /// Get Total Marks by Retrieve Data
        /// </summary>
        /// <param name="argMarks"></param>
        /// <returns></returns>
        private static double GetTotalMarks(string argMarks)
        {
            var rules = JsonConvert.DeserializeObject<List<MarkDistribution>>(argMarks);
            var mark = rules.Sum(x => x.Mark);
            return mark;
        }

        /// <summary>
        /// Build Student Marks
        /// </summary>
        /// <param name="markDistribution"></param>
        /// <param name="examRule"></param>
        /// <returns></returns>
        private static List<MarkDistribution> BuildStudentMarks(string markDistribution, bool examRule)
        {
            var rules = JsonConvert.DeserializeObject<List<DistributionModel>>(markDistribution);
            var list = rules.Select(x => new MarkDistribution
            {
                Type = x.DistributionType,
                Mark = 0,
                PassMark = x.PassMarks,
                TotalMark = x.TotalMarks
            }).ToList();
            return list;
        }

        /// <summary>
        /// Retrieve Student Marks
        /// </summary>
        /// <param name="marks"></param>
        /// <returns></returns>
        private static List<MarkDistribution> BuildStudentMarks(string marks)
        {
            var rules = JsonConvert.DeserializeObject<List<MarkDistribution>>(marks);
            var list = rules.Select(x => new MarkDistribution
            {
                Type = x.Type,
                Mark = x.Mark,
                PassMark = x.PassMark,
                TotalMark = x.TotalMark
            }).ToList();
            return list;
        }

        /// <summary>
        /// Student Mark Save
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool StudentMarkSave(StudentMarks model)
        {
            var entity = _markService.GetMarksByStudent(x => x.StudentId == model.StudentId);
            var grade = CalculateGradeAndPoint(model.StudentMark, model.ExamId).grade;
            var point = CalculateGradeAndPoint(model.StudentMark, model.ExamId).point;
            if (entity == null) return false;
            entity.SubjectId = model.SubjectId;
            entity.Marks = JsonConvert.SerializeObject(model.StudentMark);
            entity.Grade = grade;
            entity.IsMarkSet = true;
            entity.Point = point;
            entity.Present = model.Present;

            _markService.UpdateMark(entity);
            return true;
        }

        /// <summary>
        /// Calculate Grade And Point Based on Mark
        /// </summary>
        /// <param name="mark"></param>
        /// <param name="examId"></param>
        /// <returns></returns>
        private (string grade, double point) CalculateGradeAndPoint(List<MarkDistribution> mark, Guid examId)
        {
            var examRules = _examRuleService.GetExamRules().FirstOrDefault(x => x.ExamId == examId);
            var totalMarks = GetTotalMarks(JsonConvert.SerializeObject(mark));
            var exitsGrade = _gradeService.GetGrade(examRules.GradeId);
            var rules = JsonConvert.DeserializeObject<List<Rules>>(exitsGrade.Rule);
            var grade = "F";
            var point = 0.0;
            foreach (var g in rules.Where(g => totalMarks >= g.Minimum && totalMarks <= g.Maximum))
            {
                grade = g.Name;
                point = g.Point;

                return (grade, point);
            }

            return (grade, point);
        }
    }
}