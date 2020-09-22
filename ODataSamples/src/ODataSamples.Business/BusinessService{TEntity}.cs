namespace ODataSamples.Business
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Interfaces;

    using MedeaOne.Tools.Data;

    public abstract class BusinessService<TEntity> : IBusinessService<TEntity> where TEntity : class, IObjectState
    {
        #region Public Properties

        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <value>The unit of work.</value>
        public IUnitOfWork UnitOfWork { get; }

        #endregion Public Properties

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessService{TEntity}" /> class.
        /// </summary>
        protected BusinessService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        #endregion Public Constructors

        /// <summary>
        /// Creates the specified item.
        /// </summary>
        /// <param name="item">The item to create.</param>
        /// <returns>The item created.</returns>
        public virtual TEntity Create(TEntity item)
        {
            IRepository<TEntity> repository = UnitOfWork.Repository<TEntity>();

            repository.Add(item);

            UnitOfWork.SaveChanges();

            return item;
        }

        /// <summary>
        /// Creates the specified item.
        /// </summary>
        /// <param name="item">The item to create.</param>
        /// <returns>The task for the async operation that will return the item created.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual async Task<TEntity> CreateAsync(TEntity item)
        {
            IRepository<TEntity> repository = UnitOfWork.Repository<TEntity>();

            repository.Add(item);

            await UnitOfWork.SaveChangesAsync().ConfigureAwait(false);

            return item;
        }

        /// <summary>
        /// Deletes the specified item.
        /// </summary>
        /// <param name="keyValues">The primary key values.</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void Delete(params object[] keyValues)
        {
            IRepository<TEntity> repository = UnitOfWork.Repository<TEntity>();

            repository.Delete(keyValues);

            UnitOfWork.SaveChanges();
        }

        /// <summary>
        /// Deletes the specified item.
        /// </summary>
        /// <param name="keyValues">The primary key values.</param>
        /// <returns>The task for the async operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual Task DeleteAsync(params object[] keyValues)
        {
            IRepository<TEntity> repository = UnitOfWork.Repository<TEntity>();

            repository.Delete(keyValues);

            return UnitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves an entity using it's primary key values.
        /// </summary>
        /// <param name="keyValues">The key values.</param>
        /// <returns>The entity requested or null if it was not found.</returns>
        public virtual TEntity Retrieve(params object[] keyValues)
        {
            return UnitOfWork.Repository<TEntity>().Find(keyValues);
        }

        /// <summary>
        /// Retrieves an entity using it's primary key values.
        /// </summary>
        /// <param name="keyValues">The key values.</param>
        /// <returns>
        /// The task for the async operation that will return the entity requested or null if it was not found upon completion.
        /// </returns>
        public virtual Task<TEntity> RetrieveAsync(params object[] keyValues)
        {
            return UnitOfWork.Repository<TEntity>().FindAsync(keyValues);
        }

        /// <summary>
        /// Retrieves all the items of this type.
        /// </summary>
        /// <returns>IQueryable list of items.</returns>
        public virtual IQueryable<TEntity> RetrieveAll()
        {
            return UnitOfWork.Repository<TEntity>().GetAll();
        }

        /// <summary>
        /// Retrieves all the items of this type.
        /// </summary>
        /// <returns>The task for the async operation that will return the IEnumerable list of items upon completion.</returns>
        public virtual Task<IQueryable<TEntity>> RetrieveAllAsync()
        {
            return Task.FromResult(RetrieveAll());
        }

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item to update.</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void Update(TEntity item)
        {
            IRepository<TEntity> repository = UnitOfWork.Repository<TEntity>();

            repository.Update(item);

            UnitOfWork.SaveChanges();
        }

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item to update.</param>
        /// <returns>The task for the async operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task UpdateAsync(TEntity item)
        {
            IRepository<TEntity> repository = UnitOfWork.Repository<TEntity>();

            repository.Update(item);

            await UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}