using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSZ.Models;
using SSZ.LibService;
using System.Data;
using DevExpress.Web.Mvc;
using SSZ.LibService;

namespace SSZ.Controllers
{
    public class SettingController : Controller
    {
       
        public ActionResult TabOper1()
        {
            // SettingTab tab = new SettingTab();

            ViewGrid grid = new ViewGrid( (String)Session["SystemSap"], Session["ILD"].ToString());
            List<SetTab> spis = grid.ReadParameTab("YsfcGetOperationsListWs", "EtOperListWs", "1");
            Session["GridOperPos"] = spis;
            return PartialView(spis);
        }

        public ActionResult GridOper()
        {
            // SettingTab tab = new SettingTab();

            ViewGrid grid = new ViewGrid( (String)Session["SystemSap"] , Session["ILD"].ToString());
            List<SetTab> spis = grid.ReadParameTab("YsfcGetOperationsListWs", "EtOperListWs", "1");
            Session["GridOperPos"] = spis;
            return PartialView(spis);
        }


        public ActionResult SubOperGrid()
        {
            // SettingTab tab = new SettingTab();

            ViewGrid grid = new ViewGrid( (String)Session["SystemSap"], Session["ILD"].ToString());
            List<SetTab> spis = grid.ReadParameTab("YsfcGetOperationDetailWs", "EtOperSboWs",  "2");
            Session["GridSubOper"] = spis;
            return PartialView(spis);
        }


        public ActionResult DocGrid()
        {
            // SettingTab tab = new SettingTab();
            ViewGrid grid = new ViewGrid( (String)Session["SystemSap"], Session["ILD"].ToString());
            List<SetTab> spis = grid.ReadParameTab("YsfcGetOperationDetailWs", "EtOperDocWs", "3");
            Session["GridDoc"] = spis;
            return PartialView(spis);
        }


        public ActionResult CompGrid()
        {
            // SettingTab tab = new SettingTab();
            ViewGrid grid = new ViewGrid( (String)Session["SystemSap"], Session["ILD"].ToString());
            List<SetTab> spis = grid.ReadParameTab("YsfcGetOperationDetailWs", "EtOperCmpWs", "4");
            Session["GridComp"] = spis;
            return PartialView(spis);
        }


        public ActionResult VPSGrid()
        {
            // SettingTab tab = new SettingTab();
            ViewGrid grid = new ViewGrid( (String)Session["SystemSap"], Session["ILD"].ToString());
            List<SetTab> spis = grid.ReadParameTab("YsfcGetOperationDetailWs", "EtOperPrtWs", "5");
            Session["GridVPS"] = spis;
            return PartialView(spis);
        }


        // Серийные номера 
        public ActionResult SRGrid()
        {
            // SettingTab tab = new SettingTab();
            ViewGrid grid = new ViewGrid( (String)Session["SystemSap"], Session["ILD"].ToString());
            List<SetTab> spis = grid.ReadParameTab("YsfcGetOperationDetailWs", "EtOperSenWs", "6");
            Session["GridSR"] = spis;
            return PartialView(spis);
        }

        // Отчет по премиям рабочим 
        public ActionResult PrimeGrid()
        {
            // SettingTab tab = new SettingTab();
            ViewGrid grid = new ViewGrid((String)Session["SystemSap"], Session["ILD"].ToString());
            List<SetTab> spis = grid.ReadParameTab("YsfcGetStatisticsWs", "EtStatDataWs", "7");
            Session["PrimeGrid"] = spis;
            return PartialView(spis);
        }


        //Формируем таблицу для сохранения данных
        [HttpPost]
        public JsonResult FormGrid(String Position, String Name, String Description, Int32 Width1, Int32 Fontsize1, bool Vis1, Int32 Ind)
        {
            List<SetTab> sp = new List<SetTab>();
            if (Ind == 1) { Session["SettingTemp"] = null; }
            else
            {
                sp = (List<SetTab>)Session["SettingTemp"];
            }
            SetTab st = new SetTab();
            st.position = Position.Trim();
            st.Name = Name.Trim();
            st.Description = Description.Trim();
            st.width = Width1;
            st.fontSize = Fontsize1;
            st.visibleCol = Vis1;
            sp.Add(st);
            Session["SettingTemp"] = sp;
            return Json(new { isAdded = true });
        }

