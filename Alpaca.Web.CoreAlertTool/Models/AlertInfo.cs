using System.ComponentModel.DataAnnotations;
namespace Alpaca.Web.CoreAlertTool.Models
{
    public class AlertInfo
    {
        /// <summary>
        /// アラートID
        /// </summary>
        [Key]
        public string AlertId { get; set; }

        /// <summary>
        /// 鳴動時刻 hhMM
        /// </summary>
        public string AlertTime { get; set; }

        /// <summary>
        /// アラート名称
        /// </summary>
        public string AlertName { get; set; }
        /// <summary>
        /// アラート種別
        /// </summary>
        public int AlertType { get; set; }

    }
}
