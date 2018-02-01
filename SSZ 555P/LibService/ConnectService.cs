using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSZ.LibService
{
    public class ConnectService
    {

        string systemSap = "";

        public ConnectService(string conn)
        {
            systemSap = conn;
        }


        public string get_facade()
        {
            string UrlSrv = "";

            switch (systemSap)
            {
                case "AZQ":
                    UrlSrv = "http://erp-qa.sapfir.local:8000/sap/bc/srt/rfc/sap/ygui_get_facade_metadata_webs/555/ygui_get_facade_metadata/ygui_get_facade_metadata_bind";
                        break;
                case "AZD":
                    UrlSrv = "http://erp-dev.sapfir.local:8000/sap/bc/srt/rfc/sap/ygui_get_facade_metadata_webs/400/ygui_get_facade_metadata/ygui_get_facade_metadata_bind";
                    break;
                case "AZP":
                    UrlSrv = "http://erp-prod.sapfir.local:8021/sap/bc/srt/rfc/sap/ygui_get_facade_metadata_webs/555/ygui_get_facade_metadata/ygui_get_facade_metadata_bind";
                    break;
                case "AZD100":
                    UrlSrv = "http://erp-dev.sapfir.local:8000/sap/bc/srt/rfc/sap/ygui_get_facade_metadata_webs/100/ygui_get_facade_metadata/ygui_get_facade_metadata_bind";
                    break;
            }

            return UrlSrv;
        }

        public string getOperDetail()
        {
            string UrlSrv = "";

            switch (systemSap)
            {
                case "AZQ":
                    UrlSrv = "http://erp-qa.sapfir.local:8000/sap/bc/srt/rfc/sap/ysfc_get_operation_detail_webs/555/ysfc_get_operation_detail/ysfc_get_operation_detail_bind";
                    break;
                case "AZD":
                    UrlSrv = "http://erp-dev.sapfir.local:8000/sap/bc/srt/rfc/sap/ysfc_get_operation_detail_webs/400/ysfc_get_operation_detail/ysfc_get_operation_detail_bind";
                    break;
                case "AZP":
                    UrlSrv = "http://erp-prod.sapfir.local:8021/sap/bc/srt/rfc/sap/ysfc_get_operation_detail_webs/555/ysfc_get_operation_detail/ysfc_get_operation_detail_bind";
                    break;
                case "AZD100":
                    UrlSrv = "http://erp-dev.sapfir.local:8000/sap/bc/srt/rfc/sap/ysfc_get_operation_detail_webs/100/ysfc_get_operation_detail/ysfc_get_operation_detail_bind";
                    break;

            }

            return UrlSrv;
        }

        public string getOperService()
        {
            string UrlSrv = "";

            switch (systemSap)
            {
                case "AZQ":
                    UrlSrv = "http://erp-qa.sapfir.local:8000/sap/bc/srt/rfc/sap/ysfc_get_operations_list_webs/555/ysfc_get_operations_list/ysfc_get_operations_list_bind";
                    break;
                case "AZD":
                    UrlSrv = "http://erp-dev.sapfir.local:8000/sap/bc/srt/rfc/sap/ysfc_get_operations_list_webs/400/ysfc_get_operations_list/ysfc_get_operations_list_bind";
                    break;
                case "AZP":
                    UrlSrv = "http://erp-prod.sapfir.local:8021/sap/bc/srt/rfc/sap/ysfc_get_operations_list_webs/555/ysfc_get_operations_list/ysfc_get_operations_list_bind";
                    break;
                case "AZD100":
                    UrlSrv = "http://erp-dev.sapfir.local:8000/sap/bc/srt/rfc/sap/ysfc_get_operations_list_webs/100/ysfc_get_operations_list/ysfc_get_operations_list_bind";
                    break;
            }

            return UrlSrv;
        }

        public string hit_List()
        {
            string UrlSrv = "";

            switch (systemSap)
            {
                case "AZQ":
                    UrlSrv = "http://erp-qa.sapfir.local:8000/sap/bc/srt/rfc/sap/ygui_get_f4help_hit_list_webs/555/ygui_get_f4help_hit_list/ygui_get_f4help_hit_list_bind";
                    break;
                case "AZD":
                    UrlSrv = "http://erp-dev.sapfir.local:8000/sap/bc/srt/rfc/sap/ygui_get_f4help_hit_list_webs/400/ygui_get_f4help_hit_list/ygui_get_f4help_hit_list_bind";
                    break;
                case "AZP":
                    UrlSrv = "http://erp-prod.sapfir.local:8021/sap/bc/srt/rfc/sap/ygui_get_f4help_hit_list_webs/555/ygui_get_f4help_hit_list/ygui_get_f4help_hit_list_bind";
                    break;
                case "AZD100":
                    UrlSrv = "http://erp-dev.sapfir.local:8000/sap/bc/srt/rfc/sap/ygui_get_f4help_hit_list_webs/100/ygui_get_f4help_hit_list/ygui_get_f4help_hit_list_bind";
                    break;
            }

            return UrlSrv;
        }

        public string pUT_OPERATION_TICKET()
        {
            string UrlSrv = "";

            switch (systemSap)
            {
                case "AZQ":
                    UrlSrv = "http://erp-qa.sapfir.local:8000/sap/bc/srt/rfc/sap/ysfc_put_operation_ticket_webs/555/ysfc_put_operation_ticket/ysfc_put_operation_ticket_bind";
                    break;
                case "AZD":
                    UrlSrv = "http://erp-dev.sapfir.local:8000/sap/bc/srt/rfc/sap/ysfc_put_operation_ticket_webs/400/ysfc_put_operation_ticket/ysfc_put_operation_ticket_bind";
                    break;
                case "AZP":
                    UrlSrv = "http://erp-prod.sapfir.local:8021/sap/bc/srt/rfc/sap/ysfc_put_operation_ticket_webs/555/ysfc_put_operation_ticket/ysfc_put_operation_ticket_bind";
                    break;
                case "AZD100":
                    UrlSrv = "http://erp-dev.sapfir.local:8000/sap/bc/srt/rfc/sap/ysfc_put_operation_ticket_webs/100/ysfc_put_operation_ticket/ysfc_put_operation_ticket_bind";
                    break;
            }

            return UrlSrv;
        }

        public string putNotification()
        {
            string UrlSrv = "";

            switch (systemSap)
            {
                case "AZQ":
                    UrlSrv = "http://erp-qa.sapfir.local:8000/sap/bc/srt/rfc/sap/ysfc_put_notification_webs/555/ysfc_put_notification/ysfc_put_notification_bind";
                    break;
                case "AZD":
                    UrlSrv = "http://erp-dev.sapfir.local:8000/sap/bc/srt/rfc/sap/ysfc_put_notification_webs/400/ysfc_put_notification/ysfc_put_notification_bind";
                    break;
                case "AZP":
                    UrlSrv = "http://erp-prod.sapfir.local:8021/sap/bc/srt/rfc/sap/ysfc_put_notification_webs/555/ysfc_put_notification/ysfc_put_notification_bind";
                    break;
                case "AZD100":
                    UrlSrv = "http://erp-dev.sapfir.local:8000/sap/bc/srt/rfc/sap/ysfc_put_notification_webs/100/ysfc_put_notification/ysfc_put_notification_bind";
                    break;
            }

            return UrlSrv;
        }

        public string resuseGrid()
        {
            string UrlSrv = "";

            switch (systemSap)
            {
                case "AZQ":
                    UrlSrv = "http://erp-qa.sapfir.local:8000/sap/bc/srt/rfc/sap/ygui_reuse_grid_variant_webs/555/ygui_reuse_grid_variant/ygui_reuse_grid_variant_bind";
                    break;
                case "AZD":
                    UrlSrv = "http://erp-dev.sapfir.local:8000/sap/bc/srt/rfc/sap/ygui_reuse_grid_variant_webs/400/ygui_reuse_grid_variant/ygui_reuse_grid_variant_bind";
                    break;
                case "AZP":
                    UrlSrv = "http://erp-prod.sapfir.local:8021/sap/bc/srt/rfc/sap/ygui_reuse_grid_variant_webs/555/ygui_reuse_grid_variant/ygui_reuse_grid_variant_bind";
                    break;
                case "AZD100":
                    UrlSrv = "http://erp-dev.sapfir.local:8000/sap/bc/srt/rfc/sap/ygui_reuse_grid_variant_webs/100/ygui_reuse_grid_variant/ygui_reuse_grid_variant_bind";
                    break;
            }

            return UrlSrv;
        }

        public string sessionSap()
        {
            string UrlSrv = "";

            switch (systemSap)
            {
                case "AZQ":
                    UrlSrv = "http://erp-qa.sapfir.local:8000/sap/bc/srt/rfc/sap/ygui_handle_pernr_session_webs/555/ygui_handle_pernr_session/ygui_handle_pernr_session_bind";
                    break;
                case "AZD":
                    UrlSrv = "http://erp-dev.sapfir.local:8000/sap/bc/srt/rfc/sap/ygui_handle_pernr_session_webs/400/ygui_handle_pernr_session/ygui_handle_pernr_session_bind";
                    break;
                case "AZP":
                    UrlSrv = "http://erp-prod.sapfir.local:8021/sap/bc/srt/rfc/sap/ygui_handle_pernr_session_webs/555/ygui_handle_pernr_session/ygui_handle_pernr_session_bind";
                    break;
                case "AZD100":
                    UrlSrv = "http://erp-dev.sapfir.local:8000/sap/bc/srt/rfc/sap/ygui_handle_pernr_session_webs/100/ygui_handle_pernr_session/ygui_handle_pernr_session_bind";
                    break;
            }

            return UrlSrv;
        }

        public string GetStatistic()
        {
            string UrlSrv = "";

            switch (systemSap)
            {
                case "AZQ":
                    UrlSrv = "http://erp-qa.sapfir.local:8000/sap/bc/srt/rfc/sap/ysfc_get_statistics_webs/555/ysfc_get_statistics/ysfc_get_statistics_bind";
                    break;
                case "AZD":
                    UrlSrv = "http://erp-dev.sapfir.local:8000/sap/bc/srt/rfc/sap/ysfc_get_statistics_webs/400/ysfc_get_statistics/ysfc_get_statistics_bind";
                    break;
                case "AZP":
                    UrlSrv = "http://erp-prod.sapfir.local:8021/sap/bc/srt/rfc/sap/ysfc_get_statistics_webs/555/ysfc_get_statistics/ysfc_get_statistics_bind";
                    break;
                case "AZD100":
                    UrlSrv = "http://erp-dev.sapfir.local:8000/sap/bc/srt/rfc/sap/ysfc_get_statistics_webs/100/ysfc_get_statistics/ysfc_get_statistics_bind";
                    break;
            }

            return UrlSrv;
        }

        public string GetNotif()
        {
            string UrlSrv = "";

            switch (systemSap)
            {
                case "AZQ":
                    UrlSrv = "http://erp-qa.sapfir.local:8000/sap/bc/srt/rfc/sap/ysfc_get_notif_pro_items_webs/555/ysfc_get_notif_pro_items/ysfc_get_notif_pro_items_bind";
                    break;
                case "AZD":
                    UrlSrv = "http://erp-dev.sapfir.local:8000/sap/bc/srt/rfc/sap/ysfc_get_notif_pro_items_webs/400/ysfc_get_notif_pro_items/ysfc_get_notif_pro_items_bind";
                    break;
                case "AZP":
                    UrlSrv = "http://erp-prod.sapfir.local:8021/sap/bc/srt/rfc/sap/ysfc_get_notif_pro_items_webs/555/ysfc_get_notif_pro_items/ysfc_get_notif_pro_items_bind";
                    break;
                case "AZD100":
                    UrlSrv = "http://erp-dev.sapfir.local:8000/sap/bc/srt/rfc/sap/ysfc_get_notif_pro_items_webs/100/ysfc_get_notif_pro_items/ysfc_get_notif_pro_items_bind";
                    break;
            }

            return UrlSrv;
        }
    }
}