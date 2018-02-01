using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSZ.Models;
using SSZ.SessionSap;

namespace SSZ.LibService
{
    public class SettingTab
    {
        public List<SetTab> GetTab(Int32 type)
        {
            List<SetTab> spis = new List<SetTab>();
            spis.Add(new SetTab { Description ="Заказ", Name = "Order" , width = 100, position = "1", visibleCol = false});
            spis.Add(new SetTab { Description = "Операция", Name = "Operation", width = 100, position = "2", visibleCol = false });
            spis.Add(new SetTab { Description = "Наименование", Name = "Name", width = 100, position = "3", visibleCol = false });
            spis.Add(new SetTab { Description = "Материал", Name = "Matnr", width = 100, position = "4", visibleCol = false });
            spis.Add(new SetTab { Description = "План", Name = "Plan", width = 100, position = "5", visibleCol = false });
            spis.Add(new SetTab { Description = "Факт", Name = "Fact", width = 100, position = "6", visibleCol = false });
            spis.Add(new SetTab { Description = "Брак", Name = "Brak", width = 100, position = "7", visibleCol = false });
            spis.Add(new SetTab { Description = "План", Name = "Plan", width = 100, position = "8", visibleCol = false });
            spis.Add(new SetTab { Description = "Факт", Name = "Fact", width = 100, position = "9", visibleCol = false });
            spis.Add(new SetTab { Description = "Брак", Name = "Brak", width = 100, position = "10", visibleCol = false });
            spis.Add(new SetTab { Description = "Заказ", Name = "Order", width = 100, position = "11", visibleCol = true });
            spis.Add(new SetTab { Description = "Операция", Name = "Operation", width = 100, position = "12", visibleCol = false });
            spis.Add(new SetTab { Description = "Наименование", Name = "Name", width = 100, position = "13", visibleCol = false });
            spis.Add(new SetTab { Description = "Материал", Name = "Matnr", width = 100, position = "14", visibleCol = false });
            spis.Add(new SetTab { Description = "План", Name = "Plan", width = 100, position = "15", visibleCol = true });
            spis.Add(new SetTab { Description = "Факт", Name = "Fact", width = 100, position = "16", visibleCol = false });
            spis.Add(new SetTab { Description = "Брак", Name = "Brak", width = 100, position = "17", visibleCol = false });
            spis.Add(new SetTab { Description = "План", Name = "Plan", width = 100, position = "18", visibleCol = false });
            spis.Add(new SetTab { Description = "Факт", Name = "Fact", width = 100, position = "19", visibleCol = false });
            spis.Add(new SetTab { Description = "Брак", Name = "Brak", width = 100, position = "20", visibleCol = true });
            spis.Add(new SetTab { Description = "Заказ", Name = "Order", width = 100, position = "31", visibleCol = false });
            spis.Add(new SetTab { Description = "Операция", Name = "Operation", width = 100, position = "32", visibleCol = false });
            spis.Add(new SetTab { Description = "Наименование", Name = "Name", width = 100, position = "33", visibleCol = false });
            spis.Add(new SetTab { Description = "Материал", Name = "Matnr", width = 100, position = "34", visibleCol = false });
            spis.Add(new SetTab { Description = "План", Name = "Plan", width = 100, position = "35", visibleCol = false });
            spis.Add(new SetTab { Description = "Факт", Name = "Fact", width = 100, position = "36", visibleCol = false });
            spis.Add(new SetTab { Description = "Брак", Name = "Brak", width = 100, position = "37", visibleCol = false });
            spis.Add(new SetTab { Description = "План", Name = "Plan", width = 100, position = "38", visibleCol = false });
            spis.Add(new SetTab { Description = "Факт", Name = "Fact", width = 100, position = "39", visibleCol = false });
            spis.Add(new SetTab { Description = "Брак", Name = "Brak", width = 100, position = "40", visibleCol = false });
            return spis;
        }
    }
}