using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApi.DAL;
using SampleApi.Models;

namespace SampleApi.Controllers
{
    /// <summary>
    /// Creates a controller for comic books
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ComicController : ControllerBase
    {
        private readonly IComicBookDAO dao;

        /// <summary>
        /// Creates a comic controller.
        /// </summary>
        /// <param name="dao">the comic colllection dao.</param>
        public ComicController(IComicBookDAO dao)
        {
            this.dao = dao;
        }

        /// <summary>
        /// Gets a single comic by it's ID
        /// </summary>
        /// <param name="ID">A comic ID</param>
        /// <returns>Ok, a comic book object</returns>
        [HttpGet("{id}")]
        public ActionResult<ComicBook> Get(int ID)
        {
            return Ok(dao.GetComicBookByID(ID));
        }

        /// <summary>
        /// Saves a comic book to the database
        /// </summary>
        /// <param name="newComic">A comic book item</param>
        /// <returns>created, the comic book that was saved</returns>
        [HttpPost]
        public ActionResult Post(ComicBook newComic)
        {
            dao.AddComicBook(newComic);
            return Created("", newComic);
        }

        /// <summary>
        /// Searches for a comic by title and issue number
        /// </summary>
        /// <param name="title">Title</param>
        /// <param name="issue">Issue</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/search/{title}/{issue}")]
        public ActionResult<ComicBook> Search(string title, int issue)
        {
            ComicBook comic = dao.GetComicBookByIssue(title, issue);
            return Ok(comic);
        }

        [HttpGet("publisher/{publisher}")]
        public IList<ComicBook> SearchByPublisher(string publisher)
        {
            return dao.SearchByPublisher(publisher);
        }

        [HttpGet("date/{start}/{end}")]
        public IList<ComicBook> SearchByDate(DateTime start, DateTime end)
        {
            return dao.ComicsFromDateRange(start, end);
        }
    }
}