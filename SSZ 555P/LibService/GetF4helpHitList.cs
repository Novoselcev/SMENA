using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSZ.Hit_List;
namespace SSZ.LibService
{



    public class GetF4helpHitList
    {
       public YGUI_GET_F4HELP_HIT_LIST hitlist;
        String Langv = "";
        String tabnumber;
        string ILD;

        public GetF4helpHitList(string lang, string tn, string sysSap, string ild)
        {
            Langv = lang;
            tabnumber = tn;
            hitlist = new YGUI_GET_F4HELP_HIT_LIST(sysSap);
            ILD = ild;
        }

        //получения координатора GetCoord
        public DataTable GetCoord(PutNotification.YsfcOperQnoticeWs not)
        {
            YguiGetF4helpHitListWs zpr = new YguiGetF4helpHitListWs();
            zpr.IFuncMappedName = "YsfcPutNotificationWs";
        //    zpr.ILangu = Langv;
            zpr.IParamMappedName = "EQnoticeData";
            zpr.IFieldMappedName = "Coord";
            zpr.IMaxRows = "1000";
            zpr.IId = ILD;
            //zpr.ISearchContext = "Qmkat=" + not.Qmkat;
            YguiGetF4helpHitListWsResponse response = new YguiGetF4helpHitListWsResponse();
            response = hitlist.YguiGetF4helpHitListWs(zpr);
            DataTable tab = CreateTab(response, "Coord");
            return tab;
        }
        

        // получение группы кодов кодирования
        public DataTable GetQmgrp(PutNotification.YsfcOperQnoticeWs not)
        {
            YguiGetF4helpHitListWs zpr = new YguiGetF4helpHitListWs();
            zpr.IFuncMappedName = "YsfcPutNotificationWs";
        //    zpr.ILangu = Langv;
            zpr.IParamMappedName = "EQnoticeData";
            zpr.IId = ILD;
            zpr.IFieldMappedName = "Qmgrp";
            zpr.ISearchContext = "Qmkat=" + not.Qmkat;
            YguiGetF4helpHitListWsResponse response = new YguiGetF4helpHitListWsResponse();
            response = hitlist.YguiGetF4helpHitListWs(zpr);
            DataTable tab = CreateTab(response, "Qmgrp");
            return tab;
        }

        // получение  Группа кодов частей объекта
        public DataTable GetOtgrp(PutNotification.YsfcOperQnoticeWs not)
        {
            YguiGetF4helpHitListWs zpr = new YguiGetF4helpHitListWs();
            zpr.IFuncMappedName = "YsfcPutNotificationWs";
            zpr.IId = ILD;
            //    zpr.ILangu = Langv;
            zpr.IParamMappedName = "EQnoticeData";
            zpr.IFieldMappedName = "Otgrp";
            zpr.ISearchContext = "Otkat=" + not.Otkat;
            YguiGetF4helpHitListWsResponse response = new YguiGetF4helpHitListWsResponse();
            response = hitlist.YguiGetF4helpHitListWs(zpr);
            DataTable tab = CreateTab(response, "Otgrp");
            return tab;
        }

        // получение  Группа кодов проблем/дефектов
   /*     public DataTable GetFegrp(PutNotification.YsfcOperQnoticeWs not)
        {
            YguiGetF4helpHitListWs zpr = new YguiGetF4helpHitListWs();
            zpr.IFuncMappedName = "YsfcPutNotificationWs";
            zpr.IId = ILD;
            //      zpr.ILangu = Langv;
            zpr.IParamMappedName = "EQnoticeData";
            zpr.IFieldMappedName = "Fegrp";
            zpr.ISearchContext = "Fekat=" + not.Fekat;
            YguiGetF4helpHitListWsResponse response = new YguiGetF4helpHitListWsResponse();
            response = hitlist.YguiGetF4helpHitListWs(zpr);
            DataTable tab = CreateTab(response, "Fegrp");
            return tab;
        }*/



        // получение кодирования
        public DataTable GetQmcod1(PutNotification.YsfcOperQnoticeWs not)
        {
            YguiGetF4helpHitListWs zpr = new YguiGetF4helpHitListWs();
            zpr.IId = ILD;
            zpr.IFuncMappedName = "YsfcPutNotificationWs";
      //      zpr.ILangu = Langv;
            zpr.IParamMappedName = "EQnoticeData";
            zpr.IFieldMappedName = "Qmcod";
            zpr.ISearchContext = "Qmkat=" + not.Qmkat;
            YguiGetF4helpHitListWsResponse response = new YguiGetF4helpHitListWsResponse();
            response = hitlist.YguiGetF4helpHitListWs(zpr);
            DataTable tab = CreateTabTwo(response, "Qmcod");
            return tab;
        }

        // получение кодирования
        public DataTable GetOteil1(PutNotification.YsfcOperQnoticeWs not)
        {
            YguiGetF4helpHitListWs zpr = new YguiGetF4helpHitListWs();
            zpr.IFuncMappedName = "YsfcPutNotificationWs";
            zpr.IId = ILD;
            //   zpr.ILangu = Langv;
            zpr.IParamMappedName = "EQnoticeData";
            zpr.IFieldMappedName = "Oteil";
            zpr.ISearchContext = "Otkat=" + not.Otkat;
            YguiGetF4helpHitListWsResponse response = new YguiGetF4helpHitListWsResponse();
            response = hitlist.YguiGetF4helpHitListWs(zpr);
            DataTable tab = CreateTabTwo(response, "Otkat");
            return tab;
        }

