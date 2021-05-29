using System;
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
        public void UpdateDesignationModel(Guid id, DesignationModel model)
        {
            var designation = _designation.GetDesignation(id);
            designation.Name = model.Name;
            _designation.Update(designation);
        }

        public void SaveDesignationModel(DesignationModel model)
        {
            var entity = ConvertToEntity(model);
            _designation.AddDesignation(entity);
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
            var designation = _designation.GetDesignation(id);
            return new DesignationModel {Id = designation.Id, Name = designation.Name};
        }

        internal void Delete(Guid id)
        {
            _designation.Delete(id);
        }
    }
}