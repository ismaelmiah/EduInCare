using System.Linq;
using System.Reflection;
using Autofac;
using Membership.Library.Contexts;
using Membership.Library.Seed;
using Module = Autofac.Module;

namespace Membership.Library
{
    public class MembershipModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public MembershipModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            var membershipAssembly = Assembly.GetExecutingAssembly();

            //builder.RegisterAssemblyTypes(membershipAssembly).Where(x => x.Namespace != null && x.Namespace.Contains("Services")).As(x => x.GetInterfaces()
            //    .FirstOrDefault(i => i.Name == "I" + x.Name)).InstancePerLifetimeScope();


            base.Load(builder);
        }
    }
}
