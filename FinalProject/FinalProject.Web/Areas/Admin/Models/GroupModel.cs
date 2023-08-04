using System;
using FinalProject.Web.Areas.Admin.Models.ModelBuilder;

namespace FinalProject.Web.Areas.Admin.Models
{
    public class GroupModel
    {
        internal GroupModelBuilder ModelBuilder;

        public GroupModel()
        {
            ModelBuilder = new GroupModelBuilder();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
