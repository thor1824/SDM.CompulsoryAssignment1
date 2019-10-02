using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDM.CompulsoryAssingment1
{
    public class MovieReview
    {
        public int Reviewer { get; set; }
        public int Movie { get; set; }
        public int Grade{ get; set; }
        public string Date { get; set; }

        public override string ToString()
        {
            return Reviewer + " " + Movie + " " + Grade + " " + Date;
        }
    }
}
