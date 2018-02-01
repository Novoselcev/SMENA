using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSZ.SessionSap;
namespace SSZ.LibService
{
    public class SessionLib
    {
        public SessionSap.YGUI_HANDLE_PERNR_SESSION Session;
        String tabnumber;
        String Plant;
        String Langv = "";

        // конструктор класса
        public SessionLib(string lang, string tn, string sysSap, string plant)
        {
            Langv = lang;
            tabnumber = tn;
            Session = new YGUI_HANDLE_PERNR_SESSION(sysSap);
            Plant = plant;
        }


        public string OpenSession()
        {
            try
            {
                YguiHandlePernrSessionWs zpr = new YguiHandlePernrSessionWs();
                zpr.IAction = "OPEN";
                zpr.ILangu = Langv;
                zpr.IPernr = tabnumber;
                zpr.IPlant = Plant;
                zpr.IAttempts = "10";
                zpr.IAppl = "SFC";
                zpr.IMode = "M";
                YguiHandlePernrSessionWsResponse responce = new YguiHandlePernrSessionWsResponse();
                responce = Session.YguiHandlePernrSessionWs(zpr);
                return responce.EId;
            }
            catch (Exception ex) {
                return "";
            }

        }


        public YguiHandlePernrSessionWsResponse WorkSession(string Action, string ild)
        {
            YguiHandlePernrSessionWs zpr = new YguiHandlePernrSessionWs();
            zpr.IAction = Action;
            zpr.ILangu = Langv;
            zpr.IPernr = tabnumber;
            zpr.IPlant = Plant;
            zpr.IAttempts = "10";
            zpr.IAppl = "SFC";
            if (Action == "OPEN") zpr.IMode = "M";
            else zpr.IId = ild;
            YguiHandlePernrSessionWsResponse responce = new YguiHandlePernrSessionWsResponse();
            responce = Session.YguiHandlePernrSessionWs(zpr);
            return responce;
        }
    }
}