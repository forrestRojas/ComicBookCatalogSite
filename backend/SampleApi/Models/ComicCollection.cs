using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Models
{
    /// <summary>
    /// Represents a Comic Collections Model.
    /// </summary>
    public class ComicCollection
    {
        /// <summary>
        /// The Collection's id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The User id associated to the collection.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The title of the collection.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Image for the collection
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// A short description about the collection.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The Level of access needed to view this collection.
        /// </summary>
        public string AccessLevel { get; set; }
    }
}
