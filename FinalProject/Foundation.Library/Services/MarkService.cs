﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public class MarkService : IMarkService
    {
        private readonly IManagementUnitOfWork _management;

        public MarkService(IManagementUnitOfWork management)
        {
            _management = management;
        }

        public void AddMark(Mark mark)
        {
            _management.MarkRepository.Add(mark);
            _management.Save();
        }

        public void DeleteMark(Guid id)
        {
            _management.MarkRepository.Remove(id);
            _management.Save();
        }

        public void UpdateMark(Mark mark)
        {
            _management.MarkRepository.Edit(mark);
            _management.Save();
        }

        public IList<Mark> GetMarks(Expression<Func<Mark, bool>> filter, string includePamars)
        {
            return _management.MarkRepository.Get(filter, null, includePamars, false);
        }

        public Mark GetMarksByStudent(Expression<Func<Mark, bool>> filter)
        {
            return _management.MarkRepository.Get(filter).FirstOrDefault();
        }

        public Mark GetMark(Guid id)
        {
            return _management.MarkRepository.GetById(id);
        }

        public (int total, int totalDisplay, IList<Mark> records)
            GetMarkList(int pageIndex, int pageSize, string searchText, string orderBy)
        {
            (IList<Mark> data, int total, int totalDisplay) result;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                result = _management.MarkRepository.GetDynamic(null,
                    orderBy, "", pageIndex, pageSize);

            }
            else
            {
                result = _management.MarkRepository.GetDynamic(x => x.Grade == searchText,
                    orderBy, "", pageIndex, pageSize);
            }

            var data = (from x in result.data
                select new Mark
                {
                    Id = x.Id,
                    StudentId = x.StudentId,
                    CourseId = x.CourseId,
                    AcademicYearId = x.AcademicYearId,
                    //ExamId = x.ExamId,
                    SectionId = x.SectionId,
                    Grade = x.Grade,
                    Marks = x.Marks,
                    Point = x.Point,
                    Present = x.Present
                }).ToList();

            return (result.total, result.totalDisplay, data);
        }
    }
}