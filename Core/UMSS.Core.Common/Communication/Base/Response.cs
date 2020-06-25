using System;
using System.Collections.Generic;
using System.Text;
using UMSS.Core.Common.Entities.Base;

namespace UMSS.Core.Common.Communication.Base
{
    public class Response<T> : BaseResponse where T : class
    {
        public T Entity { get; private set; }
        public IEnumerable<T> EntityList { get; private set; }

        private Response(bool success, string message, T entity, IEnumerable<T> entityList) : base(success, message)
        {
            Entity = entity;
            EntityList = entityList;
        }

        /// <summary>
        /// Creates a void success response.
        /// </summary>
        /// <returns>Response.</returns>
        public Response() : this(true, string.Empty, null, null)
        { }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <returns>Response.</returns>
        public Response(T entity) : this(true, string.Empty, entity, null)
        { }

        /// <summary>
        /// Creates a success response for list.
        /// </summary>
        /// <returns>Response.</returns>
        public Response(IEnumerable<T> entityList) : this(true, string.Empty, null, entityList)
        { }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public Response(string message) : this(false, message, null, null)
        { }
    }
}
