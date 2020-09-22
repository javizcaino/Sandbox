namespace ODataSamples.Data
{
    using System.Reflection;

    using MedeaOne.Tools.Data.EntityFrameworkCore;

    using Microsoft.EntityFrameworkCore;

    public class ODataSamplesDataContext : DataContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ODataSamplesDataContext"
        /// /> class.
        /// </summary>
        /// <param name="name"> The name. </param>
        public ODataSamplesDataContext(DbContextOptions<ODataSamplesDataContext> options)
            : base(options)
        {
        }

        #region Protected Methods

        /// <summary>
        /// This method is called when the model for a derived context has been
        /// initialized, but before the model has been locked down and used to
        /// initialize the context. The default implementation of this method
        /// does nothing, but it can be overridden in a derived class such that
        /// the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">
        /// The builder that defines the model for the context being created.
        /// </param>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of
        /// a derived context is created. The model for that context is then
        /// cached and is for all further instances of the context in the app
        /// domain. This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuilder, but note that this can seriously
        /// degrade performance. More control over caching is provided through
        /// use of the <see cref="DbModelBuilder" /> and <see
        /// cref="DbContextFactory" /> classes directly.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(GetType()));

            base.OnModelCreating(modelBuilder);
        }

        #endregion Protected Methods
    }
}
