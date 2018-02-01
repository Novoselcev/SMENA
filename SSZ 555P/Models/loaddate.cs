using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections;
using SSZ.GetOperDetail;


namespace SSZ.Models
{
    public class LoadData
    {

        public List<YsfcOperDetailPrtWs> VPS;
        public List<YsfcOperDetailSenWs> SEN;
        public List<YsfcOperDetailDocWs> NorDoc;
        public List<YsfcOperDetailCmpWs> MatIput;
        public List<YsfcOperDetailSboWs> SubOper;
        public YsfcOperListWs OperDet;
        public List<YsfcOperFormsWs> TehDoc;
        public string ILD;

        public LoadData(string ild)
        {
            ILD = ild;
        }

        static public void loadSZZ()
        {
            GetOperService.YSFC_GET_OPERATIONS_LIST serv = new GetOperService.YSFC_GET_OPERATIONS_LIST();
            GetOperService.YsfcGetOperationsListWs oper = new GetOperService.YsfcGetOperationsListWs();
           // oper.IPernr = "766";
            GetOperService.YsfcGetOperationsListWsResponse response1 = new GetOperService.YsfcGetOperationsListWsResponse();
            response1 = serv.YsfcGetOperationsListWs(oper);
        }

        public List<YsfcOperListWs> OperLoad(string tabNumber, string Langv, string error, string systemSap)
        {
            // подключаемся к вебсервису
            GetOperService.YSFC_GET_OPERATIONS_LIST serv = new GetOperService.YSFC_GET_OPERATIONS_LIST(systemSap);
            GetOperService.YsfcGetOperationsListWs oper = new GetOperService.YsfcGetOperationsListWs();
            // задает входной параметр, табельный номер
            //  oper.IPernr = tabNumber.Trim();
            //  oper.ILangu = Langv.Trim();
            //  oper.IPlant = "1101";
            oper.IId = ILD;
            oper.IDiag = error;
            // получаем ответ по заданому параметру
            GetOperService.YsfcGetOperationsListWsResponse response1 = new GetOperService.YsfcGetOperationsListWsResponse();
            // создаем выходной список
            List<YsfcOperListWs> oprList = new List<YsfcOperListWs>();
          try
            {


                response1 = serv.YsfcGetOperationsListWs(oper);
            // формируем выходной список

           // Random rd = new Random();

            oprList = response1.EtOperListWs.Select(o => new YsfcOperListWs
            {
                Arbpl = o.Arbpl,
                ArbplTxt = o.ArbplTxt,
                Aufnr = o.Aufnr,
                Lmnga = o.Lmnga,
                Ltxa = o.Ltxa,
                Meinh = o.Meinh,
                Nprio = o.Nprio,
                Pernr = o.Pernr,
                PernrFn = o.PernrFn,
                Plnaw = o.Plnaw,
                Steus = o.Steus,// Plnbez
                Ssavd = o.Ssavd,
                Ssavz = o.Ssavz,
                Ssedd = o.Ssedd,
                Ssedz = o.Ssedz,
                Usttxt = GetStatus(o.Usttxt),
                Ssttxt = o.Ssttxt,
                Matnr = o.Matnr, //txtsp
                Uvorn = o.Uvorn,
                Vornr = o.Vornr,
                Werks = o.Werks,
                Asszl = o.Asszl,
                Xmnga = o.Xmnga,
                Objnr = o.Objnr,//obj
                Ism03 = o.Ism03.Trim(),
                Ile03 = o.Ile03.Trim(),
                Mgvrg = o.Mgvrg,
                Sernp = o.Sernp,
                Qmclo = o.Qmclo,
                MatnrTxt = o.MatnrTxt,
                Acti3 = o.Acti3,
                Unit3 = o.Unit3,
                Diaco = o.Diaco,
                DiacoTxt = o.DiacoTxt,
                Qmnum = o.Qmnum,
                Diaty = o.Diaty,
                ActsAlwd1 = activBut(o.ActsAlwd),
                Maknz = o.Maknz,
                Iedd = o.Iedd,
                Anzsn = o.Anzsn,
                Iedz = o.Iedz,
                Isdd = o.Isdd,
                Isdz = o.Isdz
                
            }).ToList<YsfcOperListWs>();
                  }
                catch (Exception ex)
                 {

                 }
            return oprList;
        }

        //даступные кнопки 
        public string activBut(string[] but)
        {
            string rezult = "0";
            if (but != null) { 
            if (but.Count(x => x == "START") > 0)
            {
                rezult = "0";
            }
            else if (but.Count(x => x == "STOP") > 0)
            {
                rezult = "1";
            }
            else if (but.Count(x => x == "CONTINUE") > 0)
            {
                rezult = "2";
            }
            else if (but.Count(x => x == "COMPLETE") > 0)
                {
                    rezult = "3";
                }
                else rezult = "5"; }
            return rezult;
        }


