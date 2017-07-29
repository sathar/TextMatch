using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextMatch.Services;

namespace TextMatch.Tests
{
    [TestClass]
    public class when_search_for_text_in_a_long_text
    {
        private string _inputText = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea";
        private TextSearchService _service;
        public when_search_for_text_in_a_long_text()
        {
            _service = new TextSearchService();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "longText")]
        public void should_return_LongText_ArgumentNull_Exception()
        {
            // Arrange
            var subText = "Polly";
            // Act
            var actual = _service.GetAllMatchPos(null, subText);

            // Assert
            Assert.AreEqual(actual,string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "searchText")]
        public void should_return_SearchText_ArgumentNull_Exception()
        {
            // Arrange
            var expected = string.Empty;

            // Act
            var actual = _service.GetAllMatchPos(_inputText, null);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "searchText")]
        public void should_return_argumentnullexception_when_both_empty()
        {
            // Arrange
            var expected = string.Empty;

            // Act
            var actual = _service.GetAllMatchPos(null, null);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void search_shold_be_CaseInsensitive_with_searchtext_polly()
        {
            // Arrange
            var searchText = "PoLLY";
            var expected = string.Empty;

            // Act
            var actual = _service.GetAllMatchPos(string.Empty, searchText);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void should_find_match_with_searchtext_polly()
        {
            // Arrange
            var searchText = "Polly";
            var expected = string.Empty;

            // Act
            var actual = _service.GetAllMatchPos(string.Empty, searchText);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void search_with_polly_return_three_position()
        {
            // Arrange
            var searchText = "Polly";
            var expected = "1,26,51";

            // Act
            var actual = _service.GetAllMatchPos(_inputText, searchText);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void search_with_ll_return_five_position()
        {
            // Arrange
            var searchText = "ll";
            var expected = "3,28,53,78,82";

            // Act
            var actual = _service.GetAllMatchPos(_inputText, searchText);

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void no_match_with_x()
        {
            // Arrange
            var searchText = "X";
            var expected = string.Empty;

            // Act
            var actual = _service.GetAllMatchPos(_inputText, searchText);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void no_match_with_polyx()
        {
            // Arrange
            var searchText = "Polx";
            var expected = string.Empty;

            // Act
            var actual = _service.GetAllMatchPos(_inputText, searchText);

            // Assert
            Assert.AreEqual(expected, actual);
        }

       
    }

}
