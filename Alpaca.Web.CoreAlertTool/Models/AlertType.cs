using System.ComponentModel.DataAnnotations;
namespace Alpaca.Web.CoreAlertTool.Models
{
    public class AlertType
    {
        [Key]
        [Required]
        public int AlertTypeId { get; set; }

        [Required]
        public string AlertTypeName { get; set; }
    }
}
