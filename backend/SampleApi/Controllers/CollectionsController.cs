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
    /// Creates a New Collections Controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionsController : ControllerBase
    {
        private readonly IComicCollectionDAO comicCollectionDAO;
        private readonly IComicBookDAO comicBookDAO;

        /// <summary>
        /// Creates a comic collections controller.
        /// </summary>
        /// <param name="comicCollectionDAO">the comic colllection dao.</param>
        public CollectionsController(IComicCollectionDAO comicCollectionDAO, IComicBookDAO comicBookDAO)
        {
            this.comicCollectionDAO = comicCollectionDAO;
            this.comicBookDAO = comicBookDAO;
        }

        /// <summary>
        /// Gets a list of comic collections and returns a status code.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ComicCollection> Get()
        {
            return comicCollectionDAO.GetCollections();
        }

        /// <summary>
        /// Gets a single comic collection
        /// </summary>
        /// <param name="ID">collection id</param>
        /// <returns>Comic Collection</returns>
        [HttpGet("{id}")]
        public ActionResult<ComicCollection> GetCollectionByID(int ID)
        {
            ComicCollection collection = comicCollectionDAO.GetASingleCollection(ID);
            collection.Comics = comicBookDAO.GetComicsByCollectionID(ID);
            return collection;
        }

        /// <summary>
        /// Saves a new collection
        /// </summary>
        /// <param name="newCollection"></param>
        /// <returns>OK</returns>
        [HttpPost]
        [Route("/api/create")]
        public IActionResult Create(ComicCollection newCollection)
        {
            comicCollectionDAO.CreateCollection(newCollection);
            return Ok();
        }
    }
}