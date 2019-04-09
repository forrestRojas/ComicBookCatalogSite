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

        /// <summary>
        /// Creates a comic collections controller.
        /// </summary>
        /// <param name="comicCollectionDAO">the comic colllection dao.</param>
        public CollectionsController(IComicCollectionDAO comicCollectionDAO)
        {
            this.comicCollectionDAO = comicCollectionDAO;
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
    }
}