using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace CM_16
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;
            Good[] goods = new Good[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите код товара");
                int num = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите наименование");
                string name = Console.ReadLine();
                Console.WriteLine("Введите стоимость");
                double summa = Convert.ToDouble(Console.ReadLine());

                goods[i] = new Good() { Num = num, Name = name, Summa = summa };
            }
                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };

                string jsonString = JsonSerializer.Serialize(goods, options);
                using (StreamWriter sw = new StreamWriter("../../../Products.json"))
                {
                    sw.WriteLine(jsonString);
                }
        }
    }
}
