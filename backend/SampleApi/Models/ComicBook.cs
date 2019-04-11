using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Models
{
    public class ComicBook
    {
        /// <summary>
        /// Unique ID of the comic book
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// A description of the comic book
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A brief summary
        /// </summary>
        public string Deck { get; set; }

        /// <summary>
        /// URL for a cover image
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// The issue number of the comic
        /// </summary>
        public int IssueNumber { get; set; }

        /// <summary>
        /// The name of the issue
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Volume Number
        /// </summary>
        public int Volume { get; set; }

        /// <summary>
        /// Publication Date
        /// </summary>
        public DateTime CoverDate { get; set; }

        /// <summary>
        /// Credits for the creators
        /// </summary>
        public string Credits { get; set; }

        /// <summary>
        /// The publisher of the comic
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// The title of the comic
        /// </summary>
        public string Title { get; set; }
    }
}
