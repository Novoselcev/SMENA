using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSZ.PutNotification;
using SSZ.Models;

namespace SSZ.LibService
{
    public class SentMessage
    {
        String Langv = "";
        String tabnumber;
        String ILD;
        PutNotification.YSFC_PUT_NOTIFICATION notification;
        GetNotif.YSFC_GET_NOTIF_PRO_ITEMS GetNotific;

        public SentMessage(string lang, string tn, string systemSap,  string ild)
        {
            Langv = lang;
            ILD = ild;
            tabnumber = tn;
            notification = new PutNotification.YSFC_PUT_NOTIFICATION(systemSap);
            GetNotific = new GetNotif.YSFC_GET_NOTIF_PRO_ITEMS(systemSap);

        }

        public List<DefectOZM> GetQnotIT(string obj, string allzt)
        {
            GetNotif.YsfcGetNotifProItemsWs notif = new GetNotif.YsfcGetNotifProItemsWs();
            GetNotif.YsfcOperQnoticeWs record = new GetNotif.YsfcOperQnoticeWs();
            record.Asszl = allzt;
            record.Objnr = obj;
            notif.IId = ILD;
            notif.IQnoticeData = record;
            GetNotif.YsfcGetNotifProItemsWsResponse responce = new GetNotif.YsfcGetNotifProItemsWsResponse();
            responce = GetNotific.YsfcGetNotifProItemsWs(notif);
            Int32 i = 0;
            List<DefectOZM> spis = responce.EtQnoticeItems.Select(o => new DefectOZM {
                Anzfehler = o.Anzfehler,
                Bautl =o.Bautl,
                BautlTxt= o.BautlTxt,
                FlgMark =o.FlgMark,
                Fmgeig =o.Fmgeig,
                Fmgein =o.Fmgein,
                Posnr = o.Posnr,
                Prueflinr =o.Prueflinr,
                Stufe = Convert.ToInt32(o.Stufe),
                Vwegx = Convert.ToInt32(o.Vwegx),
                Wegxx = Convert.ToInt32(o.Wegxx),
                ID = i++
            }).ToList();
            Int32[] mas = new Int32[200];
            Int32 temp = 0;
            foreach (var s in spis)
            {
                if (s.Stufe>0)
                if (s.Stufe == temp)
                {
                    s.ID_parent = mas[s.Stufe-1];
                    mas[temp] = s.ID;
                }
                else if (s.Stufe > temp)
                {
                    s.ID_parent = mas[temp];
                    mas[s.Stufe] = s.ID;
                    temp = s.Stufe;
                   
                }
                else if (s.Stufe < temp) {
                    s.ID_parent = mas[s.Stufe-1];
                    temp = s.Stufe;
                        mas[s.Stufe] = s.ID;
                }
            }

            return spis;
        }

        public YsfcPutNotificationWsResponse ansverMessage(string obj, string allzt, string act, string step, PutNotification.YsfcOperQnoticeWs data, PutNotification.YsfcQnoteItemWs[] sp)
        {
            
            YsfcPutNotificationWs notif = new YsfcPutNotificationWs();
        //    notif.ILangu = Langv;
            notif.IAction = act;
            notif.IStep = step;
            YsfcOperQnoticeWs record = new YsfcOperQnoticeWs();
            record.Asszl = allzt;
            record.Objnr = obj;
            notif.IId =  ILD;
            //  record.Pernr = tabnumber;
            if (step == "2")
            {
                record.Text = data.Text;
                record.Qmart = data.Qmart;
                record.Oteil = data.Oteil;
                record.Otgrp = data.Otgrp;
                record.Otkat = data.Otkat;
                record.Qmcod = data.Qmcod;
                record.Qmgrp = data.Qmgrp;
                record.Qmkat = data.Qmkat;
                record.Qmnum = data.Qmnum;
                record.Uvorn = data.Uvorn;
                record.Vornr = data.Vornr;
                record.Coord = data.Coord;
                record.CoordFn = data.CoordFn;
                record.Rkmng = data.Rkmng;
                notif.ItQnoticeItems = sp;
///                record.PernrFn = data.PernrFn;

            }
            notif.IQnoticeData = record;
           // notif.ItQnoticeItems
            //запрос
            YsfcPutNotificationWsResponse responce = new YsfcPutNotificationWsResponse();
            responce = notification.YsfcPutNotificationWs(notif);
            return responce;
        }

        public YsfcQnoteItemWs[] QnoteItemWs(List<DefectOZM> QmDef, string check)
        {

            var mas = check.Split(',');
            YsfcQnoteItemWs[] spis = QmDef.Where(x => mas.Contains(x.ID.ToString())).Select(o => new YsfcQnoteItemWs {
                Aflst = o.Aflst,
                Anzfehler = o.Anzfehler,
                Bautl = o.Bautl,
                BautlTxt = o.BautlTxt,
                FlgMark = "X",
                Fmgeig = o.Fmgeig,
                Fmgein =o.Fmgein,
                Posnr = o.Posnr,
                Prueflinr = o.Prueflinr
                
            } ).AsEnumerable<YsfcQnoteItemWs>().ToArray<YsfcQnoteItemWs>();
            return spis;
        }
    }
}