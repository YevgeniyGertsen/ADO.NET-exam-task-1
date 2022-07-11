using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ConsoleApp1
{
    public partial class EntityDataModel : DbContext
    {
        public EntityDataModel()
            : base("name=EntityDataModel")
        {
        }

        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<newEquipment> newEquipment { get; set; }
        public virtual DbSet<TableEquipmentHistory> TableEquipmentHistory { get; set; }
        public virtual DbSet<TablesManufacturer> TablesManufacturer { get; set; }
        public virtual DbSet<TablesModel> TablesModel { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>()
                .Property(e => e.IP)
                .IsUnicode(false);

            modelBuilder.Entity<TablesManufacturer>()
                .HasMany(e => e.newEquipment)
                .WithRequired(e => e.TablesManufacturer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TablesModel>()
                .HasMany(e => e.newEquipment)
                .WithRequired(e => e.TablesModel)
                .WillCascadeOnDelete(false);
        }
    }
}
