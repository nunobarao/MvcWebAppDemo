using System.Data.Entity;

namespace MvcWebApp.Models
{
    public class MvcWebAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MvcWebAppContext() : base("name=MvcWebAppContext")
        {
        }

        public System.Data.Entity.DbSet<MvcWebApp.Models.Produto> Produto { get; set; }

        public System.Data.Entity.DbSet<MvcWebApp.Models.Companhia> Companhias { get; set; }
    }
}
