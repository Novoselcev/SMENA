using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSZ.Models
{
    public class NormDocumentModel
    {
        public string documentNumberDRAW { get; set; }          //DRAW-DOKNR            (* CHAR25)    Документ
        public string documentTypeDRAW { get; set; }            //DRAW-DOKTL            (* CHAR3)     Тип документа
        public string documentVersionDRAW { get; set; }         //DRAW-DOKVR            (* CHAR2)     Версия документа
        public string documentDescrZPRM_DOCSET { get; set; }    //ZPRM_DOCSET-DOCNAME   (- CHAR70)    Название документа
        public string changeNumberDRAW { get; set; }            //DRAW-AENNR            (- CHAR12)    Извещение
        public string outerChangeDRAW { get; set; }             //DRAW-AENNR            (- CHAR12)    Извещение внешн.
        public string changeDateAENR { get; set; }              //AENR-DATUV            (- DATS8)     Дата извещения
        public string imageICON { get; set; }                   //ICON-ID               (- CHAR4)     Иконка
        public string URL { get; set; }
        public string Type { get; set; }
        public string DocTXT { get; set; }
        public string TypeDoc { get; set; }
    }
}