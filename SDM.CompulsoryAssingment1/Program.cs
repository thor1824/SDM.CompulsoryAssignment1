using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SDM.CompulsoryAssingment1
{
    class Program
    {
        static void Main(string[] args)
        {

            // deserialize JSON directly from a file
            MovieReviewService ms = new MovieReviewService();
            ms.GetAllReviewerWithMostReviews();
        }
    }
}
