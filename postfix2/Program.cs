using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PostfixHesaplayici
{
    static void PostfixHesapla(string postfixIfade)
    {
        Stack<int> yigin = new Stack<int>();

        string[] elemanlar = postfixIfade.Split(' ');

        foreach (string eleman in elemanlar)
        {
            if (int.TryParse(eleman, out int operand))
            {
                yigin.Push(operand);
            }
            else
            {
                if (yigin.Count < 2)
                {
                    Console.WriteLine("Yetersiz operand sayisi");
                    return;
                }

                int operand2 = yigin.Pop();
                int operand1 = yigin.Pop();

                switch (eleman)
                {
                    case "+":
                        yigin.Push(operand1 + operand2);
                        break;
                    case "-":
                        yigin.Push(operand1 - operand2);
                        break;
                    case "*":
                        yigin.Push(operand1 * operand2);
                        break;
                    case "/":
                        if (operand2 == 0)
                        {
                            Console.WriteLine("Sıfıra bölünmez");
                            return;
                        }
                        yigin.Push(operand1 / operand2);
                        break;
                    default:
                        Console.WriteLine("Geçersiz operatör kullanimi");
                        return;
                }
            }
        }

        if (yigin.Count != 1)
        {
            Console.WriteLine("Eksik operatör sayısı");
            return;
        }

        Console.WriteLine("Sonuç: " + yigin.Pop());

    }

    static void Main()
    {
        Console.Write("Postfix ifadesi giriniz: ");
        string postfixIfade = Console.ReadLine();

        PostfixHesapla(postfixIfade);

        Console.ReadLine();
    }
}