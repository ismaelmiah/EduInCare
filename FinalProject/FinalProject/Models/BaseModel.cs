using System.IO;
using Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace FinalProject.Web.Models
{
    public class BaseModel
    {
        //protected readonly UserManager<ApplicationUser> _userService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        protected readonly IHttpContextAccessor HttpContextAccessor;
        private const string ImagePath = "temp";

        public BaseModel()
        {
            _webHostEnvironment = Startup.AutofacContainer.Resolve<IWebHostEnvironment>();
            HttpContextAccessor = Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
            //_userService = Startup.AutofacContainer.Resolve<UserManager<ApplicationUser>>();
        }

        public virtual (string fileName, string filePath) StoreFile(IFormFile file)
        {
            var randomName = Path.GetRandomFileName().Replace(".", string.Empty);
            var newFileName = $"{randomName}{Path.GetExtension(file.FileName)}";

            var rootPath = _webHostEnvironment.WebRootPath;
            //var temp = _pathService.TempFolder;

            var fullPath = Path.Combine(rootPath, ImagePath);

            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }

            var path = Path.Combine(fullPath, newFileName);

            if (!File.Exists(path))
            {
                using var profileImage = File.OpenWrite(path);
                using var uploadFile = file.OpenReadStream();
                uploadFile.CopyTo(profileImage);
            }
            return (newFileName, path);
        }

        public string FormatImageUrl(string imageName)
        {
            if (string.IsNullOrWhiteSpace(imageName)) return "";
            var indexOfFileName = imageName.LastIndexOf('\\');
            if (indexOfFileName < 0) return "";
            var fileName = imageName.Substring(indexOfFileName);
            return $"/{ImagePath}/{fileName}";
        }
    }
}