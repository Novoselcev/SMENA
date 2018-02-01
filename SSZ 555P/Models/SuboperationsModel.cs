using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSZ.Models
{
    public class SuboperationsModel
    {
        public string subOperationAFVC { get; set; }       //AFVC-VORNR   (- CHAR4)     Подоперация
        public string subOperNameAFVC { get; set; }        //AFVC-LTXA1   (- CHAR40)    Наименование
        public string workPlaceCRHD { get; set; }          //CRHD-ARBPL   (- CHAR8)     Рабочее место
        public string workPlaceDescrCRTX { get; set; }     //CRTX-KTEXT   (- CHAR40)    Описание рабочего места
    }
}