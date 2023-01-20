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
    }
}
