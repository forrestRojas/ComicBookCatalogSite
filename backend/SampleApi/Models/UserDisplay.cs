using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Models
{
    public class UserDisplay
    {
        /// <summary>
        /// The user's id.
        /// </summary>        
        public int Id { get; set; }

        /// <summary>
        /// The user's username.
        /// </summary>        
        public string Username { get; set; }
          
        /// <summary>
        /// The user's role.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// A user bio.
        /// </summary>
        public string Bio { get; set; }

        /// <summary>
        /// A field for user's favorites
        /// </summary>
        public string Favorites { get; set; }

        /// <summary>
        /// A link for a user image
        /// </summary>
        public string Image { get; set; }
    }
}
