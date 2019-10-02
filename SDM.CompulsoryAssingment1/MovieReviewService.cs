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
            return MVDataSource.GetMovieReviews().Where(c => c.Reviewer == ReviewID).Count(); ;
        }

        public double AverageGradeGiven(int ReviewID)
        {
            return -1;
        }

        public int NumberOfTimesGradesGiven(int ReviewID, int SpecificRating)
        {
            return -1;
        }

        public int NumberOfReviewsRecieved(int MovieID)
        {
            return -1;
        }

        public double AverageGradeRecieved(int MovieID)
        {
            return -1;
        }

        public int NumberOfTimesGradesRecieved(int MovieID, int SpecificRating)
        {
            return -1;
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
