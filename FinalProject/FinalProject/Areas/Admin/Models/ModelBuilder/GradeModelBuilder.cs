using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using FinalProject.Web.Models;
using Foundation.Library.Entities;
using Foundation.Library.Services;
using Newtonsoft.Json;

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
            var grade = ConvertToEntity(model);
            _gradeService.AddGrade(grade);
        }

        private Grade ConvertToEntity(GradeModel model) => new Grade
        {
            Name = model.Name,
            Rule = JsonConvert.SerializeObject(model.Rules)
        };

        public void UpdateGrade(Guid id, GradeModel model)
        {
            var grade = _gradeService.GetGrade(id);
            grade.Name = model.Name;
            grade.Rule = string.Join(", ", model.Rules);

            _gradeService.Update(grade);
        }

        public void DeleteGrade(Guid id)
        {
            _gradeService.Delete(id);
        }

        public object GetGrades(DataTablesAjaxRequestModel tableModel)
        {
            var (total, totalDisplay, records) = _gradeService.GetGradeList(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new[]
                {
                    "Name",
                }));

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalDisplay,
                data = (from record in records
                        select new object[]
                        {
                            record.Name,
                            record.Rule,
                            record.Id.ToString(),
                        }
                    ).ToArray()
            };
        }

        public GradeModel BuildGradeModel(Guid id)
        {
            var grade = _gradeService.GetGrade(id);
            return new GradeModel
            {
                Id = grade.Id,
                Name = grade.Name,
                Rules = JsonConvert.DeserializeObject<List<Rules>>(grade.Rule)
            };
        }
    }
}