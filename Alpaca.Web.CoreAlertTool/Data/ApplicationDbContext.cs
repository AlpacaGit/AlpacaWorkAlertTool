using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Alpaca.Web.CoreAlertTool.Models;

namespace Alpaca.Web.CoreAlertTool.Data
{
    /// <summary>
    /// DBContextクラス。
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Alpaca.Web.CoreAlertTool.Models.AlertInfo> AlertInfo { get; set; }
    }
}