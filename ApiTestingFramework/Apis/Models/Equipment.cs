using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestingFramework.Apis.Models
{

    public class Equipment
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public EquipmentResults[] results { get; set; }
    }

    public class EquipmentResults
    {
        public int id { get; set; }
        public string name { get; set; }
    }

}
