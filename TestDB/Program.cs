using System;
using System.Linq;

namespace TestDB
{
    class Program
    {
        static void Main()
        {
            /*DateTime startDate = new DateTime(2015, 5, 20);
            DateTime closeDate = new DateTime(2015, 7, 20);
            string q = startDate.ToString("MMM") + "qwe";
            closeDate.AddYears(-18);
            Console.WriteLine(closeDate.AddYears(-18));
            AbstractPolis qwe = new AbstractPolis();*/

            using (ApplicationContext datab = new ApplicationContext())
            {
                int num = datab.Policies.Count();
                Console.WriteLine(num);

                // создаем два объекта
                AbstractPolicy policy1 = new AbstractPolicy(DateTime.Now, DateTime.Now.AddDays(31), ++num, "Alex", "Pichuev", new DateTime(1997, 8, 28), "MyLife","Life");

                // добавляем их в бд
                datab.Policies.Add(policy1);


                datab.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var policies = datab.Policies.ToList();
                Console.WriteLine("Список объектов:");
                foreach (AbstractPolicy p in policies)
                {
                    Console.WriteLine($"{p.number}-{p.startDate}-{p.closeDate}-{p.lastUpdate}-{p.ownerName}-{p.ownerSurname}-{p.birthDate}-{p.insuredObjectName}-{p.insuredObjectType}");
                }
            }
        }

        
    }
}
