namespace Alpaca.Web.CoreAlertTool.Models.ViewModel
{
    public class V_AlertList
    {
        public List<Alpaca.Web.CoreAlertTool.Models.AlertInfo> AlertInfoList { get; set; } = new List<Alpaca.Web.CoreAlertTool.Models.AlertInfo>();

        public List<Alpaca.Web.CoreAlertTool.Models.AlertType> AlertTypeList { get; set; } = new List<AlertType>();
    }
}
