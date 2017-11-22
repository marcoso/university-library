using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniversityLibraryWeb.Controllers;
using UniversityLibraryWeb;



namespace UniversityLibraryWeb.Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Home()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("University Library", result.ViewBag.Title);
        }

        [TestMethod]
        public void SearchBooks()
        {
            // Arrange
            SearchBooksController controller = new SearchBooksController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("University Library", result.ViewBag.Title);
        }

        [TestMethod]
        public void SearchBooksIndex()
        {
            // Arrange
            SearchBooksController controller = new SearchBooksController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BooksHistorical()
        {
            // Arrange
            BooksHistoricalsController controller = new BooksHistoricalsController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("University Library", result.ViewBag.Title);
        }

        [TestMethod]
        public void BooksHistoricalIndex()
        {
            // Arrange
            BooksHistoricalsController controller = new BooksHistoricalsController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
