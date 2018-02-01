using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSZ.Models
{
    public class SszModel
    {
        /* public string statusPodtvAFRU { get; set; }              //AFRU-STAT            (CHAR4)     Статус пдтв.
         public string objectZTXU_RESB_SAVE { get; set; }         //ZTXU_RESB_SAVE-ACCOU (CHAR22)    Объект
         public string objectNameAUFK { get; set; }               //AUFK-KTEXT           (CHAR40)    НаименованиеОбъекта
         public string operationAFVC { get; set; }                //AFVC-VORNR           (CHAR4)     Операция
         public string operationNameAFVC { get; set; }            //AFVC-LTXA1           (CHAR40)    НаименованиеОперации
         public string unitsCreatedXXXX { get; set; }             //!!!!!                ()          Выход продукции             ???????
         public string quantityPodtvAFRU { get; set; }            //AFRU-LMNGA           (QUAN13(3)) Кол-воПДТВ                  ???????
         public string operationMeasureUnitAFVV { get; set; }     //AFVV-MEINH           (CHAR3)     ЕИ операции
         public string beginDateRealAFVGD { get; set; }           //AFVGD-ISDD           (DATS8)     Факт начало (дата)                Х
         public string beginTimeRealAFVV { get; set; }            //AFVV-ISDZ            (TIMS6)     Факт начало (время)               Х
         public string endDateRealAFVGD { get; set; }             //AFVGD-IEDD           (DATS8)     Факт конец (дата)                 Х
         public string endTimeRealAFVV { get; set; }              //AFVV-IEDZ            (TIMS6)     Факт конец (время)                Х
         public string machineTimePlannedAFVGD { get; set; }      //AFVGD-VGW02   ??     (QUAN9(3))  Машинное время(план)
         public string workTimePlannedAFVGD { get; set; }         //AFVGD-VGW03          (QUAN9(3))  Рабочее время(план)
         public string workTimeRealCORUF { get; set; }            //CORUF-RUM03          (QUAN13(3)) Рабочее время(факт)
         public string timeMeasureUnitT006A { get; set; }         //T006A-MSEH3          (CHAR3)     Ед.изм. времени
         public string tabelNumberPA0000 { get; set; }            //PA0000-PERNR         (NUMC8)     Табельный номер
         public string workerSurnamePA0002 { get; set; }          //PA0002-NACHN         (CHAR40)    Фамилия сотрудника                Х
         public string workerNamePA0002 { get; set; }             //PA0002-VORNA         (CHAR40)    Имя сотрудника                    Х        
         public string latestBeginDateAFVV { get; set; }          //AFVV-SSAVD           (DATS8)     Самое позднее начало(дата)
         public string latestBeginTimeAFVV { get; set; }          //AFVV-SSAVZ           (TIMS6)     Самое позднее начало(время)
         public string latestEndDateAFVV { get; set; }            //AFVV-SSEDD           (DATS8)     Самое позднее окончание(дата)
         public string latestEndTimeAFVV { get; set; }            //AFVV-SSEDZ           (TIMS6)     Самое позднее окончание(время)
         public string maintenanceTimePlannedAFVGD { get; set; }  //AFVGD-VGW01          (QUAN9(3))  Время наладки(план)
         public string maintenanceTimeRealCORUF { get; set; }     //CORUF-RUM01          (QUAN13(3)) Время наладки(факт)
         public string machineTimeRealCORUF { get; set; }         //CORUF-RUM02    ??    (QUAN13(3)) Машинное время(факт)
         public string podtvOperationsQuanAFRUD { get; set; }     //AFRUD-LMNGA          (QUAN13(3)) Подтвержденное кол-во опер*/

        public string  ActsAlwd { get; set; }

        public Int32 id { get; set; }
        public string Asszl { get; set; }

        public string aufnr { get; set; }       // Номер заказа

        public string vornr { get; set; }       // Номер операции

        public string uvorn { get; set; }       // Подоперация

        public string plnaw { get; set; }       // Приложение текарты

        public string txtsp { get; set; }       // Код языка

        public string ltxa { get; set; }        // Наименование операции

        public string werks { get; set; }       // Завод

        public string arbpl { get; set; }       // Рабочее место

        public string arbplTxt { get; set; }    // Краткое название

        public string nprio { get; set; }       // Приоритет

        public string pernr { get; set; }       // Табельный номер

        public string pernrFn { get; set; }     // ФИО

        public string lmnga { get; set; }       // Выход продукции

        public string xmnga { get; set; }       // Брак
        public string matnr { get; set; }       // Материал
        public string matnrtxt { get; set; }    // Описание материала

        public string meinh { get; set; }       // ЕИ

        public string ssavd { get; set; }       // Самое позднее начало(дата)

        public string ssavz { get; set; }       // Самое позднее начало(время)

        public string ssedd { get; set; }       // Самое позднее окончание(дата)

        public string ssedz { get; set; }       // Самое позднее окончание(время)

        public string ssttxt { get; set; }      // Системный статус
        public string steus { get; set; }       // Статус

        public string usttxt { get; set; }      // Поле для просмотра пользовательского статуса

        public string plnbez { get; set; }      // Номер материала
        public string obj { get; set; }

        public string lsm03 { get; set; }  //время затраченное на обработку

        public string ile03 { get; set; } // Единица измерения времени

        public string Mgvrg { get; set; } // плановое количество

        public string StartDay{ get; set; } // Единица измерения времени

        public string EndDay { get; set; } // плановое количество

        public string Acti3 { get; set; } // Запланированное рабочее время

        public string Unit3 { get; set; } // Един. запланиров рабочего времени 

        public string Diaco { get; set; } // Код диагностики

        public string DiacoTxt { get; set; } //  Описание проблемы 

        public string Qmnum { get; set; }  //Наличие сообщения по качеству
        public string Diaty { get; set; }  // тип диагностического  сообщения
        public string Maknz { get; set; } // наличие ответа

    }
}