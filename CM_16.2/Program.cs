using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace CM_16._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonString = String.Empty;
            using (StreamReader sr = new StreamReader("../../../Products.json"))
            {
                jsonString = sr.ReadToEnd();
            }
            Good[] goods = JsonSerializer.Deserialize<Good[]>(jsonString);

            Good maxGood = goods[0];
            foreach (Good e in goods)
            {
                if (e.Summa > maxGood.Summa)
                {
                    maxGood = e;
                }
            }
            Console.WriteLine($"Самая высокая стоимость у товара - {maxGood.Name}");
            Console.ReadKey();

        }
    }
}
