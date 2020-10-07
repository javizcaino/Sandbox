namespace NetCore.ODataTest
{
    using System.Linq;

    using Microsoft.AspNet.OData.Builder;
    using Microsoft.AspNet.OData.Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Debug;

    using NetCore.ODataTest.Models;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddOData();

            services.AddDbContext<ProductsContext>(options =>
            {
                options.UseSqlServer("Data Source=.;Initial Catalog=Products;Integrated Security=True; MultipleActiveResultSets=True");
                options.UseLoggerFactory(new LoggerFactory(new[] { new DebugLoggerProvider() }));
                options.EnableSensitiveDataLogging();
            });

            services.AddScoped<IProductRepository, ProductRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder(app.ApplicationServices);

            builder.EntitySet<Product>("Products");

            app.UseMvc(routeBuilder =>
            {
                // and this line to enable OData query option, for example $filter
                routeBuilder
                    .Count()
                    .Filter()
                    .OrderBy()
                    .Expand()
                    .Select()
                    .MaxTop(null);

                routeBuilder.MapODataServiceRoute(
                    routeName: "ODataRoute",
                    routePrefix: null,
                    model: builder.GetEdmModel());

                // uncomment the following line to Work-around for #1175 in beta1
                // routeBuilder.EnableDependencyInjection();
            });
        }
    }
}
