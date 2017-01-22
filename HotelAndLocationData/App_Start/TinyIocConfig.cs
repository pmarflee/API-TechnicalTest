using HotelAndLocationData.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using TinyIoC;

namespace HotelAndLocationData
{
    public class TinyIocConfig
    {
        public static void Configure()
        {
            var container = TinyIoCContainer.Current;

            container.Register<IDataService>((c, p) =>
            {
                return new DataService(
                    ConfigurationManager.AppSettings["BaseUrl"],
                    ConfigurationManager.AppSettings["Username"],
                    ConfigurationManager.AppSettings["Password"]);
            });

            DependencyResolver.SetResolver(new TinyIocMvcDependencyResolver(container));
        }

        class TinyIocMvcDependencyResolver : IDependencyResolver
        {
            private TinyIoCContainer _container;
            public TinyIocMvcDependencyResolver(TinyIoCContainer container)
            {
                _container = container;
            }
            public object GetService(Type serviceType)
            {
                try
                {
                    return _container.Resolve(serviceType);
                }
                catch (Exception)
                {
                    return null;
                }
            }
            public IEnumerable<object> GetServices(Type serviceType)
            {
                try
                {
                    return _container.ResolveAll(serviceType, true);
                }
                catch (Exception)
                {
                    return Enumerable.Empty<object>();
                }
            }
        }
    }
}