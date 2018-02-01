using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSZ.Models
{
    public class MaterInputModel
    {
        public string osnZapMaterRESB { get; set; }        //RESB-MATNR   (- CHAR18)       ОЗМ
        public string materialDescrMAKT { get; set; }      //MAKT-MAKTX   (- CHAR40)       Наименование
    }
}