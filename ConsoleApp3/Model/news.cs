using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Model
{
    [Table("news")]
    public class news
    {
        public int newsId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string category { get; set; }
    }
}
