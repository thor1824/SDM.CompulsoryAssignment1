using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDM.CompulsoryAssingment1;
using System;
using System.Diagnostics;

namespace PerformanceTestOfMovieStuff
{
    [TestClass]
    public class MovieReviewTest
    {
        MovieReviewService _service;
        public MovieReviewTest()
        {
            _service = new MovieReviewService(new MovieReviewRepository("ratings.json"));
        }

        
        [TestMethod]
        public void TestNumberOfReviewsGiven()
        {
           
            double avgTime = getAverageTime(() => _service.NumberOfReviewsGiven(5), 5);
            Assert.IsTrue(avgTime < 4.0);
        }

        
        [TestMethod]
        public void TestAverageGradeGiven()
        {
           
            double avgTime = getAverageTime(() => _service.AverageGradeGiven(5), 5);
            Assert.IsTrue(avgTime < 4.0);

        }

        
        [TestMethod]
        public void TestNumberOfTimesGradesGiven()
        {
            double avgTime = getAverageTime(() => _service.NumberOfTimesGradesGiven(5, 5), 5);
            Assert.IsTrue(avgTime < 4.0);
        }

        
        [TestMethod]
        public void TestNumberOfReviewsRecieved()
        {
            double avgTime = getAverageTime(() => _service.NumberOfReviewsRecieved(1), 5);
            Assert.IsTrue(avgTime < 4.0);
        }

        [TestMethod]
        public void TestAverageGradeRecieved()
        {
            double avgTime = getAverageTime(() => _service.AverageGradeRecieved(1), 5);
            Assert.IsTrue(avgTime < 4.0);
        }

        private double getAverageTime(Action ac, int times)
        {
            double sum = 0.0;
            for (int i = 0; i < times; i++)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                ac.Invoke();
                sw.Stop();
                sum += sw.ElapsedMilliseconds;
            }
            return (sum / (double)times) / 1000.0;

        }
    }
}
