using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MaerskLineGroup.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserTokenCache> UserTokenCacheList { get; set; }

        public System.Data.Entity.DbSet<MaerskLineGroup.Models.Ship> Ships { get; set; }

        public System.Data.Entity.DbSet<MaerskLineGroup.Models.Shipyard> Shipyards { get; set; }

        public System.Data.Entity.DbSet<MaerskLineGroup.Models.Transportation> Transportations { get; set; }

        public System.Data.Entity.DbSet<MaerskLineGroup.Models.Warehouse> Warehouses { get; set; }

        public System.Data.Entity.DbSet<MaerskLineGroup.Models.Container> Containers { get; set; }
    }

    public class UserTokenCache
    {
        [Key]
        public int UserTokenCacheId { get; set; }
        public string webUserUniqueId { get; set; }
        public byte[] cacheBits { get; set; }
        public DateTime LastWrite { get; set; }
    }
}