        //Сохранение таблицы 
        [HttpPost]
        public JsonResult SaveGrid(Int32 TypeGrid)
        {
            List<SetTab> sp = new List<SetTab>();
            sp = (List<SetTab>)Session["SettingTemp"];

            ViewGrid grid = new ViewGrid( (String)Session["SystemSap"], Session["ILD"].ToString());
            bool isAdded = true;
            switch (TypeGrid)
            {
                case 5:
                    Session["GridOperPos"] = sp;//.OrderBy(x => Convert.ToInt32(x.position)).Select(o=>o).ToList() ;
                    grid.SaveParameTab("YsfcGetOperationsListWs", "EtOperListWs",sp, "1");
                    break;
                case 6:
                    Session["GridSubOper"] = sp;
                    grid.SaveParameTab("YsfcGetOperationDetailWs", "EtOperSboWs", sp,  "2");
                    break;
                case 7:
                    Session["GridDoc"] = sp;
                    grid.SaveParameTab("YsfcGetOperationDetailWs", "EtOperDocWs", sp, "3");
                    break;
                case 8:
                    Session["GridComp"] = sp;
                    grid.SaveParameTab("YsfcGetOperationDetailWs", "EtOperCmpWs", sp, "4");
                    break;
                case 9:
                    Session["GridVPS"] = sp;
                    grid.SaveParameTab("YsfcGetOperationDetailWs", "EtOperPrtWs", sp, "5");
                    break;
                case 10:
                    Session["GridSR"] = sp;
                    grid.SaveParameTab("YsfcGetOperationDetailWs", "EtOperSenWs", sp, "6");
                    break;
                case 11:
                    Session["PrimeGrid"] = sp;
                    grid.SaveParameTab("YsfcGetStatisticsWs", "EtStatDataWs", sp, "7");
                    break;
                default:
                    isAdded = false;
                    break;
            }
            return Json(new { isAdded });
        }


        // Восстанавливаем таблицу согласно типу
        [HttpPost]
        public JsonResult ReturnGrid(Int32 TypeGrid)
        {
            List<SetTab> sp = new List<SetTab>();
            ViewGrid grid = new ViewGrid((String)Session["SystemSap"], Session["ILD"].ToString());
            bool isAdded = true;
            switch (TypeGrid)
            {
                case 5:
                    sp = grid.ReadParameTab("YsfcGetOperationsListWs", "EtOperListWs", "1");
                    Session["GridOperPos"] = sp;
                    break;
                case 6:
                    sp = grid.ReadParameTab("YsfcGetOperationDetailWs", "EtOperSboWs", "2");
                    Session["GridSubOper"] = sp;
                    break;
                case 7:
                    sp= grid.ReadParameTab("YsfcGetOperationDetailWs", "EtOperDocWs", "3");
                    Session["GridDoc"] = sp;
                    break;
                case 8:
                    sp = grid.ReadParameTab("YsfcGetOperationDetailWs", "EtOperCmpWs", "4");
                    Session["GridComp"] = sp;
                    break;
                case 9:
                    sp = grid.ReadParameTab("YsfcGetOperationDetailWs", "EtOperPrtWs", "5");
                    Session["GridVPS"] = sp;
                    break;
                case 10:
                    sp = grid.ReadParameTab("YsfcGetOperationDetailWs", "EtOperSenWs", "6");
                    Session["GridSR"] = sp;
                    break;
                case 11:
                    sp = grid.ReadParameTab("YsfcGetStatisticsWs", "EtStatDataWs", "7");
                    Session["PrimeGrid"] = sp;
                    break;
                default:
                    isAdded = false;
                    break;
            }
            return Json(new { isAdded, sp });
        }



        public ActionResult GridViewSetOperPartial(int focusedRowIndex = 0, string ActionB = "")
        {
            List<SetTab> spis = (List<SetTab>)Session["GridOperPos"];
            if (ActionB != "")
            {
               
                Int32 Index = focusedRowIndex, newIndex = 0;
                if (ActionB == "Up")
                {
                    newIndex = spis.Count() == Index ? Index : Index - 1;
                }
                if (ActionB == "Down")
                {
                    newIndex = spis.Count() - 1 == Index ? Index : Index + 1;
                }
                if (newIndex != Index && newIndex >= 0)
                {
                    SetTab record = spis[Index];
                    SetTab temp = spis[newIndex];
                    spis[Index] = temp;
                    spis[newIndex] = record;

                }
                ViewBag.FocusedRowIndex = newIndex;
            }
            Session["GridOperPos"] = spis;

            
            return PartialView("GridViewSetOperPartial", spis);
        }


        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewSetOperEdit(MVCxGridViewBatchUpdateValues<SetTab, int> batchValues )
        {
            
            List<SetTab> spis = (List<SetTab>)Session["GridOperPos"];
            foreach (var item in batchValues.Update)
            {
                if (batchValues.IsValid(item))
                {

                    var record = spis.FirstOrDefault(x => x.Name == item.Name);
                    if (record != null) record = item;
                }
             

            }

            Session["GridOperPos"] = spis;


            return PartialView("GridViewSetOperPartial", spis);
        }

       


        [HttpPost]
        public JsonResult TempUpdate(string Position = "", Int32 Width = 0, string NPame = "" , bool GVisible=false)
        {
            if (NPame != "") { 
            List<SetTab> spis = (List<SetTab>)Session["GridOperPos"];
            SetTab record = spis.First(x=>x.Name == NPame);
            record.width = Width;
            record.visibleCol = GVisible;
            Session["GridOperPos"] = spis;
            }
            return Json(new { isAdded = true });

        }
    }
}