namespace FinalProject.Web.Areas.Employee.Models
{
    public class TeacherForm : EmployeeForm
    {

        internal TeacherModelBuilder ModelBuilder;
        public TeacherForm()
        {
            ModelBuilder = new TeacherModelBuilder();
            DepartmentList = ModelBuilder.GetDepartmentItems();
        }

    }
}