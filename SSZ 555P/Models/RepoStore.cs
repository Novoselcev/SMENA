using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSZ.Models
{
   static public class RepoStore
    {
      public static  List<SuboperationsModel> SubOper;
      public static  List<NormDocumentModel> NorDoc;
      public static  List<VPSModel> VPS;
      public static  List<ComponentsModel> MatIput;
      public static string objID;
      public static List<SszModel> temp; 
    }
}