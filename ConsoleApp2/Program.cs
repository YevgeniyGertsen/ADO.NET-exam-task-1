using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            practiceEntities db = new practiceEntities();

            db.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));

            db.Database.Log = Console.Write;

           var data55 = db.GetEquipmentByGarageRoom("108").ToList();

            //загрузка всех машин и связанных с ними моделей
            //жадная загружка
            List<newEquipment> equipments =
                db.newEquipment
                .Include("TableEquipmentHistory")
                .ToList();//1 запрос к БД

            //получим все машины 
            var query_3 = equipments
                .SelectMany(s => s.TableEquipmentHistory)
                //запрос к бд не выполняется
                //т.к. данные уже были извлечены
                //ранее с помощью прямой загрузки
                .ToList();



            //Явная загрузка (explicity loading)
            var query_1 = db.newEquipment
                .FirstOrDefault(f => f.intEquipmentID == 98);//1

            db.Entry(query_1)
                .Collection(m => m.TableEquipmentHistory)
                .Load();//2

            foreach (var item in query_1.TableEquipmentHistory)//-
            {
                //some code
            }

          


            var data = db.newEquipment.ToList(); // 1запрос  к БД
            foreach (newEquipment item in data)
            {
                if(item.intGarageRoom == "55")
                {
                  
                    //Console.WriteLine(count);
                }                
            }//+25 запросов к БД

            int count = data.First().TableEquipmentHistory.Count();
        }
    }
}
