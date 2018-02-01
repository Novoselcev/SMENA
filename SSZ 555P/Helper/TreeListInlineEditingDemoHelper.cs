using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using DevExpress.Web.ASPxTreeList;
using SSZ.Models;

namespace SSZ.Helper
{
    public class TreeListInlineEditingDemoHelper
    {
        public static DefectOZM GetEditedPost(TreeListEditFormTemplateContainer container)
        {
            return new DefectOZM
            {
                Aflst = (string)DataBinder.Eval(container.DataItem, "Aflst"),
                Anzfehler = (string)DataBinder.Eval(container.DataItem, "Anzfehler"),
                Bautl = (string)(DataBinder.Eval(container.DataItem, "Bautl") ),
                BautlTxt = (string)DataBinder.Eval(container.DataItem, "BautlTxt"),
                FlgMark = (string)DataBinder.Eval(container.DataItem, "FlgMark"),
                Fmgeig = (string)DataBinder.Eval(container.DataItem, "Fmgeig"),
                Fmgein = (string)DataBinder.Eval(container.DataItem, "Fmgein"),
                ID = (Int32)DataBinder.Eval(container.DataItem, "ID"),
                ID_parent = (Int32)DataBinder.Eval(container.DataItem, " ID_parent"),
                Posnr = (string)DataBinder.Eval(container.DataItem, "Posnr"),
                Prueflinr = (string)DataBinder.Eval(container.DataItem, "Prueflinr"),


            };
        }
    }
}