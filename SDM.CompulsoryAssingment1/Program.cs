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
            using (StreamReader file = File.OpenText(@"C:/Users/thor1/Desktop/ratings.json"))
            {
                IEnumerable<MovieReview> videogames = JsonConvert.DeserializeObject<IEnumerable<MovieReview>>(file.ReadToEnd());
                Console.WriteLine(videogames.Last());
                
            }
            Console.WriteLine("end");
        }
    }
}
