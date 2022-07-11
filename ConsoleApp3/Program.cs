using ConsoleApp3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static EntityContext db = new EntityContext();

        static void Main(string[] args)
        {

            var data = db.TrackEvaluation.ToList();

            GetData();
        }

        public static List<TrackEvaluation> GetData()
        {
            var data = db.TrackEvaluation
                 //.Include("TableEvaluationSysStatus")
                 //.Include("newEquipment")
                 .ToList();

            return data;
        }
    }
}
