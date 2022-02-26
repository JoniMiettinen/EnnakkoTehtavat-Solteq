using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnnakkoTehtävä2.Models
{
    public class EnergiankulutusData
    {
        public DateTime Timestamp { get; set; }
        public string ReportingGroup { get; set; }
        public string LocationName { get; set; }
        public double Value { get; set; }
        public string Unit { get; set; }
    }
}
