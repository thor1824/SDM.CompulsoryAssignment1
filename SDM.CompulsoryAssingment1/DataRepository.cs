using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SDM.CompulsoryAssingment1
{
    public class MovieReviewRepository

    {
        private IEnumerable<MovieReview> MovieReviews { get; set; }

        private string FilePath { get; set; }

        public MovieReviewRepository(string filePath)
        {
            FilePath = filePath;
        }

        private void InitData()
        {
            using (StreamReader file = File.OpenText(FilePath))
            {
                MovieReviews = JsonConvert.DeserializeObject<IEnumerable<MovieReview>>(file.ReadToEnd());
            }
        }

        public IEnumerable<MovieReview> GetMovieReviews(string fileName)
        {
            if (MovieReviews == null)
            {
                InitData();
            }
            return MovieReviews;
        }
    }
}
