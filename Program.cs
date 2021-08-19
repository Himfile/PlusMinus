using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasMinus //Расставить знаки +- между цифрами числа так, чтобы получить sum.
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите число");
                string dig = Console.ReadLine();
                int ldig = dig.Length - 1;
                Console.Write("Вы ввели число: " + dig);

                int sum = 0; // Искомое значение выражений
                int count = 0; // Счетчик количества выражений
                int p = 0; // Счетчик искомых выражений
                int q; // Переменная для первой цифры и нарастания остатка в одном выражении
                int maxc; // Максимальное число комбинаций знаков

                // Найдем maxc 
                string btn = ""; //Составим двоичный код числа. Он будет соответствовать
                                 //количеству расстановок знаков между цифрами.
                while (ldig > 0)
                {
                    btn += "1";
                    ldig--;
                }
                maxc = Convert.ToInt32(btn, 2);  //Количество комбинаций знаков в выражении

                // Представим число dig в иде массива цифр
                int[] c = new int[dig.Length];
                for (int i = 0; i < dig.Length; i++)
                    c[i] = int.Parse(dig[i].ToString());

                Console.WriteLine(". Расставим знаки +- между цифр. ");
                Console.WriteLine("Получили выражений: " + (maxc + 1));
                Console.WriteLine("Найдем выражение с результатом  " + sum + "");

                for (int i = 0; i <= maxc; i++) // Составляем все возможные комбинации знаков
                {
                    int k = i; // Номер текущего выражения из общего числа комбинаций maxc
                    q = c[0]; // Исходное значение первой цифры числа dig
                              //Console.WriteLine(k);

                    // Первую  цифру числа dig последовательно увеличиваем(уменьшаем)
                    // на значение следующих цифр с нарастающим остатком
                    for (int j = 1; j < c.Length; j++)
                    {
                        //Console.Write("\t" + k%2 + " - %2     ");

                        //q = X(q, c[j], k % 2);
                        if (k % 2 == 0) q += c[j];
                        else q -= c[j];
                        k >>= 1; // Операция смещения на 1 бит для чередования знаков в выражении
                                 //  (равняется количеству целых (1*2) двоек в числе)
                                 //Console.WriteLine("      >> " + k );
                    }
                    count++;
                    //Выведем выражения на экран
                    if (q == sum)
                    {
                        p++;
                    Console.Write(count + ")\t");
                    Console.Write(c[0].ToString());
                    k = i;
                    for (int j = 1; j < c.Length; j++)
                    {
                        string s = ""; // Знаковая переменная
                        if (k % 2 == 0) s = "+";
                        else s = "-";
                        Console.Write(s + c[j].ToString());
                        k >>= 1;
                    }
                    Console.WriteLine("=" + q.ToString());
                    }
                }
                Console.WriteLine();
                if (p == 0) Console.WriteLine("Искомая комбинация не найдена.");
                else Console.WriteLine("Найдено " + p);
                Console.ReadKey(true);
            }
            catch { };
        }
    }
}
