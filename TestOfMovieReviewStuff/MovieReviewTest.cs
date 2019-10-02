using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDM.CompulsoryAssingment1;

namespace TestOfMovieReviewService
{
    [TestClass]
    public class MovieReviewTest
    {
        MovieReviewService _service;

        [TestInitialize()]
        public void Initialize()
        {
            _service = new MovieReviewService();
            //MVDataSource.InitData();

        }

        [DataRow(1, 547)]
        [DataRow(2, 145)]
        [TestMethod]
        public void TestNumberOfReviewsGiven(int ReviewID, int expected)
        {
            int Result = _service.NumberOfReviewsGiven(ReviewID);
            Assert.AreEqual(expected, Result);
        }

        [TestMethod]
        public void TestAverageGradeGiven(int ReviewID, double expected)
        {
            double Result = _service.AverageGradeGiven(ReviewID);
            Assert.AreEqual(expected, Result);
        }

        [TestMethod]
        public void TestNumberOfTimesGradesGiven(int ReviewID, int SpecificRating, int expected)
        {
            int Result = _service.NumberOfTimesGradesGiven(ReviewID, SpecificRating);
            Assert.AreEqual(expected, Result);
        }

        [TestMethod]
        public void TestNumberOfReviewsRecieved(int MovieID, int expected)
        {
            int Result = _service.NumberOfReviewsRecieved(MovieID);
            Assert.AreEqual(expected, Result);
        }

        [TestMethod]
        public void TestAverageGradeRecieved(int MovieID, double expected)
        {
            double Result = _service.AverageGradeRecieved(MovieID);
            Assert.AreEqual(expected, Result);
        }

        [TestMethod]
        public void TestNumberOfTimesGradesRecieved(int MovieID, int SpecificRating, int expected)
        {
            int Result = _service.NumberOfTimesGradesRecieved(MovieID, SpecificRating);
            Assert.AreEqual(expected, Result);
        }

        [TestMethod]
        public void TestGetMovieWithHighestNumberOfTopRates(int expected)
        {
            int Result = _service.GetMovieWithHighestNumberOfTopRates();
            Assert.AreEqual(expected, Result);
        }

        [TestMethod]
        public void TestGetReviewerWithMostReviews(int expected)
        {

            int Result = _service.GetMovieWithHighestNumberOfTopRates();
            Assert.AreEqual(expected, Result);
        }

        [TestMethod]
        public void TestGetTop(int NumberOfEntries)
        {
        }

        [TestMethod]
        public void TestGetReviewsSorted(int ReviewerID)
        {
        }

        [TestMethod]
        public void TestGetReviewersSorted(int MovieID)
        {
        }
    }
}
