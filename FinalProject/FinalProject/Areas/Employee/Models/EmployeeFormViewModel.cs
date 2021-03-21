using System.Collections;

namespace FinalProject.Web.Areas.Employee.Models
{
    public class EmployeeFormViewModel : EmployeeForm
    {
        internal EmployeeModelBuilder ModelBuilder;
        public EmployeeFormViewModel()
        {
            ModelBuilder = new EmployeeModelBuilder();
            DepartmentList = ModelBuilder.GetDepartmentItems();
            EmployeeTypeList = ModelBuilder.GetTypeList();
        }

        public bool IsAdmin { get; set; }
        public bool IsTeacherApplication { get; set; }
    }
}