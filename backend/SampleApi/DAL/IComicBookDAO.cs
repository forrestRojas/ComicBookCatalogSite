using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleApi.Models;

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

        /// <summary>
        /// Finds a comic book by the issue number and title
        /// </summary>
        /// <param name="seriesTitle">Title of the comic series</param>
        /// <param name="issueNumber">Issue number being searched for</param>
        /// <returns></returns>
        ComicBook GetComicBookByIssue(string seriesTitle, int issueNumber);

        /// <summary>
        /// A list of comics from a specified date range
        /// </summary>
        /// <returns>A list of comics</returns>
        IList<ComicBook> ComicsFromDateRange(DateTime start, DateTime end);

        /// <summary>
        /// A list of comics from a single publisher
        /// </summary>
        /// <param name="publisher">The publisher</param>
        /// <returns>A list of comic books</returns>
        IList<ComicBook> SearchByPublisher(string publisher);
    }
}
