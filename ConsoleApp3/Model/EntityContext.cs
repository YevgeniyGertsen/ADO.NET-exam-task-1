using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Model
{

    public class EntityContext : DbContext
    {
        public EntityContext() : base("DefaultConnection")
        {
          
        }

        public virtual DbSet<TrackEvaluation> TrackEvaluation { get; set; }
        public virtual DbSet<TableEvaluationSysStatus> TableEvaluationSysStatuses { get; set; }
        public virtual DbSet<newEquipment> newEquipments { get; set; }
        public virtual DbSet<TablesModel> TablesModels { get; set; }
    }     
}
