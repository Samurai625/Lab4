using System;
class Program
{
    static void Main()
    {
        int[] F = ChooseM();
        Print(F);
        var result = FindMinAndLastIndex(F);
        Console.WriteLine($"Мінімальне значення в масиві: {result.minValue}");
        Console.WriteLine($"Індекс останнього мінімального числа: {result.lastIndex}");
        int[] ElementAftenMin = GetElementAften(F, result.lastIndex);
        Console.WriteLine("Елементи після останнього мінімального числа:");
        Print(ElementAftenMin);
        long multiply = CalculateMultiply(ElementAftenMin);
        Console.WriteLine($"Добуток елементів після останнього мінімального: {multiply}");
    }
    static int[] ChooseM()
    {
        Console.WriteLine("Виберіть метод заповнення масиву (випадково/вручну): ");
        string mode = Console.ReadLine().Trim().ToLower();// Trim() - пробіли, ToLower() - реєстр букв.

        switch (mode)
        {
            case "випадково":
                return Random();
            case "вручну":
                return Hand();
            default:
                Console.WriteLine("Невірний вибір.Спробуйте ще раз.");
                return ChooseM();
        }
    }
    static int[] Random()
    {
        Console.WriteLine("Введіть кількість елементів масиву:");
        int n = int.Parse(Console.ReadLine());
        Random r = new Random();
        int[] F = new int[n];
        for (int i = 0; i < n; i++)
        {
            F[i] = r.Next(1, 101);
        }
        return F;
    }
    static int[] Hand()
    {
        Console.WriteLine("Виберіть спосіб введення (окремих/одному):");
        string input = Console.ReadLine().Trim().ToLower();
        if (input == "окремих")
        {
            Console.WriteLine("Введіть кількість елементів масиву:");
            int n = int.Parse(Console.ReadLine());
            int[] F = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Введіть елемент №{i + 1}: ");
                F[i] = int.Parse(Console.ReadLine());
            }
            return F;
        }
        else if (input == "одному")
        {
            Console.WriteLine("Введіть числа через пробіл: ");
            string[] num = Console.ReadLine().Split(' ');
            int[] F = new int[num.Length];
            for (int i = 0; i < num.Length; i++)
            {
                F[i] = int.Parse(num[i]);
            }
            return F;
        }
        else
        {
            Console.WriteLine("Невірний вибір.Спробуйте ще раз.");
            return Hand();
        }
    }
    static void Print(int[] F)
    {
        for (int i = 0; i < F.Length; i++)
        {
            Console.Write(F[i] + " ");
        }
        Console.WriteLine();
    }
    static (int minValue, int lastIndex) FindMinAndLastIndex(int[] F)
    {
        int minValue = F[0];
        int lastIndex = 0;
        for (int i = 0; i < F.Length; i++)
        {
            if (F[i] < minValue)
            {
                minValue = F[i];
                lastIndex = i;
            }
            else if (F[i] == minValue)
            {
                lastIndex = i;
            }
        }
        return (minValue, lastIndex);
    }
    static int[] GetElementAften(int[] F, int SIndex)
    {
        int length = F.Length - SIndex - 1;//Елементи після пошуку
        int[] res = new int[length];
        for (int i = 0; i < length; i++)
        {
            res[i] = F[SIndex + 1 + i];
        }
        return res;
    }
    static long CalculateMultiply(int[] F)
    {
        if (F.Length == 0) return 1;//обрахування добутку елементів, повернення 1 якщо немає
        long multiply = 1;
        for (int i = 0; i < F.Length; i++)
        {
            multiply *= F[i];
        }
        return multiply;
    }
}