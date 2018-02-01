using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using SSZ.Models;
using SSZ.LibService;
using System.Data;
using SSZ.GetOperDetail;
using Microsoft.Owin.Security;
using System.ComponentModel.DataAnnotations;
using Microsoft.Owin.Host.SystemWeb;
using System.Web.Security;
using System.DirectoryServices.AccountManagement;

namespace SSZ.Controllers
{
    public class DialogController : Controller
    {
        // GET: Dialog
        public ActionResult TotalList()
        {
            TotalListClass _tl = new TotalListClass(Session["ILD"].ToString(), (String)Session["SystemSap"]);
            string date = DateTime.Now.Month < 10 ? "0" + DateTime.Now.Month.ToString() + "." + DateTime.Now.Year.ToString() : DateTime.Now.Month.ToString() + "." + DateTime.Now.Year.ToString();
            List <SSZ.GetStatistics.YafvcStatis2Ws> spis = _tl.GetStat(date);
            List<SetTab> sp;
            ViewGrid grid = new ViewGrid((String)Session["SystemSap"], Session["ILD"].ToString());
            List<SetTab> spis1 = grid.ReadParameTab("YsfcGetStatisticsWs", "EtStatDataWs", "7");
            Session["PrimeGrid"] = spis1;


            if (Session["PrimeGrid"] != null)
            {
                sp = (List<SetTab>)Session["PrimeGrid"];
            }
            else sp = new List<SetTab>();





            ViewBag.PrimeGrid = sp;
            Session["spTotallist"] = spis;
           Session["URLlist"] = _tl.URL;
            return PartialView("~/Views/Dialog/_GridViewPartialTotalList.cshtml", spis);
        }

        public ActionResult TotalListMenu()
        {
            
            ViewBag.UrlList = (String)Session["URLlist"];
            return View();
        }

        [HttpPost]
        public JsonResult GetTotalList(string DateR)
        {
            TotalListClass _tl = new TotalListClass(Session["ILD"].ToString(), (String)Session["SystemSap"]);
            List<SSZ.GetStatistics.YafvcStatis2Ws> spis = _tl.GetStat(DateR);
            Session["URLlist"] = _tl.URL;
            Session["spTotallist"] = spis;
            return Json(new { isAdded = true, UrlAdress = _tl.URL });

        }

       
         [SessionExpire]
        public ActionResult GridViewPartialView()
        {
            List<SSZ.GetStatistics.YafvcStatis2Ws> spis = new List<GetStatistics.YafvcStatis2Ws>();
            spis = (List<GetStatistics.YafvcStatis2Ws>)Session["spTotallist"];
            List<SetTab> sp;
            if (Session["PrimeGrid"] != null)
            {
                sp = (List<SetTab>)Session["PrimeGrid"];
            }
            else sp = new List<SetTab>();
            ViewBag.PrimeGrid = sp;
            return PartialView("~/Views/Dialog/_GridViewPartialTotalList.cshtml", spis);
        }



    }
}