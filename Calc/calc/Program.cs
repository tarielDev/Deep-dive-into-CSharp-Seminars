namespace calc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {

                List<string> argumentsList = args.ToList();

                //Кол-во всех операций в выражении
                int operCount = argumentsList.Where(x => x.Contains('*') || x.Contains('/') || x.Contains('+') || x.Contains('-')).Count();
                double result;

                for (int i = 0; i < operCount; i++)
                {
                    //Определение первой самой операции (/ или *)
                    string? oper = argumentsList.FirstOrDefault(x => x.Contains('*') || x.Contains('/'));
                    //Определение номера элемента операции (/ или *)
                    int index = argumentsList.Select((arg, i) => new { Argument = arg, Index = i })
                            .FirstOrDefault(x => x.Argument.Contains('*') || x.Argument.Contains('/'))?.Index ?? -1;

                    if (oper == null)
                    {
                        //Определение первой самой операции (+ или -)
                        oper = argumentsList.FirstOrDefault(x => x.Contains('+') || x.Contains('-'));
                        //Определение номера элемента операции (+ или -)
                        index = argumentsList.Select((arg, i) => new { Argument = arg, Index = i })
                                .FirstOrDefault(x => x.Argument.Contains('+') || x.Argument.Contains('-'))?.Index ?? -1;

                    }

                    switch (oper)
                    {
                        case "/":
                            //Результат операции
                            result = Convert.ToDouble(argumentsList[index - 1]) / Convert.ToDouble(argumentsList[index + 1]);
                            //Результат помещается вместо исполненной операции
                            argumentsList[index] = result.ToString();
                            //Удаляется элемент первого операнда
                            argumentsList.RemoveAt(index - 1);
                            //Удаляется элемент второго операнда
                            argumentsList.RemoveAt(index);

                            break;

                        case "*":
                            result = Convert.ToDouble(argumentsList[index - 1]) * Convert.ToDouble(argumentsList[index + 1]);
                            argumentsList[index] = result.ToString();
                            argumentsList.RemoveAt(index - 1);
                            argumentsList.RemoveAt(index);

                            break;

                        case "+":
                            result = Convert.ToDouble(argumentsList[index - 1]) + Convert.ToDouble(argumentsList[index + 1]);
                            argumentsList[index] = result.ToString();
                            argumentsList.RemoveAt(index - 1);
                            argumentsList.RemoveAt(index);

                            break;

                        case "-":
                            result = Convert.ToDouble(argumentsList[index - 1]) - Convert.ToDouble(argumentsList[index + 1]);
                            argumentsList[index] = result.ToString();
                            argumentsList.RemoveAt(index - 1);
                            argumentsList.RemoveAt(index);

                            break;

                    }

                }
                //Последний оставщийся результат выполнения
                result = Convert.ToDouble(argumentsList[0]);
                Console.WriteLine(String.Join(" ", args) + " = " + result.ToString());
            }
            else
            {
                Console.WriteLine("args isn't available!");
            }

        }

    }
}