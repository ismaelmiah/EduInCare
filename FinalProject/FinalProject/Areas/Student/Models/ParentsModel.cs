using System.Linq;
using Autofac;
using FinalProject.Web.Models;
using Foundation.Library.Services;

namespace FinalProject.Web.Areas.Student.Models
{
    public class ParentsModel
    {
        private readonly IStudentParentService _parentService;

        public ParentsModel(IStudentParentService parentService) { _parentService = parentService; }

        public ParentsModel()
        {
            _parentService = Startup.AutofacContainer.Resolve<IStudentParentService>();
        }
        public string FatherName { get; set; }
        public string FatherMobileNo { get; set; }
        public string FatherOccupation { get; set; }
        public double FatherAnnualIncome { get; set; }
        public string MotherName { get; set; }
        public string MotherMobileNo { get; set; }
        public string MotherOccupation { get; set; }
        public string GuardianName { get; set; }
        public string GuardianMobileNo { get; set; }

        internal object GetParents(DataTablesAjaxRequestModel tableModel)
        {
            var (total, totalDisplay, records) = _parentService.GetStudentsParentsList(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new[]
                {
                    "FatherName",
                    "FatherOccupation",
                    "FatherMobileNo",
                    "MotherName",
                    "MotherMobileNo"
                }));

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalDisplay,
                data = (from record in records
                        select new[]
                        {
                            record.FatherName,
                            record.FatherOccupation,
                            record.FatherMobileNo,
                            record.MotherName,
                            record.MotherMobileNo,
                            record.Id.ToString(),
                        }
                    ).ToArray()

            };
        }
    }
}