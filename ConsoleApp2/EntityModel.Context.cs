﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApp2
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class practiceEntities : DbContext
    {
        public practiceEntities()
            : base("name=practiceEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<newEquipment> newEquipment { get; set; }
        public virtual DbSet<TableEquipmentHistory> TableEquipmentHistory { get; set; }
        public virtual DbSet<TablesManufacturer> TablesManufacturer { get; set; }
        public virtual DbSet<TablesModel> TablesModel { get; set; }
    
        [DbFunction("practiceEntities", "GetEquipmentByGarageRoom")]
        public virtual IQueryable<GetEquipmentByGarageRoom_Result> GetEquipmentByGarageRoom(string intGarageRoom)
        {
            var intGarageRoomParameter = intGarageRoom != null ?
                new ObjectParameter("intGarageRoom", intGarageRoom) :
                new ObjectParameter("intGarageRoom", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<GetEquipmentByGarageRoom_Result>("[practiceEntities].[GetEquipmentByGarageRoom](@intGarageRoom)", intGarageRoomParameter);
        }
    }
}
