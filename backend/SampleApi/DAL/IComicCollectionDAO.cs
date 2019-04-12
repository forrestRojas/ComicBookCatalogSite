using SampleApi.Models;
using System.Collections.Generic;

namespace SampleApi.DAL
{
    /// <summary>
    /// An interface for the ComicCollectionDAO.
    /// </summary>
    public interface IComicCollectionDAO
    {
        /// <summary>
        /// graps all the collections from the DB.
        /// </summary>
        /// <returns>A List of Collections</returns>
        IList<ComicCollection> GetCollections();

        /// <summary>
        /// Saves a list of collections to the DB.
        /// </summary>
        /// <param name="collections">The List to be saved.</param>
        /// <returns>A Bool indicating if the transaction was succesfull.</returns>
        bool SaveCollections(IList<ComicCollection> collections);

        /// <summary>
        /// Returns a single comic collection
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ComicCollection GetASingleCollection(int id);

        /// <summary>
        /// Saves a new collection
        /// </summary>
        /// <param name="newCollection">The new collection</param>
        void CreateCollection(ComicCollection newCollection);
    }
}