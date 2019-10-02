using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDM.CompulsoryAssingment1
{
    public class MovieReviewService
    {
        public int NumberOfReviewsGiven(int ReviewID)
        {
            return MVDataSource.GetMovieReviews().Where(mr => mr.Reviewer == ReviewID).Count(); 
        }

        public double AverageGradeGiven(int ReviewID)
        {
            List<MovieReview> list = MVDataSource.GetMovieReviews().Where(mr => mr.Reviewer == ReviewID).ToList();
            double gradeSum = 0;
            foreach (var item in list)
            {
                gradeSum += item.Grade;
            }
            return gradeSum / list.Count();
        }

        public int NumberOfTimesGradesGiven(int ReviewID, int SpecificRating)
        {
            return MVDataSource.GetMovieReviews().Where(mr => mr.Reviewer == ReviewID).Where(mr => mr.Grade == SpecificRating).Count();
        }

        public int NumberOfReviewsRecieved(int MovieID)
        {
            return MVDataSource.GetMovieReviews().Where(mr => mr.Movie == MovieID).Count();
        }

        public double AverageGradeRecieved(int MovieID)
        {
            List<MovieReview> list = MVDataSource.GetMovieReviews().Where(mr => mr.Movie == MovieID).ToList();
            double gradeSum = 0;
            foreach (var item in list)
            {
                gradeSum += item.Grade;
            }
            return gradeSum / list.Count();
        }

        public int NumberOfTimesGradesRecieved(int MovieID, int SpecificRating)
        {
            return MVDataSource.GetMovieReviews().Where(mr => mr.Movie == MovieID).Where(mr => mr.Grade == SpecificRating).Count();
        }

        public int GetMovieWithHighestNumberOfTopRates()
        {
            return -1;
        }

        public int GetReviewerWithMostReviews()
        {
            return -1;
        }

        public IList<MovieReview> GetTop(int NumberOfEntries)
        {
            return null;
        }

        public IList<MovieReview> GetReviewsSorted(int ReviewerID)
        {
            return null;
        }

        public IList<MovieReview> GetReviewersSorted(int MovieID)
        {
            return null;
        }



    }
}
