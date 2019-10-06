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

        [DataRow(1, 3.5)]
        [DataRow(2, 4.5)]
        [TestMethod]
        public void TestAverageGradeRecieved(int MovieID, double expected)
        {
            _service = new MovieReviewService(new MovieReviewRepository("TestJson/Json_TestAverageGradeRecieved.json"));
            double Result = _service.AverageGradeRecieved(MovieID);
            Assert.AreEqual(expected, Math.Round(Result, 2));
        }

        [DataRow(1, 4, 4)]
        [DataRow(2, 5, 6)]
        [TestMethod]
        public void TestNumberOfTimesGradesRecieved(int MovieID, int SpecificRating, int expected)
        {
            _service = new MovieReviewService(new MovieReviewRepository("TestJson/Json_TestNumberOfTimesGradesRecieved.json"));
            int Result = _service.NumberOfTimesGradesRecieved(MovieID, SpecificRating);
            Assert.AreEqual(expected, Result);
        }

        [DataRow(new int[] { 3, 4 }, "TestJson/Json_TestGetAllMovieWithHighestNumberOfTopRates_many.json")]
        [DataRow(new int[] { 3 }, "TestJson/Json_TestGetAllMovieWithHighestNumberOfTopRates_one.json")]
        [TestMethod]
        public void TestGetAllMovieWithHighestNumberOfTopRates(int[] expected, string testUrl)
        {
            _service = new MovieReviewService(new MovieReviewRepository(testUrl));
            int[] Result = _service.GetAllMovieWithHighestNumberOfTopRates(); 
            for (int i = 0; i < Result.Length; i++)
            {
                Assert.AreEqual(expected[i], Result[i]);
            }
        }

        [DataRow(new int[] { 2, 1 }, "TestJson/Json_TestGetAllReviewerWithMostReviews_many.json")]
        [DataRow(new int[] { 3 }, "TestJson/Json_TestGetAllReviewerWithMostReviews_one.json")]
        [TestMethod]
        public void TestGetAllReviewerWithMostReviews(int[] expected, string testUrl)
        {
            _service = new MovieReviewService(new MovieReviewRepository(testUrl));
            int[] Result = _service.GetAllReviewerWithMostReviews();
            for (int i = 0; i < Result.Length; i++)
            {
                Assert.AreEqual(expected[i], Result[i]);
            }
        }

        [DataRow(5, new int[5] {10, 8, 4, 2, 7})]
        [DataRow(10, new int[10] { 10, 8, 4, 2, 7, 1, 6, 3, 5, 9 })]

        [TestMethod]
        public void TestGetTop(int NumberOfEntries, int[] expectedList)
        {
            _service = new MovieReviewService(new MovieReviewRepository("TestJson/Json_TestGetTop.json"));
            int[] Result = _service.GetTop(NumberOfEntries);
            for (int i = 0; i < expectedList.Length; i++)
            {
                Assert.AreEqual(expectedList[i], Result[i]);
            }
        }

        [DataRow(1, new int[] { 9, 6, 7, 8, 10, 4, 2, 3, 5, 1 })]
        [DataRow(2, new int[] { 2, 3, 1 })]
        [TestMethod]
        public void TestGetReviewsSorted(int ReviewerID, int[] expected)
        {
            _service = new MovieReviewService(new MovieReviewRepository("TestJson/Json_TestGetReviewsSorted.json"));
            int[] result = _service.GetReviewsSorted(ReviewerID);
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [DataRow(1, new int[] { 10, 7, 6, 8, 9, 4, 2, 3, 5, 1 })]
        [DataRow(2, new int[] { 12, 11, 13 })]
        [TestMethod]
        public void TestGetReviewersSorted(int MovieID, int[] expected)
        {
            _service = new MovieReviewService(new MovieReviewRepository("TestJson/Json_TestGetReviewersSorted.json"));
            int[] result = _service.GetReviewersSorted(MovieID);
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }
    }
}
