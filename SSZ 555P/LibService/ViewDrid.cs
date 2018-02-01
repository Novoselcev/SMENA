using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSZ.ReuseGrid;
using SSZ.Models;
namespace SSZ.LibService
{
    public class ViewGrid
    {
        public YGUI_REUSE_GRID_VARIANT REUSE_GRID;
        String ILD;
        // конструктор класса
        public ViewGrid(string sysSap, string ild)
        {
            ILD = ild;
            REUSE_GRID = new YGUI_REUSE_GRID_VARIANT(sysSap);
        }

        public List<SetTab>  ReadParameTab(string service, string tab_name, string handle)
        {
            List<SetTab> spis = new List<SetTab>();
            try
            {
                SettingTab tt = new SettingTab();
                // spis = tt.GetTab(1);
                YguiReuseGridVariantWs zpr = new YguiReuseGridVariantWs();
                zpr.IHandle = handle;
                //         zpr.ILangu = Langv;
                zpr.IAction = "READ";
                zpr.IId = ILD;
                //     zpr.IPernr = tabnumber;
                zpr.IFuncMappedName = service;
                zpr.IParamMappedName = tab_name;
                zpr.IShared = "";
                
                YguiReuseGridVariantWsResponse responce = new YguiReuseGridVariantWsResponse();
                responce = REUSE_GRID.YguiReuseGridVariantWs(zpr);
                if (responce.EFound != "X")
                {
                    zpr.IShared = "X";
                    responce = new YguiReuseGridVariantWsResponse();
                    responce = REUSE_GRID.YguiReuseGridVariantWs(zpr);
                }
                spis = responce.EtVariantDescWs.Select(x => new SetTab
                {
                    Description = x.Fieldtext,
                    Name = x.Fieldname,
                    position = x.ColPos,
                    width = x.Outputlen != "" ? Convert.ToInt32(x.Outputlen) * 10 : 50,
                    visibleCol = x.NoOut == "" ? true : x.NoOut == "1" ? true : false,
                    fontSize = x.FontSize == "" ? 12 : Convert.ToInt32(x.FontSize),
                    DescripS = x.ScrtextM
                }).ToList<SetTab>();
            }
            catch (Exception e) { }
            return spis.OrderBy(x => Convert.ToInt32(x.position)).Select(o => o).ToList();
        }

        public void SaveParameTab(string service, string tab_name, List<SetTab> sp, string handle)
        {
            
            SettingTab tt = new SettingTab();
            // spis = tt.GetTab(1);
            //Считываем
            YguiReuseGridVariantWs zpr = new YguiReuseGridVariantWs();
            zpr.IHandle = handle;
            zpr.IId = ILD;
            //     zpr.ILangu = Langv;
            zpr.IAction = "READ";
      //      zpr.IPernr = tabnumber;
            zpr.IFuncMappedName = service;
            zpr.IParamMappedName = tab_name;
            zpr.IShared = "";
            YguiReuseGridVariantWsResponse responce = new YguiReuseGridVariantWsResponse();
            responce = REUSE_GRID.YguiReuseGridVariantWs(zpr);
            var spis = responce.EtVariantDescWs.ToList();

            YguiFieldDescWs[] Result = (from e in spis
                                        join o in sp on
                                        e.Fieldname equals o.Name
                                        select new YguiFieldDescWs {
                                            ColPos = o.position.ToString(),
                                            F4availabl = e.F4availabl,
                                            Fieldname = e.Fieldname,
                                            Fieldtext = e.Fieldtext,
                                            FontSize = o.fontSize.ToString(),
                                            Intlen =e.Intlen,
                                            Inttype = e.Inttype,
                                            NoOut = o.visibleCol ? "1" : "0",
                                            Outputlen = o.width == 0 ? "0" : Convert.ToInt32(o.width / 10).ToString(),
                                            Reptext = e.Reptext,
                                            ScrtextL = e.ScrtextL,
                                            ScrtextM = e.ScrtextM,
                                            ScrtextS = e.ScrtextS,
                                            Typename = e.Typename,
                                            
                                        }  ).AsEnumerable<YguiFieldDescWs>().ToArray<YguiFieldDescWs>();

            zpr = new YguiReuseGridVariantWs();
            zpr.IHandle = handle;
       //     zpr.ILangu = Langv;
            zpr.IAction = "SAVE";
         //   zpr.IPernr = tabnumber;
            zpr.IFuncMappedName = service;
            zpr.IParamMappedName = tab_name;
            zpr.IShared = "";
            zpr.ItVariantDescWs = Result;
            zpr.IId = ILD;
            responce = new YguiReuseGridVariantWsResponse();
            responce = REUSE_GRID.YguiReuseGridVariantWs(zpr);
        }

    }
}