        // Код проблемы/дефекта
     /*   public DataTable GetFecod1(PutNotification.YsfcOperQnoticeWs not)
        {
            YguiGetF4helpHitListWs zpr = new YguiGetF4helpHitListWs();
            zpr.IId = ILD;
            zpr.IFuncMappedName = "YsfcPutNotificationWs";
        //    zpr.ILangu = Langv;
            zpr.IParamMappedName = "EQnoticeData";
            zpr.IFieldMappedName = "Fecod";
            zpr.ISearchContext = "Fekat=" + not.Fekat;
            YguiGetF4helpHitListWsResponse response = new YguiGetF4helpHitListWsResponse();
            response = hitlist.YguiGetF4helpHitListWs(zpr);
            DataTable tab = CreateTabTwo(response, "Fecod");
            return tab;
        }*/


        // получение кодирования
        public DataTable GetQmcod(PutNotification.YsfcOperQnoticeWs not)
        {
            YguiGetF4helpHitListWs zpr = new YguiGetF4helpHitListWs();
            zpr.IId = ILD;
            zpr.IFuncMappedName = "YsfcPutNotificationWs";
      //      zpr.ILangu = Langv;
            zpr.IParamMappedName = "EQnoticeData";
            zpr.IFieldMappedName = "Qmcod";
            zpr.ISearchContext = "Qmkat=" + not.Qmkat + "; Qmgrp=" + not.Qmgrp;
            YguiGetF4helpHitListWsResponse response = new YguiGetF4helpHitListWsResponse();
            response = hitlist.YguiGetF4helpHitListWs(zpr);
            DataTable tab = CreateTab(response, "Qmcod");
            return tab;
        }

        // получение часть объекта
        public DataTable GetOteil(PutNotification.YsfcOperQnoticeWs not)
        {
            YguiGetF4helpHitListWs zpr = new YguiGetF4helpHitListWs();
            zpr.IFuncMappedName = "YsfcPutNotificationWs";
            zpr.IId = ILD;
            //     zpr.ILangu = Langv;
            zpr.IParamMappedName = "EQnoticeData";
            zpr.IFieldMappedName = "Oteil";
            zpr.ISearchContext = "Otkat=" + not.Otkat + "; Otgrp=" + not.Otgrp;
            YguiGetF4helpHitListWsResponse response = new YguiGetF4helpHitListWsResponse();
            response = hitlist.YguiGetF4helpHitListWs(zpr);
            DataTable tab = CreateTab(response, "Oteil");
            return tab;
        }


        //Код проблемы/дефекта
   /*     public DataTable GetFecod(PutNotification.YsfcOperQnoticeWs not)
        {
            YguiGetF4helpHitListWs zpr = new YguiGetF4helpHitListWs();
            zpr.IFuncMappedName = "YsfcPutNotificationWs";
       ///     zpr.ILangu = Langv;
            zpr.IParamMappedName = "EQnoticeData";
            zpr.IId = ILD;
            zpr.IFieldMappedName = "Fecod";
            zpr.ISearchContext = "Fekat=" + not.Fekat + "; Fegrp=" + not.Fegrp;
            YguiGetF4helpHitListWsResponse response = new YguiGetF4helpHitListWsResponse();
            response = hitlist.YguiGetF4helpHitListWs(zpr);
            DataTable tab = CreateTab(response, "Fecod");
            return tab;
        }*/

        private DataTable CreateTab(YguiGetF4helpHitListWsResponse res, string NameTab)
        {

            //Создаем таблицу
            DataTable tab = new DataTable(NameTab);
            DataRow NewRow;
            foreach (var z in res.EtHitListDescWs)
            {
                DataColumn colum = new DataColumn(z.Fieldname, Type.GetType("System.String"));
                colum.MaxLength = Convert.ToInt32(z.Outputlen);
                colum.Caption = z.ScrtextM;
                tab.Columns.Add(colum);
            }

            //Заполняем таблицу

            for (int i = 0; i < res.EtHitListWs.Length; i++)
            {
                string str = res.EtHitListWs[i];
                Int32 ch = 0;
                Int32 ch1 = 0;
                NewRow = tab.NewRow();
                foreach (var z in res.EtHitListDescWs)
                {
                    ch1 = ch;
                    ch += Convert.ToInt32(z.Outputlen);
                    if (ch <= str.Length)
                        NewRow[z.Fieldname] = str.Substring(ch1, Convert.ToInt32(z.Outputlen)).Trim();
                    else NewRow[z.Fieldname] = str.Substring(ch1).Trim();
                }
                tab.Rows.Add(NewRow);
            }
            NewRow = tab.NewRow();
            foreach (var z in res.EtHitListDescWs)
            {
                NewRow[z.Fieldname] = "";
            }
            tab.Rows.Add(NewRow);
            return tab;

        }

        private DataTable CreateTabTwo(YguiGetF4helpHitListWsResponse res, string NameTab)
        {
            DataTable tab = new DataTable(NameTab);

            foreach (var z in res.EtHitListDescWs)
            {
                DataColumn colum = new DataColumn(z.Fieldname, Type.GetType("System.String"));
                colum.MaxLength = Convert.ToInt32(z.Outputlen);
                colum.Caption = z.ScrtextM;
                tab.Columns.Add(colum);
            }
            return tab;
        }
    }
}

