using System;
using Autofac;
using Foundation.Library.Entities;
using Foundation.Library.Services;

namespace FinalProject.Web.Areas.Employee.Models
{
    public class EducationLevelModelBuilder
    {
        private readonly IEducationLevelService _educationLevelService;

        public EducationLevelModelBuilder(IEducationLevelService educationLevelService)
        {
            _educationLevelService = educationLevelService;
        }

        public EducationLevelModelBuilder()
        {
            _educationLevelService = Startup.AutofacContainer.Resolve<IEducationLevelService>();
        }
        public void UpdateEducationLevelModel(Guid id, EducationLevelModel model)
        {
            throw new System.NotImplementedException();
        }

        public void SaveEducationLevelModel(EducationLevelModel model)
        {
            var entity = ConvertToEntity(model);
            _educationLevelService.AddEducationLevel(entity);
        }

        private EducationLevel ConvertToEntity(EducationLevelModel model)
        {
            return new EducationLevel
            {
                EducationLevelName = model.EducationLevelName
            };
        }

        public EducationLevelModel BuildEducationLevelModel(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}