using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alpaca.Web.CoreAlertTool.Models
{
    public class M_Page
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PageId { get; set; }

        [Required]
        public string PageName { get; set; }
    }
}
