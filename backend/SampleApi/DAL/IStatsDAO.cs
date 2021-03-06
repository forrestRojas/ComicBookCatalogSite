﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleApi.Models;

namespace SampleApi.DAL
{
    /// <summary>
    /// An interface for statistics
    /// </summary>
    public interface IStatsDAO
    {
        /// <summary>
        /// A list of recently updated collections
        /// </summary>
        /// <returns>A list of collections</returns>
        IList<Search> RecentlyUpdated();

        /// <summary>
        /// A list of the largest collcetions
        /// </summary>
        /// <returns>A list of collcetions</returns>
        IList<Search> LargestCollection();

        /// <summary>
        /// A list of the most collceted comics
        /// </summary>
        /// <returns>A likst of comic books</returns>
        IList<Search> MostPopularComic();

        /// <summary>
        /// The total number of comics in the database
        /// </summary>
        /// <returns>The number of comics</returns>
        int TotalComics();

        /// <summary>
        /// The total number of collections in the database
        /// </summary>
        /// <returns>The number of collections</returns>
        int TotalCollections();

        /// <summary>
        /// A list of the publishers that shows up the most in the collection
        /// </summary>
        /// <returns>Name of publisher and count of appearances</returns>
        IList<Search> MostPopularPublisher();

        /// <summary>
        /// A list of user's with the biggest total number of comics
        /// </summary>
        /// <returns>A list of users</returns>
        IList<Search> UserWithMostComics();
    }
}
