using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Model
{
    [Table("TrackEvaluation")]
    public class TrackEvaluation
    {
        [Key]
        public int intEvalutionId { get; set; }

        public int? intEvalutionNumber { get; set; }
        public DateTime? dCreateDate { get; set; }
        public string strSalesOrderNumber { get; set; }
        public DateTime? dConfirmDate { get; set; }
        public DateTime? dDateOfSale { get; set; }
        public DateTime? dEstimatedDateArrival { get; set; }
        public DateTime? dArrivalDate { get; set; }
        public double? floatETTR { get; set; }
        public double? floatELTR { get; set; }
        public int? intEquipmentID { get; set; }

        //public virtual TableEvaluationSysStatus TableEvaluationSysStatus { get; set; }
        public virtual newEquipment newEquipment { get; set; }
    }
}
