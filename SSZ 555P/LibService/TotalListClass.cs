using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSZ.Models;
using SSZ.GetStatistics;

namespace SSZ.LibService
{
    public class TotalListClass
    {
        public YSFC_GET_STATISTICS GET_STATISTICS;
        String ILD;
        public String URL;
        public String Error;
        // конструктор класса
        public TotalListClass(string ild, string sysSap)
        {
            ILD = ild;
            GET_STATISTICS = new YSFC_GET_STATISTICS(sysSap);
        }


        //Получаем расчетный листок
        public List<YafvcStatis2Ws> GetStat(string date)
        {
            YsfcGetStatisticsWs zpr = new YsfcGetStatisticsWs();
            zpr.IId = ILD;
            zpr.IPeriod = date;
            YsfcGetStatisticsWsResponse responce = new YsfcGetStatisticsWsResponse();
            responce = GET_STATISTICS.YsfcGetStatisticsWs(zpr);
            List<YafvcStatis2Ws> list = responce.EtStatDataWs.ToList<YafvcStatis2Ws>();
            URL = responce.EPayslipUrl;
            return list;
        }

       

    } 
}