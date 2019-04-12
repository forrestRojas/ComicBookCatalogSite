using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.DAL
{
    /// <summary>
    /// Interface definition for comic book data communication
    /// </summary>
    public interface IComicBookDAO
    {
        /// <summary>
        /// Returns all comic books
        /// </summary>
        /// <returns></returns>
        IList<ComicBook> GetAllComicBooks();

        /// <summary>
        /// Returns a comic book by the ID
        /// </summary>
        /// <returns></returns>
        ComicBook GetComicBookByID(int id);

        /// <summary>
        /// Adds a new comic book
        /// </summary>
        /// <param name="book"></param>
        void AddComicBook(ComicBook book);

        /// <summary>
        /// Returns the comics of a single collection
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A list of comic book items</returns>
        IList<ComicBook> GetComicsByCollectionID(int id);
    }
}
