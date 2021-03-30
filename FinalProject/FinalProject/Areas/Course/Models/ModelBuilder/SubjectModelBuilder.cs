using System;
using System.Linq;
using Autofac;
using FinalProject.Web.Models;
using Foundation.Library.Entities;
using Foundation.Library.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Web.Areas.Course.Models.ModelBuilder
{
    public class SubjectModelBuilder
    {
        private readonly ISubjectService _subject;
        private readonly ICourseService _course;

        public SubjectModelBuilder(ISubjectService subject, ICourseService course)
        {
            _subject = subject;
            _course = course;
        }

        public SubjectModelBuilder()
        {
            _subject = Startup.AutofacContainer.Resolve<ISubjectService>();
            _course = Startup.AutofacContainer.Resolve<ICourseService>();
        }
        public void DeleteSubject(Guid id)
        {
            _subject.Delete(id);
        }

        public void UpdateSubject(Guid id, SubjectModel model)
        {
            var exSubject = _subject.GetSubject(id);
            exSubject.Name = model.Name;
            exSubject.CourseId = model.CourseId;
            exSubject.ExcludeInResult = model.ExcludeInResult;
            _subject.Update(exSubject);
        }

        private static Subject ConvertToEntity(SubjectModel model)
        {
            return new Subject
            {
                Name = model.Name,
                Code = model.Code,
                CourseId = model.CourseId,
                ExcludeInResult = model.ExcludeInResult
            };
        }

        public void SaveSubject(SubjectModel model)
        {
            var entity = ConvertToEntity(model);
            _subject.AddSubject(entity);
        }

        public SubjectModel BuildSubjectModel(Guid id)
        {
            var exSubject = _subject.GetSubject(id);
            return new SubjectModel
            {
                Name = exSubject.Name,
                Code = exSubject.Code,
                CourseList = GetCourseList(exSubject.CourseId),
                ExcludeInResult = exSubject.ExcludeInResult,
                Id = exSubject.Id
            };
        }

        public object GetSubjects(DataTablesAjaxRequestModel tableModel)
        {

            var (total, totalDisplay, records) = _subject.GetSubjectList(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new[]
                {
                    "Name",
                    "Code",
                    "Course",
                    "ExcludeInResult",
                }));

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalDisplay,
                data = (from record in records
                        select new object[]
                        {
                            record.Name,
                            record.Code,
                            record.Course.Name,
                            record.ExcludeInResult,
                            record.Id.ToString(),
                        }
                    ).ToArray()
            };
        }

        public SelectList GetCourseList(object selectedValue = null)
        {
            return new SelectList(_course.GetCourses(), "Id", "Name", selectedValue);
        }
    }
}