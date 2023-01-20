using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Alpaca.Web.CoreAlertTool.Models
{
    /// <summary>
    /// 操作ログ
    /// </summary>
    public class ControlLog
    {
        [Key]
        [Required]
        public long RecId { get; set; }

        [Required]
        public DateTime ControlDateTime { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LogType { get; set; }

        [Required]
        public string SessionID { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PageID { get; set; }

        public string LogDetail { get; set; }
    }
}
