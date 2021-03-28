using System;
using System.Linq;
using FinalProject.Web.Models;
using Foundation.Library.Entities;
using Foundation.Library.Services;

namespace FinalProject.Web.Areas.Admin.Models.ModelBuilder
{
    public class SectionModelBuilder
    {
        private readonly ISectionService _sectionService;

        public SectionModelBuilder(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }
        public void SaveSection(SectionModel model)
        {
            var entity = ConvertToEntity(model);
            _sectionService.AddSection(entity);
        }

        private Section ConvertToEntity(SectionModel model)
        {
            return new Section
            {
                Name = model.Name,
                Capacity = model.Capacity,
                CourseId = model.CourseId,
                TeacherId = model.TeacherId,
                Description = model.Description,
                Status = model.Status
            };
        }

        public void UpdateSection(Guid id, SectionModel model)
        {
            var exSection = _sectionService.GetSection(id);
            exSection.Name = model.Name;
            exSection.Capacity = model.Capacity;
            exSection.CourseId = model.CourseId;
            exSection.TeacherId = model.TeacherId;
            exSection.Description = model.Description;

            _sectionService.Update(exSection);
        }

        public void DeleteSection(Guid id)
        {
            _sectionService.Delete(id);
        }

        public object GetSections(DataTablesAjaxRequestModel tableModel)
        {
            var (total, totalDisplay, records) = _sectionService.GetSectionList(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new[]
                {
                    "Name",
                    "Capacity",
                    "Course",
                    "Employee",
                    "Status",
                    "Description",
                }));

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalDisplay,
                data = (from record in records
                        select new object[]
                        {
                            record.Name,
                            record.Course.Name,
                            record.Employee.Name,
                            record.Capacity,
                            record.Description,
                            record.Status,
                            record.Id.ToString(),
                        }
                    ).ToArray()
            };
        }

        public SectionModel BuildSectionModel(Guid id)
        {
            var exSection = _sectionService.GetSection(id);

            return new SectionModel
            {
                Name = exSection.Name,
                Capacity = exSection.Capacity,
                CourseId = exSection.CourseId,
                TeacherId = exSection.TeacherId,
                Description = exSection.Description,
                Status = exSection.Status
            };
        }
    }
}