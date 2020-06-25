using System;
using System.Collections.Generic;
using System.Text;
using UMSS.Core.Common.Communication.Base;
using UMSS.Core.Common.Entities;

namespace UMSS.Core.Common.Communication
{
    public class ArtistResponse : BaseResponse
    {
        public Artist Artist { get; private set; }

        private ArtistResponse(bool success, string message, Artist artist) : base(success, message)
        {
            Artist = artist;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>
        public ArtistResponse(Artist artist) : this(true, string.Empty, artist)
        { }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ArtistResponse(string message) : this(false, message, null)
        { }
    }
}
