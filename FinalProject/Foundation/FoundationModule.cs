using System.Linq;
using System.Reflection;
using Autofac;
using Foundation.Contexts;
using Foundation.UnitOfWorks;
using Module = Autofac.Module;

namespace Foundation
{
    public class FoundationModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public FoundationModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WebsiteContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            var foundationAssembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(foundationAssembly).Where(x => x.Namespace != null && x.Namespace.Contains("Services")).As(x => x.GetInterfaces()
                    .FirstOrDefault(i => i.Name == "I" + x.Name)).InstancePerLifetimeScope();
            

            builder.RegisterAssemblyTypes(foundationAssembly).Where(x => x.Namespace != null && x.Namespace.Contains("Repositories")).As(x => x.GetInterfaces()
                    .FirstOrDefault(i => i.Name == "I" + x.Name)).InstancePerLifetimeScope();

            builder.RegisterType<WebsiteUnitOfWork>().As<IWebsiteUnitOfWork>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}