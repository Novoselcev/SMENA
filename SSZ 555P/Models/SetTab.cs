using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SSZ.Models
{
    public class SetTab
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string DescripS { get; set; }
        public bool visibleCol { get; set; }
        public string position { get; set; }
        [Range(0, 200, ErrorMessage = "Значение не корректно")]
        public Int32 width { get; set; }
        public Int32 fontSize { get; set; }
    }
}