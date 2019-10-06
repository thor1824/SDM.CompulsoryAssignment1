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


        [DataRow(1, 13)]
        [DataRow(2, 7)]
        [TestMethod]
        public void TestNumberOfReviewsGiven(int ReviewID, int expected)
        {
            _service = new MovieReviewService(new MovieReviewRepository("TestJson/Json_TestNumberOfReviewsGiven.json"));
            int Result = _service.NumberOfReviewsGiven(ReviewID);
            Assert.AreEqual(expected, Result);
        }

        [DataRow(1, 3.5)]
        [DataRow(2, 4.5)]
        [TestMethod]
        public void TestAverageGradeGiven(int ReviewID, double expected)
        {
            _service = new MovieReviewService(new MovieReviewRepository("TestJson/Json_TestAverageGradeGiven.json"));
            double Result = _service.AverageGradeGiven(ReviewID);
            Assert.AreEqual(expected, Math.Round(Result, 2));
        }

        [DataRow(1, 4, 6)]
        [DataRow(2, 5, 4)]
        [TestMethod]
        public void TestNumberOfTimesGradesGiven(int ReviewID, int SpecificRating, int expected)
        {
            _service = new MovieReviewService(new MovieReviewRepository("TestJson/Json_TestNumberOfTimesGradesGiven.json"));
            int Result = _service.NumberOfTimesGradesGiven(ReviewID, SpecificRating);
            Assert.AreEqual(expected, Result);
        }

        [DataRow(1, 8)]
        [DataRow(2, 12)]
        [TestMethod]
        public void TestNumberOfReviewsRecieved(int MovieID, int expected)
        {
            _service = new MovieReviewService(new MovieReviewRepository("TestJson/Json_TestNumberOfReviewsRecieved.json"));
            int Result = _service.NumberOfReviewsRecieved(MovieID);
            Assert.AreEqual(expected, Result);
        }

        [DataRow(1, 3.4)]
        [DataRow(2, 4.5)]
        [TestMethod]
        public void TestAverageGradeRecieved(int MovieID, double expected)
        {
            _service = new MovieReviewService(new MovieReviewRepository("TestJson/Json_TestAverageGradeRecieved.json"));
            double Result = _service.AverageGradeRecieved(MovieID);
            Assert.AreEqual(expected, Math.Round(Result, 2));
        }

        [DataRow(1759415, 5, 4)]
        [DataRow(2175886, 4, 8)]
        [TestMethod]
        public void TestNumberOfTimesGradesRecieved(int MovieID, int SpecificRating, int expected)
        {
            _service = new MovieReviewService(new MovieReviewRepository("C:/Users/thor1/Desktop/ratings_test.json"));
            int Result = _service.NumberOfTimesGradesRecieved(MovieID, SpecificRating);
            Assert.AreEqual(expected, Result);
        }

        [DataRow(new int[] { 7, 2570542 })]
        [TestMethod]
        public void TestGetAllMovieWithHighestNumberOfTopRates(int[] expected)
        {
            _service = new MovieReviewService(new MovieReviewRepository("TestJson/Json_TestGetAllMovieWithHighestNumberOfTopRates.json"));
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
            _service = new MovieReviewService(new MovieReviewRepository("TestJson/Json_TestGetAllReviewerWithMostReviews.json"));
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
            _service = new MovieReviewService(new MovieReviewRepository("C:/Users/thor1/Desktop/ratings_test.json"));
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
            _service = new MovieReviewService(new MovieReviewRepository("C:/Users/thor1/Desktop/ratings_test.json"));
            int[] result = _service.GetReviewsSorted(ReviewerID);
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestMethod]
        public void TestGetReviewersSorted(int MovieID, int[] expected)
        {
            _service = new MovieReviewService(new MovieReviewRepository("C:/Users/thor1/Desktop/ratings_test.json"));
            int[] result = _service.GetReviewersSorted(MovieID);
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }
    }
}
