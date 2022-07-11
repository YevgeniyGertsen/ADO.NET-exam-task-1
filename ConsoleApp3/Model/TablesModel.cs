using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Model
{
    [Table("TablesModel")]
    public class TablesModel
    {
        [Key]
        public int intModelID { get; set; }
        public string strName { get; set; }
       // public virtual ICollection<newEquipment> newEquipment { get; set; }
    }
}
