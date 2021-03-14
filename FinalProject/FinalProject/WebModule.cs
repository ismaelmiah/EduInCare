using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace FinalProject.Web
{
    public class WebModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public WebModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var webExecutingAssembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(webExecutingAssembly).Where(x => x.Namespace != null && x.Namespace.Contains("Admin.Models")).AsSelf();
            builder.RegisterAssemblyTypes(webExecutingAssembly).Where(x => x.Namespace != null && x.Namespace.Contains("Student.Models")).AsSelf();

            base.Load(builder);
        }
    }
}
