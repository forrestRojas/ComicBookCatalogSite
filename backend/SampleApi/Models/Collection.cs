using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Models
{
    /// <summary>
    /// Represents a Collections Model.
    /// </summary>
    public class Collection
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

        /// <summary>
        /// The date the collection was created
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// The date the last update was made to a collection
        /// </summary>
        public DateTime UpdatedDate { get; set; }

        /// <summary>
        /// The list of comics in the collection
        /// </summary>
        public IList<ComicBook> Comics { get; set; }
    }
}
