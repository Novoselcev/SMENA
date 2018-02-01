using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSZ.PUT_OPERATION_TICKET;

namespace SSZ.LibService
{
    public class WorkStatus
    {



        YSFC_PUT_OPERATION_TICKET service ;
        String Langv = "";
        String tabnumber;
        String ILD;
        public WorkStatus(string lang, string tn, string systemSap, string ild)
        {
            Langv = lang;
            tabnumber = tn;
            ILD = ild;
            service = new YSFC_PUT_OPERATION_TICKET(systemSap);
        }
        //функция для запуска  и паузы выполнения заказа
        public YsfcPutOperationTicketWsResponse Start_operation(string obj, string allzt, string act, string step, PUT_OPERATION_TICKET.YsfcOperConfirmWs lastdate)
        {
            YsfcPutOperationTicketWs fun = new YsfcPutOperationTicketWs();
            fun.IId = ILD;
            if (act == "S1")// старт 
            {
              //  fun.ILangu = Langv; //язык
                fun.IStep = step; // шаг
                fun.IAction = "START"; // операция
            }
            else if (act == "P1")// пауза 
            {
              //  fun.ILangu = Langv; //язык
                fun.IStep = step; // шаг
                fun.IAction = "PAUSE"; // операция
            }
            else if (act == "CN1")// пауза 
            {
               // fun.ILangu = Langv; //язык
                fun.IStep = step; // шаг
                fun.IAction = "CONTINUE"; // операция
            }
            // передаем в структуру объект и счетчик
            YsfcOperConfirmWs record = new YsfcOperConfirmWs();
            record.Objnr = obj;
            record.Asszl = allzt;
           
          //  record.Pernr = lastdate.Pernr;
            if (step == "2")
            {
                record.Ldate = lastdate.Ldate;
                record.Ltime = lastdate.Ltime;
                if (act == "P1")
                {
                    record.Lmnga = "0";// lastdate.Lmnga;
                    record.Xmnga = "0";// lastdate.Xmnga;
                    record.Meinh = lastdate.Meinh;
                    record.Ile03 = lastdate.Ile03;
                    record.Ism03 = lastdate.Ism03;

                }

            }
            fun.IConfirmData = record;
            //запрос
            YsfcPutOperationTicketWsResponse responce = new YsfcPutOperationTicketWsResponse();
            responce = service.YsfcPutOperationTicketWs(fun);
            return responce;
        }

        //функция для получения проверки и начальных данных опрерации стоп и завершить
        public YsfcPutOperationTicketWsResponse StopeCompleteStepOne(string obj, string allzt, string act, string step)
        {
            YsfcPutOperationTicketWs fun = new YsfcPutOperationTicketWs();
            fun.IId = ILD;
            if (act == "ST1")// старт шаг 1
            {
           //     fun.ILangu = Langv; //язык
                fun.IStep = step; // шаг
                fun.IAction = "STOP"; // операция
            }
            else if (act == "C1")// пауза шаг 1
            {
           //     fun.ILangu = Langv; //язык
                fun.IStep = step; // шаг
                fun.IAction = "COMPLETE"; // операция
            }
            // передаем в структуру объект и счетчик
            YsfcOperConfirmWs record = new YsfcOperConfirmWs();
            record.Objnr = obj;
            record.Asszl = allzt;
         //   record.Pernr = tabnumber;
            fun.IConfirmData = record;
            //запрос
            YsfcPutOperationTicketWsResponse responce = new YsfcPutOperationTicketWsResponse();
            responce = service.YsfcPutOperationTicketWs(fun);
            return responce;
        }

        //функция для получения проверки и начальных данных опрерации стоп и завершить
        public YsfcReturnWs StopeCompleteStepTwo(YsfcOperConfirmWs DataOper ,string Operate, List<SSZ.GetOperDetail.YsfcOperDetailSenWs> SEN)
        {
            YsfcPutOperationTicketWs fun = new YsfcPutOperationTicketWs();
            fun.IId = ILD;
            //    fun.ILangu = Langv; //язык
            fun.IStep = "2"; // шаг
                fun.IAction = Operate; // операция
            fun.ItOperSenWs = SEN.Where(x=>x.Kzebu=="X").Select(o=> new YsfcOperDetailSenWs {
                Aufnr =o.Aufnr,
                Diaco = o.Diaco,
                DiacoTxt = o.DiacoTxt,
                Diaty = o.Diaty,
                Equnr =o.Equnr,
                Kzebu = o.Kzebu,
                Matnr = o.Matnr,
                Posnr = o.Posnr,
                Sernr = o.Sernr,
                Taser = o.Taser
            } ).AsEnumerable<YsfcOperDetailSenWs>().ToArray<YsfcOperDetailSenWs>(); ;
            // передаем в структуру объект и счетчик
            YsfcOperConfirmWs record = new YsfcOperConfirmWs();
            record.Objnr = DataOper.Objnr;
            record.Asszl = DataOper.Asszl;
            record.Ltxa1 = DataOper.Ltxa1;
            record.Xmnga = DataOper.Xmnga;
            record.Lmnga = DataOper.Lmnga;
            record.Ltime = DataOper.Ltime;
            record.Ldate = DataOper.Ldate;
      //      record.Pernr = tabnumber;
            fun.IConfirmData = record;
            //запрос
            YsfcPutOperationTicketWsResponse responce = new YsfcPutOperationTicketWsResponse();
            responce = service.YsfcPutOperationTicketWs(fun);
            return responce.EReturn;
        }

    }
}