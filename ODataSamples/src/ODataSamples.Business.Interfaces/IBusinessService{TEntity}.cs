namespace ODataSamples.Business.Interfaces
{
    using System.Linq;
    using System.Threading.Tasks;

    using MedeaOne.Tools.Data;

    /// <summary>
    /// Interface that must be implemented by any Business Service.
    /// </summary>
    /// <typeparam name="TEntity">
    /// The type of the entities that are managed by the service.
    /// </typeparam>
    public interface IBusinessService<TEntity> where TEntity : class, IObjectState
    {
        /// <summary>
        /// Creates the specified item.
        /// </summary>
        /// <param name="item"> The item to create. </param>
        /// <returns> The item created. </returns>
        /// <exception cref="ItemAlreadyExistsException">
        /// Is thrown when already exists an entity with the same name, id or
        /// which unique field.
        /// </exception>
        TEntity Create(TEntity item);

        /// <summary>
        /// Creates the specified item.
        /// </summary>
        /// <param name="item"> The item to create. </param>
        /// <returns>
        /// The task for the async operation that will return the item created.
        /// </returns>
        /// <exception cref="ItemAlreadyExistsException">
        /// Is thrown when already exists an entity with the same name, id or
        /// which unique field.
        /// </exception>
        Task<TEntity> CreateAsync(TEntity item);

        /// <summary>
        /// Deletes the specified item.
        /// </summary>
        /// <param name="keyValues"> The primary key values. </param>
        /// <exception cref="ItemNotFoundException">
        /// Is thrown when the item does not exist.
        /// </exception>
        /// <exception cref="ItemHasDependantObjectsException">
        /// Is thrown when has dependant undeleted children.
        /// </exception>
        void Delete(params object[] keyValues);

        /// <summary>
        /// Deletes the specified item.
        /// </summary>
        /// <param name="keyValues"> The primary key values. </param>
        /// <returns> The task for the async operation. </returns>
        /// <exception cref="ItemNotFoundException">
        /// Is thrown when the item does not exist.
        /// </exception>
        /// <exception cref="ItemHasDependantObjectsException">
        /// Is thrown when has dependant undeleted children.
        /// </exception>
        Task DeleteAsync(params object[] keyValues);

        /// <summary>
        /// Retrieves an entity using it's primary key values.
        /// </summary>
        /// <param name="keyValues"> The key values. </param>
        /// <returns> The entity requested or null if it was not found. </returns>
        /// <exception cref="ItemNotFoundException">
        /// Is thrown when item does not exist.
        /// </exception>
        TEntity Retrieve(params object[] keyValues);

        /// <summary>
        /// Retrieves an entity using it's primary key values.
        /// </summary>
        /// <param name="keyValues"> The key values. </param>
        /// <returns>
        /// The task for the async operation that will return the entity
        /// requested or null if it was not found upon completion.
        /// </returns>
        /// <exception cref="ItemNotFoundException">
        /// Is thrown when item does not exist.
        /// </exception>
        Task<TEntity> RetrieveAsync(params object[] keyValues);

        /// <summary>
        /// Retrieves all the items of this type.
        /// </summary>
        /// <returns> IQueryable list of items. </returns>
        IQueryable<TEntity> RetrieveAll();

        /// <summary>
        /// Retrieves all the items of this type.
        /// </summary>
        /// <returns>
        /// The task for the async operation that will return the IEnumerable
        /// list of items upon completion.
        /// </returns>
        Task<IQueryable<TEntity>> RetrieveAllAsync();

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item"> The item to update. </param>
        void Update(TEntity item);

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item"> The item to update. </param>
        /// <returns> The task for the async operation. </returns>
        Task UpdateAsync(TEntity item);
    }
}