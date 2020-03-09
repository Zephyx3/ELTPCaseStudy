using System.Web.Http;
using Unity;
using Unity.WebApi;
using ELTPServiceLayer;
using System.Web.Mvc;
using Unity.Mvc5;

namespace ELTPCaseStudy
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IUsersService, UserService>();
            container.RegisterType<IMoviesService, MoviesService>();
            container.RegisterType<IReviewsService, ReviewsService>();
            container.RegisterType<IRentalsService, RentalsService>();

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
           
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}