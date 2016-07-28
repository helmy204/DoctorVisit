using DoctorVisit.Core.Basis;
using DoctorVisit.Data;
using DoctorVisit.Service.Authentication;
using DoctorVisit.Service.Common;
using DoctorVisit.Service.Security;
using DoctorVisit.Service.Users;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Unity.Mvc5;

namespace DoctorVisit.Web.Framework
{
    /// <summary>
    /// Dependency Registrar
    /// </summary>
    public static class DependencyRegistrar
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();    
            RegisterTypes(container);

            return container;
        }

        private static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<HttpContextBase>(new InjectionFactory(c => new HttpContextWrapper(HttpContext.Current)));
            container.RegisterType<IWorkContext, WebWorkContext>();

            // context
            container.RegisterType<IDbContext, DoctorVisitDbContext>(new PerResolveLifetimeManager());
            container.RegisterType<IDbDoctorVisitContext, DoctorVisitDbContext>(new PerResolveLifetimeManager());

            // repository
            container.RegisterType(typeof(IRepository<>), typeof(EfRepository<>));
            container.RegisterType(typeof(IDoctorVisitRepository<>), typeof(EfDoctorVisitRepository<>));

            // authentication
            container.RegisterType<IAuthenticationService, FormsAuthenticationService>();
            container.RegisterType<IDoctorVisitPrincipalService, DoctorVisitPrincipalService>();

            // security
            container.RegisterType<IEncryptionService, EncryptionService>();

            // common
            container.RegisterType<IDoctorVisitResult, DoctorVisitResult>();

            // users
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IUserRegistrationService, UserRegistrationService>();
        }
    }
}
