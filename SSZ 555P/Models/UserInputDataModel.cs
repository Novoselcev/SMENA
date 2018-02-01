using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSZ.Models
{
    public class UserInputDataModel
    {
        public string prodOrderAFKO { get; set; }          //AFKO-AUFNR   (* CHAR12)   Производственный заказ       (Номер заказа)
        public string prodOrderAUFK { get; set; }          //AUFK-AUFNR   (* CHAR12)   Сетевой график               (Номер заказа)
        public string workPlaceCRHD { get; set; }          //CRHD-ARBPL   (- CHAR8)    Рабочее место                (Рабочее место)
        public string plantAUFK { get; set; }              //AUFK-WERKS   (- CHAR4)    Завод                        (Завод)
        public string dateStartPlannedAFVV { get; set; }   //AFVV-FSAVD   (- DATS8)    Запланированный срок начала
        public string dateEndPlannedAFVV { get; set; }     //AFVV-FSEDD   (- DATS8)    Запланированный срок конца
        public string dateStartRealAFVV { get; set; }      //AFVV-ISAVD   (- DATS8)    Фактический срок начала
        public string dateEndRealAFVV { get; set; }        //AFVV-IEAVD   (- DATS8)    Фактический срок конца
        public string dateStartBasisAFVV { get; set; }     //AFVV-NTANF   (- DATS8)    Базисный срок начала
        public string materialNumberAFKO { get; set; }     //AFKO-PLNBEZ  (- CHAR18)   Материал                      (Номер материала)
        public string tabelNumberPA0000 { get; set; }      //PA0000-PERNR (* NUMC8)    Табельный номер               (Табельный номер)
    }
}