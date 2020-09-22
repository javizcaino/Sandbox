namespace ODataSamples.Business.Interfaces
{
    using System;

    /// <summary>
    /// Exception that indicates that an entity does not exist in the repository.
    /// </summary>
    public class ItemNotFoundException : Exception
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemNotFoundException"
        /// /> class.
        /// </summary>
        public ItemNotFoundException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemNotFoundException"
        /// /> class.
        /// </summary>
        /// <param name="message"> Message describing the error. </param>
        public ItemNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemNotFoundException"
        /// /> class.
        /// </summary>
        /// <param name="message">
        /// The error message that explains the reason for the exception.
        /// </param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception, or a null
        /// reference (Nothing in Visual Basic) if no inner exception is specified.
        /// </param>
        public ItemNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion Public Constructors
    }
}