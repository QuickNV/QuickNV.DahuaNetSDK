using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System;

namespace Dahua.Api.Helpers
{
    /// <summary>
    /// DahuaApi Exception
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class DahuaApiException : Exception
    {
        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="DahuaApiException" /> class.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="errorMessage">The error message.</param>
        public DahuaApiException(string method, string errorMessage)
            : base(method)
        {
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"{ErrorMessage}{Environment.NewLine}{base.ToString()}";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DahuaApiException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected DahuaApiException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
