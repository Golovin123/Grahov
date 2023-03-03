
class Calculator
{
    public static double DoOperation(double num1, double num2, string op)
    {
        double result = double.NaN; // Значение по умолчанию - это не число, которое мы используем, если операция, такая как деление, может привести к ошибке.

        // Используйте оператор switch для выполнения математических расчетов.
        switch (op)
        {
            case "с":
                result = num1 + num2;
                break;
            case "р":
                result = num1 - num2;
                break;
            case "у":
                result = num1 * num2;
                break;
            case "д":
                // Попросите пользователя ввести ненулевой делитель.
                if (num2 != 0)
                {
                    result = num1 / num2;
                }
                break;
            // Возвращает текст для ввода неправильного параметра.
            default:
                break;
        }
        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        bool endApp = false;
        // Отображать заголовок как приложение консольного калькулятора C#.
        Console.WriteLine("Приложение консольного калькулятора C#\r");
        Console.WriteLine("------------------------\n");

        while (!endApp)
        {
            // Объявите переменные и установите значение empty.
            string numInput1 = "";
            string numInput2 = "";
            double result = 0;

            // Попросите пользователя ввести первое число.
            Console.Write("Введите число A, а затем нажмите Enter: ");
            numInput1 = Console.ReadLine();

            double cleanNum1 = 0;
            while (!double.TryParse(numInput1, out cleanNum1))
            {
                Console.Write("Это недопустимый ввод. Пожалуйста, введите целое значение: ");
                numInput1 = Console.ReadLine();
            }

            // Попросите пользователя ввести второй номер.
                        Console.Write("Введите число B, а затем нажмите Enter: ");
            numInput2 = Console.ReadLine();

            double cleanNum2 = 0;
            while (!double.TryParse(numInput2, out cleanNum2))
            {
                Console.Write("Это недопустимый ввод. Пожалуйста, введите целое значение: ");
                numInput2 = Console.ReadLine();
            }

            // Попросите пользователя выбрать оператора.
            Console.WriteLine("Выберите оператора из следующего списка:");
            Console.WriteLine("\tс - Сложить");
            Console.WriteLine("\tр - Разность");
            Console.WriteLine("\tу - Умножить");
            Console.WriteLine("\tр - Разделить");
            Console.Write("Ваш выбор? ");

            string op = Console.ReadLine();

            try
            {
                result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                if (double.IsNaN(result))
                {
                    Console.WriteLine("Эта операция приведет к математической ошибке.\n");
                }
                else Console.WriteLine("Ваш результат: {0:0.##}\n", result);
            }
            catch (Exception e)
            {
                Console.WriteLine("О, нет! При попытке выполнить математические вычисления возникло исключение.\n - Подробности: " + e.Message);
            }

            Console.WriteLine("------------------------\n");

            // Дождитесь ответа пользователя перед закрытием.
            Console.Write("Нажмите \"n\" и Enter, чтобы закрыть приложение, или нажмите любую другую клавишу и Enter, чтобы продолжить: ");
            if (Console.ReadLine() == "n") endApp = true;

            Console.WriteLine("\n"); // Дружественное пространство строк.
        }
        return;
    }
}