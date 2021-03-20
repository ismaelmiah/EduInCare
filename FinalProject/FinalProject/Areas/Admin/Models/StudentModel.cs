using System.Linq;
using Autofac;
using FinalProject.Web.Models;
using Foundation.Library.Services;

namespace FinalProject.Web.Areas.Admin.Models
{
    public class StudentModel : BaseModel
    {
        private readonly IStudentService _studentService;

        public StudentModel(IStudentService studentService) { _studentService = studentService; }

        public StudentModel()
        {
            _studentService = Startup.AutofacContainer.Resolve<IStudentService>();
        }
        internal object GetStudents(DataTablesAjaxRequestModel tableModel)
        {
            var (total, totalDisplay, records) = _studentService.GetStudentList(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new[]
                {
                    "FirstName",
                    "MiddleName",
                    "LastName",
                    "Photo",
                    "Gender",
                    "Class",
                    "DateOfBirth",
                    "YearOfEnroll"
                }));

            return new
            {
                recordsTotal = total,
                recordsFiltered = totalDisplay,
                data = (from record in records
                        select new[]
                        {
                            record.FirstName,
                            record.MiddleName,
                            record.LastName,
                            FormatImageUrl(record.Image?.Url),
                            record.Gender,
                            record.Course?.Title,
                            record.DateOfBirth.ToShortDateString(),
                            record.YearOfEnroll.ToShortDateString(),
                            record.Id.ToString(),
                        }
                    ).ToArray()

            };
        }
    }
}