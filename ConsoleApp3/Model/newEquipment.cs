using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Model
{
    [Table("newEquipment")]
    public class newEquipment
    {
        [Key]
        public int intEquipmentID { get; set; }
        public int intModelID { get; set; }
       // public virtual TablesModel TablesModel { get; set; }
        public virtual ICollection<TrackEvaluation> TrackEvaluation { get; set; }
    }
}
