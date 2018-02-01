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

    public class HomeController : Controller
    {

        //List<SszModel> MainOper = new List<SszModel>();
        [AllowAnonymous]
        public ActionResult Start()
        {
            Logout model = new Logout();
            List<systemsap> spis = new List<systemsap>();
            List<ListPlant> pl = new List<ListPlant>();
            pl.Add(new ListPlant { Name = "1101", Text = "1101 - Махачкала" });
            pl.Add(new ListPlant { Name = "1102", Text = "1102 - Москва" });
            pl.Add(new ListPlant { Name = "1103", Text = "1103 - Ниж. Новгород" });
            pl.Add(new ListPlant { Name = "1104", Text = "1104 - Челябинск" });
            pl.Add(new ListPlant { Name = "1105", Text = "1105 - Санкт-Петербург" });
            pl.Add(new ListPlant { Name = "1106", Text = "1106 - Калуга" });
            SelectList pl1 = new SelectList(pl, "Name", "Text");
            ViewBag.Plant = pl1;
            Session["Vhod"] = true;
            spis.Add(new systemsap { Name = "AZP", Text = "AZP - продуктивная система" });
            spis.Add(new systemsap { Name = "AZQ", Text = "AZQ - тестовая система" });
            spis.Add(new systemsap { Name = "AZD", Text = "AZD - Developer system" });
            spis.Add(new systemsap { Name = "AZD100", Text = "AZD100 - Developer system" });
            SelectList sys = new SelectList(spis, "Name", "Text");
            ViewBag.SysSap = sys;
            ViewBag.SystemM = false;
            model.Lang = "RU";
            if (HttpContext.Request.Cookies["Smena"] != null)
            {
                string coc = HttpContext.Request.Cookies["Smena"].Value.ToString();
                if (coc == "AZP" || coc == "AZQ" || coc == "AZD" || coc == "AZD100")
                    model.SystemSap = coc;

            }

            if (HttpContext.Request.Cookies["SmenaPL"] != null)
            {
                string coc = HttpContext.Request.Cookies["SmenaPL"].Value.ToString();
                if (coc == "1101" || coc == "1102" || coc == "1103" || coc == "1104" || coc == "1105" || coc == "1106")
                    model.Plant = coc;

            }
            // else { model.Plant = "1101"; }

            // model.TabNomer = "766";
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]

        public ActionResult Start(Logout model, string returnUrl)
        {
            Session["SystemSap"] = model.SystemSap;
            Session["Plant"] = model.Plant;
            
            ViewBag.SystemM = false;
            Boolean flag = false;
            FormsAuthentication.SignOut();
        //    if ((bool)Session["Vhod"]==true) {
              //  Session["Vhod"] = false;
                if (!Membership.Providers["SapfirProvider"].ValidateUser(model.Username, model.Password))
            {

                ///domainProvider = Membership.Providers["AzimuthProvider"];
                if (Membership.Providers["AzimuthProvider"].ValidateUser(model.Username, model.Password)) flag = true;
                else ModelState.AddModelError("Username", "Неверно введен логин или пароль");
            }
            else { flag = true; }
            if (flag) {
                FormsAuthentication.SetAuthCookie(model.Username, true);
                var user = Membership.GetUser(model.Username);
                var context = new PrincipalContext(ContextType.Domain);
                var principal = UserPrincipal.FindByIdentity(context, model.Username);
                var EmployeerId = principal.EmployeeId;
                if (model.Username.ToLower().Trim() == "novoselcev.a" || model.Username.ToLower().Trim() == "hasmet" || model.Username.ToLower().Trim() == "mralbert")
                {
                    if (model.TabNomer == null || model.TabNomer.Trim() == "")
                    {
                        model.TabNomer = EmployeerId;
                    }
                }
                else {
                    model.TabNomer = EmployeerId;
                }

                if (model.TabNomer == null || model.TabNomer.Trim() == "")
                {
                    ModelState.AddModelError("TabNomer", "Табельный номер не определен");
                    FormsAuthentication.SignOut();
                }

                SessionLib sess = new SessionLib(model.Lang, model.TabNomer, (String)Session["SystemSap"], (string)Session["Plant"]);
                string sessiont = sess.OpenSession();
                if (sessiont == "")
                {
                    ModelState.AddModelError("TabNomer", "Табельный номер не существует");
                    FormsAuthentication.SignOut();
                } else {

                    Session["ILD"] = sessiont;
                }

            }

                /*  else
                  {
                      Authorization auth = new Authorization();
                      if (!auth.CheckTabNuber(model.TabNomer, model.Lang, (String)Session["SystemSap"]))
                      {
                          ModelState.AddModelError("TabNomer", "По табельному №" + model.TabNomer + " отсутствуют задания");
                      }
                  }*/
                if (ModelState.IsValid)
                {
                    Session["tabnumber"] = model.TabNomer;
                    Session["lang"] = model.Lang;
                    Session["Username"] = model.Username;
                    Session["SubOper"] = null;
                    Session["NorDoc"] = null;
                    Session["MatIput"] = null;
                    Session["VPS"] = null;
                    Session["TabOper"] = null;
                    Session["Obj"] = null;
                    Session["Asszl"] = null;
                    Session["TehDoc"] = null;

                if (HttpContext.Request.Cookies["Smena"] == null)
                    {
                        HttpContext.Response.Cookies["Smena"].Value = model.SystemSap;
                        HttpContext.Response.Cookies["Smena"].Expires = DateTime.Now.AddMonths(2);


                    }
                    else
                    {
                        HttpContext.Response.Cookies["Smena"].Value = model.SystemSap;
                    }


                    if (HttpContext.Request.Cookies["SmenaPL"] == null)
                    {
                        HttpContext.Response.Cookies["SmenaPL"].Value = model.Plant;
                        HttpContext.Response.Cookies["SmenaPL"].Expires = DateTime.Now.AddMonths(2);


                    }
                    else
                    {
                        HttpContext.Response.Cookies["SmenaPL"].Value = model.Plant;
                    }
   //                 Session["Vhod"] = true;
        //        }

                //запуск сессии

                return RedirectToAction("Index");
            }

            List<systemsap> spis = new List<systemsap>();
            spis.Add(new systemsap { Name = "AZP", Text = "AZP - продуктивная система" });
            spis.Add(new systemsap { Name = "AZQ", Text = "AZQ - тестовая система" });
            spis.Add(new systemsap { Name = "AZD", Text = "AZD - Developer system" });
            spis.Add(new systemsap { Name = "AZD100", Text = "AZD100 - Developer system" });
            SelectList sys = new SelectList(spis, "Name", "Text");
            ViewBag.SysSap = sys;
            List<ListPlant> pl = new List<ListPlant>();
            pl.Add(new ListPlant { Name = "1101", Text = "1101 - Махачкала" });
            pl.Add(new ListPlant { Name = "1102", Text = "1102 - Москва" });
            pl.Add(new ListPlant { Name = "1103", Text = "1103 - Ниж. Новгород" });
            pl.Add(new ListPlant { Name = "1104", Text = "1104 - Челябинск" });
            pl.Add(new ListPlant { Name = "1105", Text = "1105 - Санкт-Петербург" });
            pl.Add(new ListPlant { Name = "1106", Text = "1106 - Калуга" });
            SelectList pl1 = new SelectList(pl, "Name", "Text");
            ViewBag.Plant = pl1;


            return View(model);
        }

        public ActionResult LogOff()
        {
            //  Session.Clear();
            if (Session["ILD"] != null)
            {
                SessionLib sess = new SessionLib(Session["lang"].ToString(), Session["tabnumber"].ToString(), (String)Session["SystemSap"], (string)Session["Plant"]);
                sess.WorkSession("CLOSE", Session["ILD"].ToString());
            }
            FormsAuthentication.SignOut();
            return Redirect("/Home/Start");
        }

        [SessionExpire]
        [Authorize]
        public ActionResult Index()
        {

            ViewGrid grid = new ViewGrid((String)Session["SystemSap"], Session["ILD"].ToString());
            List<SetTab> sp = grid.ReadParameTab("YsfcGetOperationsListWs", "EtOperListWs", "1");
            Session["GridOperPos"] = sp;
            SetTab record = new SetTab();
            record.Name = "ActsAlwd1";
            record.visibleCol = false;
            record.Description = "ActsAlwd1";
            record.width = 100;
            sp.Add(record);
            ViewBag.GridOperPos = GetListMainOper();



            // DXCOMMENT: Pass a data model for GridView
            ViewBag.SystemM = true;
            LoadData _getData = new LoadData(Session["ILD"].ToString());
            List<YsfcOperListWs> mainOper = _getData.OperLoad(Session["tabnumber"].ToString(), Session["lang"].ToString(), "X", (String)Session["SystemSap"]);
            if (mainOper.Count() > 0)
                ViewBag.login = mainOper.First().PernrFn;
            else ViewBag.login = "";
            ViewBag.Systema = (String)Session["SystemSap"];
            Session["TabOper"] = mainOper;
            return View(mainOper);
        }

        public List<SetTab> GetListMainOper()
        {
            List<SetTab> sp;
            if (Session["GridOperPos"] != null)
            {
                sp = (List<SetTab>)Session["GridOperPos"];
            }
            else sp = new List<SetTab>();
            SetTab record = new SetTab();
            record.Name = "ActsAlwd1";
            record.visibleCol = false;
            record.Description = "ActsAlwd1";
            record.width = 100;
            sp.Add(record);
            return sp;
        }

        [SessionExpire]
        public ActionResult GridViewPartialView()
        {

            ViewBag.GridOperPos = GetListMainOper();
            List<YsfcOperListWs> mainOper = new List<YsfcOperListWs>();
            mainOper = (List<YsfcOperListWs>)Session["TabOper"];
            return PartialView("GridViewPartialView", mainOper);
        }

        [SessionExpire]
        public ActionResult GridViewPartialViewUpdateFull()
        {

            ViewBag.GridOperPos = GetListMainOper();

            LoadData _getData = new LoadData(Session["ILD"].ToString());
            List<YsfcOperListWs> mainOper = new List<YsfcOperListWs>();
            mainOper = _getData.OperLoad(Session["tabnumber"].ToString(), Session["lang"].ToString(), "", (String)Session["SystemSap"]);
            Session["TabOper"] = mainOper;
            return PartialView("GridViewPartialView", mainOper);
        }
        [SessionExpire]
        public ActionResult GridViewPartialViewUpdate(string stat, string obj, string allzt, string opci, string ActB)
        {


            ViewBag.GridOperPos = GetListMainOper();
            List<YsfcOperListWs> mainOper = new List<YsfcOperListWs>();
            mainOper = (List<YsfcOperListWs>)Session["TabOper"];
            var ob = mainOper.FirstOrDefault(x => x.Asszl == allzt && x.Objnr == obj);

            YsfcOperListWs oper = new YsfcOperListWs();
            if (obj != null)
            {
                LoadData _getData = new LoadData(Session["ILD"].ToString());
                _getData.GetOperDetail(obj, allzt, "Oper", (String)Session["SystemSap"]);
                oper = _getData.OperDet;
                if (oper == null)
                {
                    oper = new YsfcOperListWs();
                }
            }


            if (ob != null)
            {
                if (opci == "0")
                {
                    ob.Usttxt = stat;
                    ob.ActsAlwd1 = ActB;
                }
                else if (opci == "1")
                {
                    LoadData _getData = new LoadData(Session["ILD"].ToString());
                    ob.Usttxt = _getData.GetStatus(oper.Usttxt);
                    ob.ActsAlwd1 = oper.ActsAlwd1;

                }
                ob.Xmnga = oper.Xmnga;
                ob.Lmnga = oper.Lmnga;
                ob.Diaco = oper.Diaco;
                ob.DiacoTxt = oper.DiacoTxt;
                ob.Diaty = oper.Diaty;
                ob.Qmnum = oper.Qmnum;
                ob.Ism03 = oper.Ism03;
                ob.Qmclo = oper.Qmclo;
            }
            Session["TabOper"] = mainOper;
            //         System.Threading.Thread.Sleep(500);
            //   return Json(new { brakC = ob.xmnga, prodC= ob.lmnga });
            return PartialView("GridViewPartialView", mainOper);
        }







        public ActionResult PopupDetail()
        {

            return PartialView();
        }
        public ActionResult PopupTableDetails(string obj, string Asszl)
        {
            /* _getData.GetOperDetail(obj, Asszl, "Oper");
             ViewData["oper"] = _getData.OperDet;*/


            Session["Obj"] = obj;
            Session["Asszl"] = Asszl;
            return PartialView();
        }

        public ActionResult PopupConfirmTab(string obj, string Asszl)
        {

            Session["Obj"] = obj;
            Session["Asszl"] = Asszl;
            return PartialView();
        }

        public ActionResult PopupMessage(string obj, string Asszl)
        {

            Session["Obj"] = obj;
            Session["Asszl"] = Asszl;
            return PartialView();
        }


        public ActionResult PopupDetailAction(string customerID, string Asszl, string pageID)
        {


            LoadData _getData = new LoadData(Session["ILD"].ToString());

            Session["pageID"] = pageID;
            _getData.GetOperDetail(customerID, Asszl, "all", (String)Session["SystemSap"]);
            Session["SubOper"] = _getData.SubOper;
            Session["NorDoc"] = _getData.NorDoc;
            Session["MatIput"] = _getData.MatIput;
            Session["VPS"] = _getData.VPS;
            Session["SerMumber"] = _getData.SEN;
            Session["TehDoc"] = _getData.TehDoc;
            YsfcOperListWs oper = new YsfcOperListWs();
            _getData.GetOperDetail(customerID, Asszl, "Oper", (String)Session["SystemSap"]);

            Session["SerMumberFlag"] = _getData.OperDet.Sernp;
            return PartialView("PopupDetail");

        }

        public PartialViewResult UserTableDetails()
        {
            LoadData _getData = new LoadData(Session["ILD"].ToString());
            YsfcOperListWs oper = new YsfcOperListWs();
            if (Session["Obj"] != null) {
                _getData.GetOperDetail(Session["Obj"].ToString(), Session["Asszl"].ToString(), "Oper", (String)Session["SystemSap"]);
                oper = _getData.OperDet;
                if (oper == null)
                {
                    oper = new YsfcOperListWs();
                }
            }
            return PartialView(oper);
        }


        public PartialViewResult linkTableDetails(string ObjId = "", string Asszl = "")
        {
            LoadData _getData = new LoadData(Session["ILD"].ToString());
            YsfcOperListWs oper = new YsfcOperListWs();
            if (ObjId != "") {
                _getData.GetOperDetail(ObjId, Asszl, "Oper", (String)Session["SystemSap"]);
                oper = _getData.OperDet;
                if (oper.Sernp != null && oper.Sernp != "")
                {
                    ViewBag.SerNomer = true;
                }
                else {
                    ViewBag.SerNomer = false;
                }
            }
            ViewBag.ObjId = ObjId;
            ViewBag.Asszl = Asszl;
            return PartialView();
        }





        public PartialViewResult UserConfirmOperation()
        {

            PUT_OPERATION_TICKET.YsfcOperConfirmWs confirm = new PUT_OPERATION_TICKET.YsfcOperConfirmWs();
            if (Session["Confirm"] != null)
            {
                confirm = (PUT_OPERATION_TICKET.YsfcOperConfirmWs)Session["Confirm"];
            }
            // проверка на сетевой график для того чтобы не указывать браковое значение
            if (confirm.Aufnr != null && confirm.Aufnr[0] == '4')
            {
                ViewBag.Disabled = true;
            }
            else ViewBag.Disabled = false;
            return PartialView(confirm);
        }


        public PartialViewResult UserMessage()
        {
            ViewData["Qmgrp"] = null;
            ViewData["Coord"] = null;
            ViewData["Otgrp"] = null;
            //     ViewData["Fegrp"] = null;
            ViewData["Qmcod"] = null;
            ViewData["Oteil"] = null;
            //    ViewData["Fecod"] = null;
            ViewData["QmcodS"] = null;
            ViewData["OteilS"] = null;
            ViewData["FecodS"] = null;
            PutNotification.YsfcOperQnoticeWs QnoticeWs = new PutNotification.YsfcOperQnoticeWs();
            ViewBag.EBut = false;
            if (Session["QnoticeWs"] != null)
            {
                QnoticeWs = (PutNotification.YsfcOperQnoticeWs)Session["QnoticeWs"];
                if (QnoticeWs.Text != null && QnoticeWs.Text != "")
                    ViewBag.EBut = true;

                ViewData["QmcodS"] = QnoticeWs.Qmcod;
                ViewData["OteilS"] = QnoticeWs.Oteil;

                string lang = Session["lang"].ToString();
                string TabNumber = Session["tabnumber"].ToString();
                GetF4helpHitList hitL = new GetF4helpHitList(lang, TabNumber, (String)Session["SystemSap"], Session["ILD"].ToString());
                DataTable Coord = hitL.GetCoord(QnoticeWs);
                DataTable Qmgrp = hitL.GetQmgrp(QnoticeWs);
                DataTable Otgrp = hitL.GetOtgrp(QnoticeWs);
                //   DataTable Fegrp = hitL.GetFegrp(QnoticeWs);
                DataTable Qmcod = hitL.GetQmcod1(QnoticeWs);
                DataTable Oteil = hitL.GetOteil1(QnoticeWs);
                //   DataTable Fecod = hitL.GetFecod1(QnoticeWs);
                ViewData["Qmgrp"] = Qmgrp;
                ViewData["Otgrp"] = Otgrp;
                //     ViewData["Fegrp"] = Fegrp;
                ViewData["Qmcod"] = Qmcod;
                ViewData["Oteil"] = Oteil;
                //   ViewData["Fecod"] = Fecod;
                ViewData["Coord"] = Coord;
            }
            return PartialView(QnoticeWs);
        }

        /*********************************************************************************************************/
        public ActionResult tabControlDetail()
        {
            ViewBag.SerMumber = false;
            ViewBag.pageID = 0;
            if (Session["pageID"] != null)
                ViewBag.pageID = (String)(Session["pageID"]);

            if (Session["SerMumberFlag"] != null && (String)Session["SerMumberFlag"] != "")
            {

                ViewBag.SerMumber = true;
            }
            return PartialView();
        }



        public ActionResult TabStopClouseOper()
        {
            ViewBag.SerMumber = false;
            if (Session["SerMumberFlag"] != null && (String)Session["SerMumberFlag"] != "")
            {

                ViewBag.SerMumber = true;
            }
            return PartialView();
        }

        public ActionResult tabPodOper()
        {
            return PartialView();
        }
        public ActionResult tabPodOper1()
        {
            List<SetTab> sp;
            if (Session["GridSubOper"] != null)
            {
                sp = (List<SetTab>)Session["GridSubOper"];
            }
            else sp = new List<SetTab>();
            ViewBag.GridSubOper = sp;
            return PartialView("~/Views/Home/_tabPodOper1.cshtml", (List<YsfcOperDetailSboWs>)Session["SubOper"]);
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartialDoc()
        {

            List<SetTab> sp;
            if (Session["GridDoc"] != null)
            {
                sp = (List<SetTab>)Session["GridDoc"];
            }
            else sp = new List<SetTab>();
            ViewBag.GridDoc = sp;
            return PartialView("~/Views/Home/_GridViewPartialDoc.cshtml", (List<YsfcOperDetailDocWs>)Session["NorDoc"]);
        }
        [ValidateInput(false)]
        public ActionResult GridView1PartialComp()
        {

            List<SetTab> sp;
            if (Session["GridComp"] != null)
            {
                sp = (List<SetTab>)Session["GridComp"];
            }
            else sp = new List<SetTab>();
            ViewBag.GridComp = sp;
            return PartialView("~/Views/Home/_GridView1PartialComp.cshtml", (List<YsfcOperDetailCmpWs>)Session["MatIput"]);
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartialVPS()
        {
            List<SetTab> sp;
            if (Session["GridVPS"] != null)
            {
                sp = (List<SetTab>)Session["GridVPS"];
            }
            else sp = new List<SetTab>();
            ViewBag.GridVPS = sp;
            return PartialView("~/Views/Home/_GridViewPartialVPS.cshtml", (List<YsfcOperDetailPrtWs>)Session["VPS"]);
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartialTehDoc()
        {
            List<YsfcOperFormsWs> sp = (List<YsfcOperFormsWs>)Session["TehDoc"];
            return PartialView("~/Views/Home/_GridViewPartialTehDoc.cshtml", sp);
        }



        public ActionResult GridViewPartialSen()
        {
            List<SetTab> sp;
            if (Session["GridSR"] != null)
            {
                sp = (List<SetTab>)Session["GridSR"];
            }
            else sp = new List<SetTab>();
            ViewBag.SerMumber = sp;
            return PartialView("~/Views/Home/_GridViewPartialSer.cshtml", (List<YsfcOperDetailSenWs>)Session["SerMumber"]);
        }





        public ActionResult UserInputData()
        {
            return PartialView();
        }
        [ValidateInput(false)]
        public ActionResult GridLookupPartial()
        {
            var model = new List<SearchTabModel>();
            model.Add(new SearchTabModel { tabelNumber = "766", workerName = "Vasya", workerSurname = "Ivanov", workingPlace = "234520" });
            model.Add(new SearchTabModel { tabelNumber = "756", workerName = "Vasya", workerSurname = "Ivanov", workingPlace = "234520" });
            model.Add(new SearchTabModel { tabelNumber = "716", workerName = "Vasya", workerSurname = "Ivanov", workingPlace = "234520" });
            model.Add(new SearchTabModel { tabelNumber = "734", workerName = "Vasya", workerSurname = "Ivanov", workingPlace = "234520" });
            model.Add(new SearchTabModel { tabelNumber = "720", workerName = "Vasya", workerSurname = "Ivanov", workingPlace = "234520" });
            model.Add(new SearchTabModel { tabelNumber = "763", workerName = "Vasya", workerSurname = "Ivanov", workingPlace = "234520" });
            return PartialView("~/Views/Home/_GridLookupPartial.cshtml", model);
        }
        [ValidateInput(false)]
        public ActionResult WorkPlaceInputGridLookupPartial()
        {
            var model = new List<WorkPlaceInputModel>();
            model.Add(new WorkPlaceInputModel { workPlaceCRHD = "01010012", workPlaceDescrCRTX = "ПробивнойПресс" });
            model.Add(new WorkPlaceInputModel { workPlaceCRHD = "01015432", workPlaceDescrCRTX = "ФрезерСтанок" });
            model.Add(new WorkPlaceInputModel { workPlaceCRHD = "01010012", workPlaceDescrCRTX = "ПробивнойПресс" });
            model.Add(new WorkPlaceInputModel { workPlaceCRHD = "01016472", workPlaceDescrCRTX = "КопирАппарат" });
            model.Add(new WorkPlaceInputModel { workPlaceCRHD = "01011232", workPlaceDescrCRTX = "СтиральнаяМашина" });
            model.Add(new WorkPlaceInputModel { workPlaceCRHD = "01012212", workPlaceDescrCRTX = "Автомобиль" });
            return PartialView("_WorkPlaceInputGridLookupPartial", model);
        }
        [ValidateInput(false)]
        public ActionResult PlantInputGridLookupPartial()
        {
            var model = new List<PlantInputModel>();
            model.Add(new PlantInputModel { plantNumber = "1101", plantDescription = "Махачкала" });
            model.Add(new PlantInputModel { plantNumber = "1201", plantDescription = "Екатеринбург" });
            model.Add(new PlantInputModel { plantNumber = "1104", plantDescription = "Челябинск" });
            model.Add(new PlantInputModel { plantNumber = "1100", plantDescription = "Москва" });
            return PartialView("_PlantInputGridLookupPartial", model);
        }
        [ValidateInput(false)]
        public ActionResult MaterInputGridLookupPartial()
        {
            var model = new List<MaterInputModel>();
            model.Add(new MaterInputModel { osnZapMaterRESB = "90000003", materialDescrMAKT = "ВАИШ.687254.003 Плата печатная многослой" });
            model.Add(new MaterInputModel { osnZapMaterRESB = "90000042", materialDescrMAKT = "Кабель Flexiform 402 L HABIA CABLE" });
            model.Add(new MaterInputModel { osnZapMaterRESB = "90000052", materialDescrMAKT = "Компл вход соед для Micro корпусов VICOR" });
            model.Add(new MaterInputModel { osnZapMaterRESB = "90000142", materialDescrMAKT = "Микросхема NJM2880U33 JRC" });
            model.Add(new MaterInputModel { osnZapMaterRESB = "90000144", materialDescrMAKT = "Микросхема PAT-10 MINI-CIRCUITS" });
            return PartialView("_MaterInputGridLookupPartial", model);
        }
        [ValidateInput(false)]
        public ActionResult ShortageGridViewPartial()
        {
            var model = new List<ShortageAlarmModel>();
            model.Add(new ShortageAlarmModel { plant = "1101", warehouse = "019", materialNumber = "90000123", materialDescription = "ВАИШ.687254.003 Плата печатная многослой", demand = "7,280", shortage = "7,280", measureUnit = "М", objectID = "1" });
            model.Add(new ShortageAlarmModel { plant = "1101", warehouse = "019", materialNumber = "90000034", materialDescription = "Микросхема PAT-10 MINI-CIRCUITS", demand = "7,280", shortage = "7,280", measureUnit = "М", objectID = "2" });
            model.Add(new ShortageAlarmModel { plant = "1101", warehouse = "022", materialNumber = "90000233", materialDescription = "ВАИШ.687254.003 Плата печатная многослой", demand = "7,280", shortage = "7,280", measureUnit = "М", objectID = "3" });
            model.Add(new ShortageAlarmModel { plant = "1101", warehouse = "019", materialNumber = "90000013", materialDescription = "Компл вход соед для Micro корпусов VICOR", demand = "7,280", shortage = "7,280", measureUnit = "М", objectID = "4" });
            model.Add(new ShortageAlarmModel { plant = "1101", warehouse = "021", materialNumber = "90000003", materialDescription = "Кабель Flexiform 402 L HABIA CABLE", demand = "7,280", shortage = "7,280", measureUnit = "М", objectID = "5" });
            model.Add(new ShortageAlarmModel { plant = "1101", warehouse = "019", materialNumber = "90000033", materialDescription = "ВАИШ.687254.003 Плата печатная многослой", demand = "7,280", shortage = "7,280", measureUnit = "М", objectID = "6" });
            return PartialView("_ShortageGridViewPartial", model);
        }


        [HttpPost]
        public JsonResult StatrtStatus(string obj, string allzt, string act, string step)
        {

            string lang = Session["lang"].ToString();
            string TabNumber = Session["tabnumber"].ToString();
            PUT_OPERATION_TICKET.YsfcOperConfirmWs EConfirmD = new PUT_OPERATION_TICKET.YsfcOperConfirmWs();

            //    EConfirmD.Pernr = Session["tabnumber"].ToString();
            if (Session["EConfirmData"] != null && step == "2")
            {
                EConfirmD = (PUT_OPERATION_TICKET.YsfcOperConfirmWs)Session["EConfirmData"];
            }

            bool Clref = false;
            WorkStatus action = new WorkStatus(lang, TabNumber, (String)Session["SystemSap"], Session["ILD"].ToString());
            PUT_OPERATION_TICKET.YsfcPutOperationTicketWsResponse ansver = action.Start_operation(obj, allzt, act, step, EConfirmD);
            bool window_error = true;// переменная окна ошибки
            if (ansver.EReturn.Type == "" || ansver.EReturn.Type.ToLower() == "s") window_error = false;
            Session["EConfirmData"] = ansver.EConfirmData;
            if (step == "2")
            {
                Clref = true;
            }
            return Json(new { isAdded = window_error, refreshC = Clref, message = ansver.EReturn.Message, type = ansver.EReturn.Type });

        }

        [HttpPost]
        public JsonResult ZQmcod(string Grupa)
        {

            ViewData["Qmcod"] = null;
            PutNotification.YsfcOperQnoticeWs QnoticeWs = new PutNotification.YsfcOperQnoticeWs();
            if (Session["QnoticeWs"] != null)
            {
                QnoticeWs = (PutNotification.YsfcOperQnoticeWs)Session["QnoticeWs"];
                QnoticeWs.Qmgrp = Grupa;
                string lang = Session["lang"].ToString();
                string TabNumber = Session["tabnumber"].ToString();
                GetF4helpHitList hitL = new GetF4helpHitList(lang, TabNumber, (String)Session["SystemSap"], Session["ILD"].ToString());
                DataTable Qmcod = hitL.GetQmcod(QnoticeWs);
                ViewData["Qmcod"] = Qmcod;
            }

            return Json(new { isAdded = false });

        }




        [HttpPost]
        public JsonResult StopComplete(string obj, string allzt, string act, string step, string sernp)
        {

            string lang = Session["lang"].ToString();
            string TabNumber = Session["tabnumber"].ToString();
            Session["SerMumberFlag"] = sernp;
            WorkStatus action = new WorkStatus(lang, TabNumber, (String)Session["SystemSap"], Session["ILD"].ToString());
            PUT_OPERATION_TICKET.YsfcPutOperationTicketWsResponse ansver = action.StopeCompleteStepOne(obj, allzt, act, step);
            bool window_error = true;// переменная окна ошибки
            if (ansver.EReturn.Type == "" || ansver.EReturn.Type.ToLower() == "s") window_error = false;
            PUT_OPERATION_TICKET.YsfcOperConfirmWs DataOper = ansver.EConfirmData;
            DataOper.Lmnga = DataOper.Lmnga.Trim();
            DataOper.Xmnga = DataOper.Xmnga.Trim();
            DataOper.Asszl = allzt;
            Session["Confirm"] = DataOper;
            //получаем список серийных номеров из GetOperationDetail
            LoadData _getData = new LoadData(Session["ILD"].ToString());
            _getData.GetOperDetail(obj, allzt, "Sen", (String)Session["SystemSap"]);
            Session["SerMumber"] = _getData.SEN;
            return Json(new { isAdded = window_error, message = ansver.EReturn.Message, type = ansver.EReturn.Type });

        }

        // var z = { prod: product, br: brak, step: "2", stat: Status };
        [HttpPost]
        public JsonResult StopCompleteTwo(string prod, string br, string mess, string Operate)
        {

            //  Double prod1 = Convert.ToDouble(prod);

            PUT_OPERATION_TICKET.YsfcOperConfirmWs DataOper = (PUT_OPERATION_TICKET.YsfcOperConfirmWs)Session["Confirm"];
            DataOper.Ltxa1 = mess;
            DataOper.Lmnga = prod.Replace(".", ",");
            DataOper.Xmnga = br.Replace(".", ",");
            List<SSZ.GetOperDetail.YsfcOperDetailSenWs> SEN = (List<SSZ.GetOperDetail.YsfcOperDetailSenWs>)Session["SerMumber"];
            string lang = Session["lang"].ToString();
            string TabNumber = Session["tabnumber"].ToString();
            WorkStatus action = new WorkStatus(lang, TabNumber, (String)Session["SystemSap"], Session["ILD"].ToString());
            PUT_OPERATION_TICKET.YsfcReturnWs ansver = action.StopeCompleteStepTwo(DataOper, Operate, SEN);
            bool window_error = true;// переменная окна ошибки
            if (ansver.Type == "" || ansver.Type.ToLower() == "s") window_error = false;
            return Json(new { isAdded = window_error, message = ansver.Message, type = ansver.Type });

        }

        [HttpPost]
        public JsonResult ASMessage(string obj, string allzt, string act, string step, string message, string type, string qmgrp, string qmcod, string otgrp, string oteil, string coord, int KolDef, string checkP)
        {

            string lang = Session["lang"].ToString();
            string TabNumber = Session["tabnumber"].ToString();
            SentMessage action = new SentMessage(lang, TabNumber, (String)Session["SystemSap"], Session["ILD"].ToString());
            PutNotification.YsfcOperQnoticeWs sentdata = new PutNotification.YsfcOperQnoticeWs();
            PutNotification.YsfcQnoteItemWs[] QnoteItemWs = new PutNotification.YsfcQnoteItemWs[1];
            if (Session["QnoticeWs"] != null && step == "2")
            {
                var coordinator = coord.Split('-');
                sentdata = (PutNotification.YsfcOperQnoticeWs)Session["QnoticeWs"];
                sentdata.Text = message;
                string _selectedIDs = Request.Params["selectedIDs"];
                //     sentdata.Fecod = fecod;
                //      sentdata.Fegrp = fegrp;
                sentdata.Qmcod = qmcod;
                sentdata.Qmgrp = qmgrp;
                sentdata.Oteil = oteil;
                sentdata.Otgrp = otgrp;
                sentdata.Coord = coordinator[0].Trim();
                sentdata.Rkmng = KolDef.ToString();
                QnoteItemWs = action.QnoteItemWs((List<DefectOZM>)Session["QmDef"], checkP);
                // sentdata.Qmart = type;
            }

            Session["Obj"] = obj;
            Session["Asszl"] = allzt;

            ViewBag.EBut = false;
            PutNotification.YsfcPutNotificationWsResponse ansver = action.ansverMessage(obj, allzt, act, step, sentdata, QnoteItemWs);
            bool window_error = true;// переменная окна ошибки
            if (ansver.EReturn.Type == "" || ansver.EReturn.Type.ToLower() == "s") window_error = false;
            if (step == "1")
            {



                //получаем от сапа присоенные данные сообщению
                PutNotification.YsfcOperQnoticeWs data = ansver.EQnoticeData;
                if (data.Text != null && data.Text != "")
                {
                    string mess = data.Text.Replace("----------------------------------------", "$");
                    var mas = mess.Split('$');
                    data.Text = mas[mas.Length - 1];

                }
                //Записываем в память
                Session["QnoticeWs"] = data;
                return Json(new { isAdded = window_error, message = ansver.EReturn.Message, type = ansver.EReturn.Type });
            }
            else
            {
                bool Clref = false;
                if (ansver.EReturn.Type == "I")
                {
                    Clref = true;
                }
                return Json(new { isAdded = window_error, refreshC = Clref, message = ansver.EReturn.Message, type = ansver.EReturn.Type });
            }

        }


        public ActionResult QmcodPart(string Qmgrp1)
        {
            DataTable Qmcod = null;
            ViewData["Qmcod"] = null;
            PutNotification.YsfcOperQnoticeWs QnoticeWs = new PutNotification.YsfcOperQnoticeWs();
            if (Session["QnoticeWs"] != null)
            {
                QnoticeWs = (PutNotification.YsfcOperQnoticeWs)Session["QnoticeWs"];
                QnoticeWs.Qmgrp = Qmgrp1;
                string lang = Session["lang"].ToString();
                string TabNumber = Session["tabnumber"].ToString();
                GetF4helpHitList hitL = new GetF4helpHitList(lang, TabNumber, (String)Session["SystemSap"], Session["ILD"].ToString());
                Qmcod = hitL.GetQmcod(QnoticeWs);
                ViewData["Qmcod"] = Qmcod;
            }

            return PartialView("QmcodPart", Qmcod);
        }

        public ActionResult OteilPart(string Otgrp1)
        {
            DataTable Oteil = null;
            ViewData["Oteil"] = null;
            PutNotification.YsfcOperQnoticeWs QnoticeWs = new PutNotification.YsfcOperQnoticeWs();
            if (Session["QnoticeWs"] != null)
            {
                QnoticeWs = (PutNotification.YsfcOperQnoticeWs)Session["QnoticeWs"];
                QnoticeWs.Otgrp = Otgrp1;
                string lang = Session["lang"].ToString();
                string TabNumber = Session["tabnumber"].ToString();
                GetF4helpHitList hitL = new GetF4helpHitList(lang, TabNumber, (String)Session["SystemSap"], Session["ILD"].ToString());
                Oteil = hitL.GetOteil(QnoticeWs);
                ViewData["Oteil"] = Oteil;
            }

            return PartialView("OteilPart", Oteil);
        }

        public ActionResult messageForm()
        {
            PutNotification.YsfcOperQnoticeWs QnoticeWs = new PutNotification.YsfcOperQnoticeWs();
            if (Session["QnoticeWs"] != null)
            {
                QnoticeWs = (PutNotification.YsfcOperQnoticeWs)Session["QnoticeWs"];
            }
            return PartialView("messageForm", QnoticeWs);
        }


        public ActionResult QmOzmDefect()
        {
            string lang = Session["lang"].ToString();
            string TabNumber = Session["tabnumber"].ToString();
            SentMessage action = new SentMessage(lang, TabNumber, (String)Session["SystemSap"], Session["ILD"].ToString());
            List<DefectOZM> spis = new List<DefectOZM>();
            if (Session["Obj"] != null) {
                string obj = (String)Session["Obj"];
                string allzt = (String)Session["Asszl"];
                spis = action.GetQnotIT(obj, allzt);
                Session["QmDef"] = spis;
            }

            return PartialView("QmOzmDefect", spis);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult InlineEditFormTemplatePartial1(DefectOZM с)
        {
      
                return PartialView("InlineEditFormTemplatePartial1", (SSZ.Models.DefectOZM) с);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult InlineEditingWithTemplateUpdatePostPartial(DefectOZM post)
        {
           
            List<DefectOZM> spis = (List<DefectOZM>)Session["QmDef"];
            if (ModelState.IsValid)
            {
                try
                {
                    var sp = spis.FirstOrDefault(x => x.ID == post.ID);
                    if (sp != null) {
                        sp.Fmgeig = post.Fmgeig;
                        sp.Posnr = post.Posnr;
                        sp.Prueflinr = post.Prueflinr;
                        sp.Anzfehler = post.Anzfehler;
                        Session["QmDef"] = spis;

                    }
                }
                catch (Exception e)
                {
                    ViewData["EditNodeError"] = e.Message;
                }
            }
            else
                ViewData["EditNodeError"] = "Please, correct all errors.";
            return PartialView("QmOzmDefect",spis);
        }


        [ValidateInput(false)]
        public ActionResult DefMat(string SearchText)
        {
            // string _selectedIDs = Request.Params["selectedIDs"];
            ViewData["SearchText"] = SearchText;
            List<DefectOZM> spis =(List<DefectOZM>) Session["QmDef"];

            return PartialView("QmOzmDefect", spis);
        }

        public ActionResult DefMatCustom(string SearchText, bool? isNewSearch)
        {
            // string _selectedIDs = Request.Params["selectedIDs"];
            ViewData["SearchText"] = SearchText;
            ViewData["IsNewSearch"] = isNewSearch;
            List<DefectOZM> spis = (List<DefectOZM>)Session["QmDef"];
            return PartialView("QmOzmDefect", spis);
        }

        /*    public ActionResult FecodPart(string Fegrp1)
            {
                DataTable Fecod = null;
                ViewData["Fecod"] = null;
                PutNotification.YsfcOperQnoticeWs QnoticeWs = new PutNotification.YsfcOperQnoticeWs();
                if (Session["QnoticeWs"] != null)
                {
                    QnoticeWs = (PutNotification.YsfcOperQnoticeWs)Session["QnoticeWs"];
                    QnoticeWs.Fegrp = Fegrp1;
                    string lang = Session["lang"].ToString();
                    string TabNumber = Session["tabnumber"].ToString();
                    GetF4helpHitList hitL = new GetF4helpHitList(lang, TabNumber, (String)Session["SystemSap"], Session["ILD"].ToString());
                    Fecod = hitL.GetFecod(QnoticeWs);
                    ViewData["Fecod"] = Fecod;
                }

                return PartialView("FecodPart", Fecod);
            }/*

        */


        [SessionExpire]
        public JsonResult GridViewPartialViewUpdate3()
        {
            LoadData _getData = new LoadData(Session["ILD"].ToString());
            List<YsfcOperListWs> mainOper = new List<YsfcOperListWs>();
            mainOper = _getData.OperLoad(Session["tabnumber"].ToString(), Session["lang"].ToString(), "X", (String)Session["SystemSap"]);
            Session["TabOper"] = mainOper;
            ViewBag.GridOperPos = GetListMainOper();
            Int32 count = mainOper.Count();
            return Json(new { isAdded = true, RowCount = count });
        }


        //Вывод списка серийных номеров для потверждения выполненных операций
        public ActionResult GetSerNumber()
        {
            List<YsfcOperDetailSenWs> SEN = (List<YsfcOperDetailSenWs>)Session["SerMumber"];
            return View(SEN);
        }

        //выбор серийных номеров из списка
        public JsonResult ChangeCHeckSerNumber(string SerNumber , String check)
        {
            string sern = SerNumber.Trim();
            List<YsfcOperDetailSenWs> SEN = (List<YsfcOperDetailSenWs>)Session["SerMumber"];
            var sn = SEN.FirstOrDefault(x => x.Sernr == sern);
            if (sn != null)
            {
                sn.Kzebu = check;
                Session["SerMumber"] = SEN;
            }
            return Json(new { isAdded = true });
        }






        

    }
}