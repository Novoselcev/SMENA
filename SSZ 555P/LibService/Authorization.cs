using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSZ.LibService
{
    public class Authorization
    {
        public bool CheckTabNuber(string tabNumber, string Langv, string connectSap)
        {
            bool rezult=true;
           try
            {
                GetOperService.YSFC_GET_OPERATIONS_LIST serv = new GetOperService.YSFC_GET_OPERATIONS_LIST(connectSap);
             

                GetOperService.YsfcGetOperationsListWs oper = new GetOperService.YsfcGetOperationsListWs();
                // задает входной параметр, табельный номер
              /*  oper.IPernr = tabNumber.Trim();
                oper.ILangu = Langv.Trim();
                oper.IPlant = "1101";*/
                // получаем ответ по заданому параметру
                GetOperService.YsfcGetOperationsListWsResponse response1 = new GetOperService.YsfcGetOperationsListWsResponse();
                response1 = serv.YsfcGetOperationsListWs(oper);
           }
          catch (Exception ex)
            {
                string mes = ex.Message;
                rezult = false;
            }
            return rezult;

        }
    }
}