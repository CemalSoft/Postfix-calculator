using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PostfixHesaplayici
{
    static void postfixCalculate(string postfixIfade)
    {
        Stack<int> stack = new Stack<int>();

        string[] elements = postfixIfade.Split(' ');

        foreach (string element in elements)
        {
            if (int.TryParse(element, out int operand))
            {
                stack.Push(operand);
            }
            else
            {
                if (stack.Count < 2)
                {
                    Console.WriteLine("Insufficient number of operands");
                    return;
                }

                int operand2 = stack.Pop();
                int operand1 = stack.Pop();

                switch (element)
                {
                    case "+":
                        stack.Push(operand1 + operand2);
                        break;
                    case "-":
                        stack.Push(operand1 - operand2);
                        break;
                    case "*":
                        stack.Push(operand1 * operand2);
                        break;
                    case "/":
                        if (operand2 == 0)
                        {
                            Console.WriteLine("Not divisible by zero");
                            return;
                        }
                        stack.Push(operand1 / operand2);
                        break;
                    default:
                        Console.WriteLine("Invalid operator usage");
                        return;
                }
            }
        }

        if (stack.Count != 1)
        {
            Console.WriteLine("Number of missing operators");
            return;
        }

        Console.WriteLine("Result: " + stack.Pop());

    }

    static void Main()
    {
        Console.Write("Enter the Postfix expression: ");
        string postfixExpression = Console.ReadLine();

        postfixCalculate(postfixExpression);

        Console.ReadLine();
    }
}