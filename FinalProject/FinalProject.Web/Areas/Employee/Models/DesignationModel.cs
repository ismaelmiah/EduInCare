using System;

namespace FinalProject.Web.Areas.Employee.Models
{
    public class DesignationModel
    {
        internal DesignationModelBuilder ModelBuilder;

        public DesignationModel()
        {
            ModelBuilder = new DesignationModelBuilder();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}