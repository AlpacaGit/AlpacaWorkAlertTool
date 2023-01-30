using Alpaca.Web.CoreAlertTool.Data;
using System.Web;
namespace Alpaca.Web.CoreAlertTool.Common
{
    public static class Util
    {

        public static bool WriteLog(ApplicationDbContext context, HttpContext httpContext,Common.ConstInfo.PageId pageId,string detail = "")
        {
            bool ret = false;

            Alpaca.Web.CoreAlertTool.Models.ControlLog controlLog = new Models.ControlLog();

            int logCount = context.ControlLog.Count() + 1;
            controlLog.ControlDateTime = DateTime.Now;
            controlLog.SessionID = httpContext.Connection.Id;
            controlLog.LogType = 1;
            controlLog.PageID = (int)pageId;
            controlLog.LogDetail = detail;
            context.Add(controlLog);
            context.SaveChanges();
            return ret; ;
        }

        public static bool IsTimeStr(Models.AlertInfo alertInfo)
        {
            bool ret = false;

            string aStrDateTime = DateTime.Now.ToString("yyyy/MM/dd ");
            //4桁時刻
            if(alertInfo.AlertTime.Length == 4)
            {
                aStrDateTime += alertInfo.AlertTime.Substring(0, 2);
                aStrDateTime += ":";
                aStrDateTime += alertInfo.AlertTime.Substring(2, 2);
            }
            else if(alertInfo.AlertTime.Length == 5)
            {
                aStrDateTime += alertInfo.AlertTime;
            }
            aStrDateTime += ":00";
            DateTime convertDateTime;
            ret = DateTime.TryParse(aStrDateTime, out convertDateTime);

            if (ret)
            {
                alertInfo.AlertTime = convertDateTime.ToString("HH:mm");
            }

            return ret;
        }
    }
}