        // формирование статуса
        public string GetStatus(string status)
        {

            var mas = status.Split(' '); // разбиваем статусы
                                         // берем последний элемент
            Int32 index = mas.Length;
            string st = "";
            if (index != 0)
            {
               string zap = mas[index - 1].Trim();
                switch (zap)
                {
                    case "НАЗН":
                        st = "0";
                        break;
                    case "РАБО":
                        st = "1";
                        break;
                    case "ОСТН":
                        st = "3";
                        break;
                    case "ЗВРШ":
                        st = "4";
                        break;
                    default:
                        st = zap;
                        break;
                }

            }

            return st;
        }


        // получение деталей впс компоненты подоперации материалы
        public void GetOperDetail(string obj, string Allzt, string type, string connectSap)
        {
            GetOperDetail.YSFC_GET_OPERATION_DETAIL  serv = new GetOperDetail.YSFC_GET_OPERATION_DETAIL(connectSap);
            GetOperDetail.YsfcGetOperationDetailWs detail = new GetOperDetail.YsfcGetOperationDetailWs();
            GetOperDetail.YsfcOperKeyWs key = new SSZ.GetOperDetail.YsfcOperKeyWs();
            GetOperDetail.YsfcOperAskForWs ask = new SSZ.GetOperDetail.YsfcOperAskForWs();
            key.Objnr = obj;
            key.Asszl = Allzt;
            detail.IId = ILD;
            detail.IOperKeyWs = key;
          //  detail.ILangu = "RU";
            GetOperDetail.YsfcGetOperationDetailWsResponse responce = new GetOperDetail.YsfcGetOperationDetailWsResponse();

            // ФЛАГ ДЛЯ ПОЛУЧЕНИЯ ВЕ ДАННЫХ
            if (type == "all")
            {
                ask.Cmp = "X";
                ask.Sbo = "X";
                ask.Doc = "X";
                ask.Prt = "X";
                ask.Sen = "X";
               // ask.Acts = "X";
                ask.Diag = "X";
                detail.IOperAskForWs = ask;
                responce = serv.YsfcGetOperationDetailWs(detail);
                getSbo(responce);
                getCmp(responce);
                getDoc(responce);
                getVPS(responce);
                getOper(responce);
                getSen(responce);
                getTehDoc(responce);
            } // получение подопераций
           else if (type == "all_not_sen")
            {
                ask.Cmp = "X";
                ask.Sbo = "X";
                ask.Doc = "X";
                ask.Prt = "X";
                // ask.Acts = "X";
                ask.Diag = "X";
                detail.IOperAskForWs = ask;
                responce = serv.YsfcGetOperationDetailWs(detail);
                getSbo(responce);
                getCmp(responce);
                getDoc(responce);
                getVPS(responce);
                getOper(responce);
            } // получение подопераций
            else if (type == "Sbo")
            {
                ask.Sbo = "X";
                detail.IOperAskForWs = ask;
                responce = serv.YsfcGetOperationDetailWs(detail);
                getSbo(responce);
            } // компоненты 
            else if (type == "Cmp")
            {
                ask.Cmp = "X";
                ask.Diag = "X"; // проверка на ошибки
                detail.IOperAskForWs = ask;
                responce = serv.YsfcGetOperationDetailWs(detail);
                getCmp(responce);
            } // документы
            else if (type == "Doc")
            {
                ask.Doc = "X";
                detail.IOperAskForWs = ask;
                responce = serv.YsfcGetOperationDetailWs(detail);
                getDoc(responce);
            } //впс
            else if (type == "Prt")
            {
                ask.Prt = "X";
                detail.IOperAskForWs = ask;
                responce = serv.YsfcGetOperationDetailWs(detail);
                getVPS(responce);
            }
            else if (type == "Sen")
            {
                ask.Sen = "X";
                detail.IOperAskForWs = ask;
                responce = serv.YsfcGetOperationDetailWs(detail);
                getSen(responce);
            }
            else if (type == "Oper")
            {
                ask.Oper = "X";
                ask.Diag = "X"; // проверка на ошибки
                detail.IOperAskForWs = ask;
                responce = serv.YsfcGetOperationDetailWs(detail);
                getOper(responce);
            }
        }


        

        void getSbo(GetOperDetail.YsfcGetOperationDetailWsResponse responce)
        {
            SubOper = responce.EtOperSboWs.Select(o => new YsfcOperDetailSboWs
            {
                Arbpl = o.Arbpl,
                ArbplTxt = o.ArbplTxt,
                Asszl = o.Asszl,
                Aufnr = o.Aufnr,
                Ltxa = o.Ltxa,
                Objnr = o.Objnr,
                Ssttxt = o.Ssttxt,
                Usttxt = o.Usttxt,
                Uvorn = o.Uvorn,
                Vornr = o.Vornr,
                Werks = o.Werks

               /* subOperationAFVC = o.Uvorn,
                subOperNameAFVC = o.Ltxa*/
            }).ToList();
        }

