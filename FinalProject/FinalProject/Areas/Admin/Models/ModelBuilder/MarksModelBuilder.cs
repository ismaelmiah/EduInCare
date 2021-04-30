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

        public MarksModelBuilder(
            IExamRuleService examRuleService,
            ICourseService courseService,
            IExamService examService,
            ISubjectService subjectService,
            IMarkService markService,
            ISectionService sectionService,
            IAcademicYearService academic,
            IRegistrationStudentService registrationStudent)
        {
            _examRuleService = examRuleService;
            _courseService = courseService;
            _examService = examService;
            _subjectService = subjectService;
            _markService = markService;
            _sectionService = sectionService;
            _academic = academic;
            _registrationStudent = registrationStudent;
        }

        public MarksModelBuilder()
        {
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

        internal SelectList GetExamList(Guid courseId, object selectedItem = null)
        {
            return new SelectList(_examService.GetExams(courseId), "Id", "Name", selectedItem);
        }

        internal SelectList GetSubjectList(Guid courseId, object selectedItem = null)
        {
            return new SelectList(_subjectService.GetSubjects(courseId), "Id", "Name", selectedItem);
        }

        internal SelectList GetCourseList(object selectedItem = null)
        {
            return new SelectList(_courseService.GetCourses(), "Id", "Name", selectedItem);
        }

        public SelectList GetSectionList(object selectedItem = null)
        {
            return new SelectList(_sectionService.GetSections(), "Id", "Name", selectedItem);
        }

        public object GetExam(Guid examId)
        {
            return _examService.GetExam(examId);
        }

        public List<StudentMarks> GetStudentsAndExamRules(Guid academicYearId, Guid courseId, Guid sectionId, Guid examId)
        {
            var examRule = _examRuleService.GetExamRules().FirstOrDefault(x => x.ExamId == examId);

            var students = _markService.GetMarks(x => x.AcademicYearId == academicYearId
                                                      && x.CourseId == courseId && x.SectionId == sectionId && x.IsMarkSet == false,
                "Student,Section,Course,Subject,Exam,AcademicYear").Select(x => new StudentMarks
            {
                StudentId = x.StudentId,
                StudentName = x.Student.FirstName + ' '+x.Student.MiddleName + ' '+x.Student.LastName,
                RollNo = x.Student.RollNo,
                AcademicYearId = x.AcademicYearId,
                Present = x.Present,
                SectionId = x.SectionId,
                StudentMark = BuildStudentMarks(examRule.MarksDistribution)
            }).ToList();
            //var marksColumn = students[0].Exam.MarksDistributionTypes.Split(',');

            //return new
            //{
            //    examRule,
            //    registeredStudents
            //};
            return students;
        }

        private List<MarkDistribution> BuildStudentMarks(string examRuleMarksDistribution)
        {
            var rules = JsonConvert.DeserializeObject<List<DistributionModel>>(examRuleMarksDistribution);
            var list = rules.Select(x => new MarkDistribution
            {
                Type = x.DistributionType,
                Mark = 0,
                PassMark = x.PassMarks,
                TotalMark = x.TotalMarks
            }).ToList();
            return list;
        }

        public bool StudentMarkSave(StudentMarks model)
        {
            //var entity = _markService.GetMarks().FirstOrDefault(x => x.StudentId == model.StudentId);
            //if (entity != null)
            //{
            //    entity.ExamId = model.ExamId;
            //    entity.SubjectId = model.SubjectId;
            //    entity.Marks = GenerationJsonMarks(model.StudentMark);
            //    entity.Grade = "";
            //    entity.IsMarkSet = true;
            //    entity.Point = 3.4;

            //    _markService.UpdateMark(entity);
            //    return true;
            //}
            return false;
        }

        private string GenerationJsonMarks(List<MarkDistribution> modelMarks)
        {
            return JsonConvert.SerializeObject(modelMarks);
        }
    }
}