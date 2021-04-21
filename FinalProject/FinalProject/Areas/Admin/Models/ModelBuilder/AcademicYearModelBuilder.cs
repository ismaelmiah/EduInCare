using System;
using System.Linq;
using Autofac;
using FinalProject.Web.Models;
using Foundation.Library.Entities;
using Foundation.Library.Services;

namespace FinalProject.Web.Areas.Admin.Models.ModelBuilder
{
    public class AcademicYearModelBuilder
    {
        private readonly IAcademicYearService _service;

        public AcademicYearModelBuilder(IAcademicYearService service)
        {
            _service = service;
        }

        public AcademicYearModelBuilder()
        {
            _service = Startup.AutofacContainer.Resolve<IAcademicYearService>();
        }
        public void SaveAcademicYear(AcademicYearModel model)
        {
            var entity = ConvertToEntity(model);
            _service.AddAcademicYear(entity);
        }

        private AcademicYear ConvertToEntity(AcademicYearModel model)
        {
            return new AcademicYear
            {
                Title = model.Title,
                EndDate = model.EndDate,
                IsOpenForAdmission = model.IsOpenForAdmission,
                Status = model.Status,
                StartDate = model.StartDate
            };
        }

        public void UpdateAcademicYear(Guid modelId, AcademicYearModel model)
        {
            var exEntity = _service.GetAcademicYear(modelId);
            exEntity.Status = model.Status;
            exEntity.EndDate = model.EndDate;
            exEntity.IsOpenForAdmission = model.IsOpenForAdmission;
            exEntity.StartDate = model.StartDate;
            exEntity.Title = model.Title;

            _service.Update(exEntity);
        }

        public void DeleteAcademicYear(Guid id)
        {
            _service.Delete(id);
        }

        public AcademicYearModel BuildAcademicYearModel(Guid id)
        {
            var exEntity = _service.GetAcademicYear(id);
            return new AcademicYearModel
            {
                StartDate = exEntity.StartDate,
                EndDate = exEntity.EndDate,
                IsOpenForAdmission = exEntity.IsOpenForAdmission,
                Status = exEntity.Status,
                Title = exEntity.Title
            };
        }

        public object GetAcademicYears(DataTablesAjaxRequestModel tableModel)
        {
            var (total, totalDisplay, records) = _service.GetAcademicYearList(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new[]
                {
                    "Title",
                    "StartDate",
                    "EndDate",
                    "Status",
                    "IsOpenForAdmission"
                }));

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalDisplay,
                data = (from record in records
                        select new object[]
                        {
                            record.Title,
                            record.Registration.Count(),
                            record.StartDate.ToShortDateString(),
                            record.EndDate.ToShortDateString(),
                            record.Status,
                            record.IsOpenForAdmission,
                            record.Id.ToString(),
                        }
                    ).ToArray()

            };
        }
    }
}