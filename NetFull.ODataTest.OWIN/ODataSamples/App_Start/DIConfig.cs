namespace ODataSamples
{
    using System.Web.Http;

    using Models;

    using Unity;
    using Unity.Lifetime;

    public static class DIConfig
    {
        public static void Register(HttpConfiguration config)
        {
            UnityContainer container = new UnityContainer();
            container.RegisterType<IProductRepository, ProductRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}