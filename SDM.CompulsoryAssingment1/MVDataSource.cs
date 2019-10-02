using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SDM.CompulsoryAssingment1
{
    public class MVDataSource
    {
        private static IEnumerable<MovieReview> MovieReviews { get; set; }

        public static void InitData()
        {
            using (StreamReader file = File.OpenText(@"C:/Users/thor1/Desktop/ratings.json"))
            {
                MovieReviews = JsonConvert.DeserializeObject<IEnumerable<MovieReview>>(file.ReadToEnd());
            }
        }

        public static IEnumerable<MovieReview> GetMovieReviews()
        {
            if (MovieReviews == null)
            {
                InitData();
            }
            return MovieReviews;
        }
    }
}
