using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Autofac;
using Foundation.Library.Entities;
using Foundation.Library.Services;

namespace FinalProject.Web.Areas.Employee.Models
{
    public class DesignationModelBuilder
    {
        private readonly IDesignationService _designation;

        public DesignationModelBuilder(IDesignationService designation)
        {
            _designation = designation;
        }

        public DesignationModelBuilder()
        {
            _designation = Startup.AutofacContainer.Resolve<IDesignationService>();
        }
        public void UpdateDesignationModel(object id, DesignationModel model)
        {
            throw new System.NotImplementedException();
        }

        public void SaveDesignationModel(DesignationModel model)
        {
            var Entity = ConvertToEntity(model);
            _designation.AddDesignation(Entity);
        }

        private Designation ConvertToEntity(DesignationModel model)
        {
            return new Designation
            {
                Name = model.Name
            };
        }

        public DesignationModel BuildDesignationModel(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}