using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreReactLab.Models
{
    public class Order
    {
        public int id { get; set; }
        public int adminId { get; set; }
        public Admin admin { get; set; }
        public int workerId { get; set; }
        public Worker worker { get; set; }
        public int typeWorkId { get; set; }
        public TypeWork typeWork { get; set; }
        public string FIO { get; set; }
        public string VinNum { get; set; }
        public string CarNum { get; set; }
        public string CarName { get; set; }
        public string TelNum { get; set; }
        public DateTime DateTime { get; set; }
    }
}
