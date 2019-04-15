using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleApi.DAL;
using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApi.Tests.DAL
{
    [TestClass]
    public class CBSDTest
    {
        [TestMethod]
        public void Test()
        {
            ComicBook book = new ComicBook();
            ComicBookSQLDAO dao = new ComicBookSQLDAO("Data Source=.\\SQLEXPRESS;Initial Catalog=ComicCollection;Integrated Security=True");
            book = dao.GetComicBookByIssue("Omaha the Cat Dancer", 14);

        }
    }
}
