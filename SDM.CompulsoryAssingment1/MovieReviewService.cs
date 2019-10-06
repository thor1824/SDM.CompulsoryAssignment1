using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDM.CompulsoryAssingment1
{
    public class MovieReviewService
    {
        private MovieReviewRepository _repo;

        public MovieReviewService(MovieReviewRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Function 1:
        /// Get the number of reviews from a given <code>ReviewID</code>.
        /// </summary>
        /// <param name="ReviewID"></param>
        /// <returns></returns>
        public int NumberOfReviewsGiven(int ReviewID)
        {
            return _repo.GetMovieReviews().Where(mr => mr.Reviewer == ReviewID).Count(); 
        }

        /// <summary>
        /// Function 2:
        /// Get the average Grade that the given reviewer, derived from <code>ReviewID</code>, have given.
        /// </summary>
        /// <param name="ReviewID"></param>
        /// <returns></returns>
        public double AverageGradeGiven(int ReviewID)
        {
            List<MovieReview> list = _repo.GetMovieReviews().Where(mr => mr.Reviewer == ReviewID).ToList();
            double gradeSum = 0;
            foreach (var item in list)
            {
                gradeSum += item.Grade;
            }
            return gradeSum / list.Count();
        }

        /// <summary>
        /// Function 3:
        /// On input <code>ReviewID</code> and <code>SpecificRating</code>, get number of times reviewer of <code>ReviewID</code> has given a movie grade of <code>SpecificRating</code> 
        /// </summary>
        /// <param name="ReviewID"></param>
        /// <param name="SpecificRating"></param>
        /// <returns></returns>
        public int NumberOfTimesGradesGiven(int ReviewID, int SpecificRating)
        {
            return _repo.GetMovieReviews().Where(mr => mr.Reviewer == ReviewID).Where(mr => mr.Grade == SpecificRating).Count();
        }

        public int NumberOfReviewsRecieved(int MovieID)
        {
            return _repo.GetMovieReviews().Where(mr => mr.Movie == MovieID).Count();
        }

        public double AverageGradeRecieved(int MovieID)
        {
            List<MovieReview> list = _repo.GetMovieReviews().Where(mr => mr.Movie == MovieID).ToList();
            double gradeSum = 0;
            foreach (var item in list)
            {
                gradeSum += item.Grade;
            }
            return gradeSum / list.Count();
        }

        public int NumberOfTimesGradesRecieved(int MovieID, int SpecificRating)
        {
            return _repo.GetMovieReviews().Where(mr => mr.Movie == MovieID).Where(mr => mr.Grade == SpecificRating).Count();
        }

        public int[] GetAllMovieWithHighestNumberOfTopRates()
        {
            var list = _repo.GetMovieReviews().Where(mr => mr.Grade == 5).GroupBy(mr => mr.Movie).OrderByDescending(g => g.Count()).AsEnumerable();
            int count = list.First().Count();
            
            var temp = list.Where(g => g.Count() == count).ToList();

            int[] results = new int[temp.Count()];
            int i = 0;
            foreach (var item in temp)
            {
                results[i] = item.First().Movie;
                i++;
            }
            return results;
        }

        public int[] GetAllReviewerWithMostReviews()
        {
            var list = _repo.GetMovieReviews().GroupBy(mr => mr.Reviewer).OrderByDescending(g => g.Count()).AsEnumerable();
            int count = list.First().Count();

            var temp = list.Where(g => g.Count() == count).ToList();

            int[] results = new int[temp.Count()];
            int i = 0;
            foreach (var item in temp)
            {
                results[i] = item.First().Reviewer;
                i++;
            }
            return results;
        }

        public int[] GetTop(int NumberOfEntries)
        {
            int[] top = new int[NumberOfEntries];
            List<Movie> movies = new List<Movie>();
            List<MovieReview> list = _repo.GetMovieReviews().OrderBy(mr => mr.Movie).ToList();
            
            int prevMovieID = 0;
            double gradeSum = 0;
            double numberOfGrades = 0;

            for (int i = 0; i < list.Count; i++)
            {

                if (i == 0)
                {
                    prevMovieID = list[i].Movie;
                }


                if (list[i].Movie == prevMovieID)
                {
                    gradeSum += list[i].Grade;
                    numberOfGrades++;
                }
                else
                {
                    movies.Add(new Movie() { MovieID = prevMovieID, AvgGrade = gradeSum / numberOfGrades });
                    gradeSum = list[i].Grade;
                    numberOfGrades = 1;
                }
                prevMovieID = list[i].Movie;
            }
            movies.Add(new Movie() { MovieID = prevMovieID, AvgGrade = gradeSum / numberOfGrades });

            movies.Sort((emp1, emp2) => emp2.AvgGrade.CompareTo(emp1.AvgGrade));

            for (int i = 0; i < NumberOfEntries; i++)
            {
                Console.WriteLine(movies[i].MovieID + ":" + movies[i].AvgGrade);
                top[i] = movies[i].MovieID;
            }
            return top;
            
        }

        public int[] GetReviewsSorted(int ReviewerID)
        {
            int[] reviewsSorted = _repo.GetMovieReviews().Where(mr => mr.Reviewer == ReviewerID).OrderByDescending(mr => mr.Grade).ThenByDescending(mr => mr.Date).Select(mr => mr.Movie).ToArray();
            for (int i = 0; i < reviewsSorted.Length; i++)
            {
                Console.WriteLine(reviewsSorted[i]);
            }
            return reviewsSorted;
        }

        public int[] GetReviewersSorted(int MovieID)
        {
            int[] reviewersSorted = _repo.GetMovieReviews().Where(mr => mr.Movie == MovieID).OrderByDescending(mr => mr.Grade).ThenByDescending(mr => mr.Date).Select(mr => mr.Reviewer).ToArray();
            for (int i = 0; i < reviewersSorted.Length; i++)
            {
                Console.WriteLine(reviewersSorted[i]);
            }
            return reviewersSorted;
        }



    }
}
