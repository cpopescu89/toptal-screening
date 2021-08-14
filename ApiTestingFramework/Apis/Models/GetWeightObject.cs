using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestingFramework.Apis.Models
{

    public class GetWeightObject
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public WeightResults[] results { get; set; }
    }

    public class WeightResults
    {
        public int id { get; set; }
        public string date { get; set; }
        public string weight { get; set; }
        public int user { get; set; }
    }

}

