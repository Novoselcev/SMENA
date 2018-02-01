using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSZ.Models
{
    public class WorkPlaceInputModel
    {
        public string workPlaceCRHD { get; set; }          //CRHD-ARBPL   (- CHAR8)     Рабочее место
        public string workPlaceDescrCRTX { get; set; }     //CRTX-KTEXT   (- CHAR40)    Описание рабочего места
    }
}