        void getDoc(GetOperDetail.YsfcGetOperationDetailWsResponse responce)
        {
            NorDoc = responce.EtOperDocWs.Select(o => o).ToList<YsfcOperDetailDocWs>();
           /* NorDoc = responce.EtOperDocWs.Select(o => new YsfcOperDetailDocWs
            {
              Aedat =o.
                /* documentNumberDRAW = o.Doknr,
                documentTypeDRAW = o.Doktl,
                documentVersionDRAW = o.Dokvr,
                changeNumberDRAW = o.Aennr,
                outerChangeDRAW = o.Dokar,
                Type = o.Typ,
                URL = o.Url,
                DocTXT = o.Dktxt,
                TypeDoc = o.DoktlTxt
            }).ToList();*/
        }

        void getCmp(GetOperDetail.YsfcGetOperationDetailWsResponse responce)
        {
            MatIput = responce.EtOperCmpWs.Select(o => o).ToList<YsfcOperDetailCmpWs>();
            
            /*new ComponentsModel
            {
                osnZapMaterRESB = o.Matnr,
                materialDescrMAKT = o.MatnrTxt,
                plannedQuantitySTPO = o.Bdmng,
                measureUnitT006A = o.Meins,
                Xfehl= o.Xfehl,
                Enmng =o.Enmng,
                Vmeng = o.Vmeng
            }).ToList();*/
        }

        void getVPS(GetOperDetail.YsfcGetOperationDetailWsResponse responce)
        {
            VPS = responce.EtOperPrtWs.Select(o => o).ToList<YsfcOperDetailPrtWs>();
            /*new VPSModel
            {
                osnZapMaterRESB = o.Matnr,
                materialDescrMAKT = o.MatnrTxt,
                plannedQuantitySTPO = o.Steuf
            }).ToList();*/
        }

        void getSen(GetOperDetail.YsfcGetOperationDetailWsResponse responce)
        {
             SEN = responce.EtOperSenWs.Select(o => o).ToList<YsfcOperDetailSenWs>();
            
        }

        void getTehDoc(GetOperDetail.YsfcGetOperationDetailWsResponse responce)
        {
            TehDoc = responce.EtFormsUrlWs.Select(o => o).ToList<YsfcOperFormsWs>();

        }

        void getOper(GetOperDetail.YsfcGetOperationDetailWsResponse responce)
        {
            OperDet = new YsfcOperListWs();
            OperDet.Arbpl = responce.EOperListWs.Arbpl;
            OperDet.ArbplTxt = responce.EOperListWs.ArbplTxt;
            OperDet.Asszl = responce.EOperListWs.Asszl;
            OperDet.Aufnr = responce.EOperListWs.Aufnr;
            OperDet.Lmnga = responce.EOperListWs.Lmnga;
            OperDet.Ltxa = responce.EOperListWs.Ltxa;
            OperDet.Matnr = responce.EOperListWs.Matnr;
            OperDet.MatnrTxt = responce.EOperListWs.MatnrTxt;
            OperDet.Meinh = responce.EOperListWs.Meinh;
            OperDet.Nprio = responce.EOperListWs.Nprio;            
            OperDet.Objnr = responce.EOperListWs.Objnr;
            OperDet.Pernr = responce.EOperListWs.Pernr;
            OperDet.PernrFn = responce.EOperListWs.PernrFn;
            OperDet.Plnaw = responce.EOperListWs.Plnaw;
            OperDet.Ssavd = responce.EOperListWs.Ssavd + " " + responce.EOperListWs.Ssavz;
            OperDet.Ssavz = responce.EOperListWs.Ssavz;
            OperDet.Ssedd = responce.EOperListWs.Ssedd+" "+ responce.EOperListWs.Ssedz;
            OperDet.Ssedz = responce.EOperListWs.Ssedz;
            OperDet.Ssttxt = responce.EOperListWs.Ssttxt;
            OperDet.Steus = responce.EOperListWs.Steus;
            OperDet.Usttxt = responce.EOperListWs.Usttxt;
            OperDet.Uvorn = responce.EOperListWs.Uvorn;
            OperDet.Vornr = responce.EOperListWs.Vornr;
            OperDet.Werks = responce.EOperListWs.Werks;
            OperDet.Xmnga = responce.EOperListWs.Xmnga;
            OperDet.Ism03 = responce.EOperListWs.Ism03.Trim();
            OperDet.Ile03 = responce.EOperListWs.Ile03.Trim();
            OperDet.Mgvrg = responce.EOperListWs.Mgvrg;
            OperDet.Unit3 = responce.EOperListWs.Unit3;
            OperDet.Acti3= responce.EOperListWs.Acti3;
            OperDet.Diaco = responce.EOperListWs.Diaco;
            OperDet.DiacoTxt = responce.EOperListWs.DiacoTxt;
            OperDet.Qmnum = responce.EOperListWs.Qmnum;
            OperDet.ActsAlwd1 = activBut(responce.EOperListWs.ActsAlwd);
            OperDet.Maknz = responce.EOperListWs.Maknz;
            OperDet.Qmclo = responce.EOperListWs.Qmclo;
            OperDet.Sernp = responce.EOperListWs.Sernp;

            OperDet.Isdz = responce.EOperListWs.Isdz;
            OperDet.Isdd = responce.EOperListWs.Isdd;
            OperDet.Iedd = responce.EOperListWs.Iedd;
            OperDet.Iedz = responce.EOperListWs.Iedz;
        }
    }
    }