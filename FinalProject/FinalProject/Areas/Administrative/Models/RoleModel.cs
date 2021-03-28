using System;
using FinalProject.Web.Areas.Administrative.Models.ModelBuilder;

namespace FinalProject.Web.Areas.Administrative.Models
{
    public class RoleModel
    {
        protected internal RoleModelBuilder ModelBuilder;
        public RoleModel()
        {
            ModelBuilder = new RoleModelBuilder();
        }

        public string Id { get; set; }
        public string RoleName { get; set; }
    }
}