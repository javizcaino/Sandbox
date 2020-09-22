namespace ODataSamples
{
    using MedeaOne.Tools.Data;
    using MedeaOne.Tools.Data.EntityFrameworkCore;

    using Microsoft.AspNet.OData.Extensions;
    using Microsoft.AspNet.OData.Formatter.Serialization;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Debug;
    using Microsoft.OData.Edm;

    using ODataSamples.Business;
    using ODataSamples.Business.Interfaces;
    using ODataSamples.Data;
    using ODataSamples.ODataConfiguration;

    public class Startup
    {
        private readonly IEdmModel _odataModel = null;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _odataModel = ODataConfiguration.ODataConfig.GetEdmModel();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ODataSamplesDataContext>(options =>
                options
                    .UseSqlServer(Configuration.GetConnectionString("ODataSamplesContext"))
                    .UseLoggerFactory(new LoggerFactory(new[] { new DebugLoggerProvider() }))
                    .EnableDetailedErrors()
                    .EnableSensitiveDataLogging());

            services.AddScoped<IDataContext, ODataSamplesDataContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductsBusinessService, ProductsBusinessService>();

            services.AddControllers(mvcOptions =>
                mvcOptions.EnableEndpointRouting = false);

            services.AddOData();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMvc(routeBuilder =>
            {
                routeBuilder
                    .Count()
                    .Expand()
                    .Filter()
                    .MaxTop(null)
                    .OrderBy()
                    .Select()
                    .SkipToken();

                routeBuilder.MapODataServiceRoute("odata", null, _odataModel);
            });
        }
    }
}