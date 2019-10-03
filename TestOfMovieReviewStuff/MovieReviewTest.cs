using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDM.CompulsoryAssingment1;
using System;
using System.Collections.Generic;

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

        [DataRow(1, 3.75)]
        [DataRow(2, 3.56)]
        [DataRow(5, 3.92)]
        [TestMethod]
        public void TestAverageGradeGiven(int ReviewID, double expected)
        {

            double Result = _service.AverageGradeGiven(ReviewID);
            Assert.AreEqual(expected, Math.Round(Result, 2));
        }

        [DataRow(2, 4, 42)]
        [DataRow(4, 5, 19)]
        [TestMethod]
        public void TestNumberOfTimesGradesGiven(int ReviewID, int SpecificRating, int expected)
        {
            int Result = _service.NumberOfTimesGradesGiven(ReviewID, SpecificRating);
            Assert.AreEqual(expected, Result);
        }

        [DataRow(2059652, 22)]
        [DataRow(1759415, 15)]
        [TestMethod]
        public void TestNumberOfReviewsRecieved(int MovieID, int expected)
        {
            int Result = _service.NumberOfReviewsRecieved(MovieID);
            Assert.AreEqual(expected, Result);
        }

        [DataRow(2059652, 3.77)]
        [DataRow(1759415, 3.47)]
        [TestMethod]
        public void TestAverageGradeRecieved(int MovieID, double expected)
        {
            double Result = _service.AverageGradeRecieved(MovieID);
            Assert.AreEqual(expected, Math.Round(Result, 2));
        }

        [DataRow(1759415, 5, 4)]
        [DataRow(2175886, 4, 8)]
        [TestMethod]
        public void TestNumberOfTimesGradesRecieved(int MovieID, int SpecificRating, int expected)
        {
            int Result = _service.NumberOfTimesGradesRecieved(MovieID, SpecificRating);
            Assert.AreEqual(expected, Result);
        }

        [DataRow(new int[] { 7, 2570542 })]
        [TestMethod]
        public void TestGetAllMovieWithHighestNumberOfTopRates(int[] expected)
        {
            int[] Result = _service.GetAllMovieWithHighestNumberOfTopRates();
            for (int i = 0; i < Result.Length; i++)
            {
                Assert.AreEqual(expected[i], Result[i]);
            }
        }

        [DataRow(new int[] { 8, 1 })]
        [TestMethod]
        public void TestGetAllReviewerWithMostReviews(int[] expected)
        {

            int[] Result = _service.GetAllReviewerWithMostReviews();
            for (int i = 0; i < Result.Length; i++)
            {
                Assert.AreEqual(expected[i], Result[i]);
            }
        }

        [DataRow(5, new int[5] {7, 59, 168, 25, 10})]
        [TestMethod]
        public void TestGetTop(int NumberOfEntries, int[] expectedList)
        {
            int[] Result = _service.GetTop(NumberOfEntries);
            for (int i = 0; i < expectedList.Length; i++)
            {
                Assert.AreEqual(expectedList[i], Result[i]);
            }
        }

        [DataRow(1, new int[] { 2570542, 8 })]
        [TestMethod]
        public void TestGetReviewsSorted(int ReviewerID, int[] expected)
        {
            int[] result = _service.GetReviewsSorted(ReviewerID);
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestMethod]
        public void TestGetReviewersSorted(int MovieID, int[] expected)
        {
            int[] result = _service.GetReviewersSorted(MovieID);
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }
    }
}
