using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSZ.Models
{
    public class ShortageAlarmModel
    {
        public string objectID { get; set; }
        public string plant { get; set; }
        public string warehouse { get; set; }
        public string materialNumber { get; set; }
        public string materialDescription { get; set; }
        public string demand { get; set; }
        public string shortage { get; set; }
        public string measureUnit { get; set; }
    }
}