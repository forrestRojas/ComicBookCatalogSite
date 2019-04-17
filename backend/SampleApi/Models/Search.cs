using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Models
{
    /// <summary>
    /// A class for stat searches
    /// </summary>
    public class Search
    {
        /// <summary>
        /// The id of the data
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the data
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Its attached value
        /// </summary>
        public int Value { get; set; }
    }
}
