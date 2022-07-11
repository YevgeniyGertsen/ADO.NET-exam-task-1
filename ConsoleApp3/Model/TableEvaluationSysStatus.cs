using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Model
{
    [Table("TableEvaluationSysStatus")]
    public class TableEvaluationSysStatus
    {
        [Key]
        public int intEvaluationSysStatusId { get; set; }
        public string strStatysName { get; set; }

       // public virtual  ICollection<TrackEvaluation> TrackEvaluation { get; set; }
    }
}
