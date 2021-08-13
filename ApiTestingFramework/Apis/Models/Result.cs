using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestingFramework.Apis.Models
{
    class Result
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public object[] results { get; set; }
    }
}
