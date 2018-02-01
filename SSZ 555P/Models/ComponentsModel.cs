using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSZ.Models
{
    public class ComponentsModel
    {
        public string osnZapMaterRESB { get; set; }        //RESB-MATNR   (- CHAR18)       ОЗМ
        public string materialDescrMAKT { get; set; }      //MAKT-MAKTX   (- CHAR40)       Наименование
        public string plannedQuantitySTPO { get; set; }    //STPO-MENGE   (- QUAN13(3))    Кол-во(план)
        public string measureUnitT006A { get; set; }       //T006A-MSEH3  (- CHAR3)        ЕИ
        public string Xfehl { get; set; } // дефицитные позиции
        public string Enmng { get; set; } // отпущенное  количество
        public string Vmeng { get; set; } // потвержд  количество
    }
}