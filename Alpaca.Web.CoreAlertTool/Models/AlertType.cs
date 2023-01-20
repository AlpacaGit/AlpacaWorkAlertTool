using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alpaca.Web.CoreAlertTool.Models
{
    public class AlertType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AlertTypeId { get; set; }

        [Required]
        public string AlertTypeName { get; set; }
    }
}
