namespace NetFull.ODataTest
{
    using System.Web.Http;

    using NetFull.ODataTest.Models;

    using Unity;
    using Unity.Lifetime;

    public static class DIConfig
    {
        public static void Register(HttpConfiguration config)
        {
            UnityContainer container = new UnityContainer();
            container.RegisterType<IProductRepository, ProductRepository>(new TransientLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}