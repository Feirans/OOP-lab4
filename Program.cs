using System;
namespace Program;

class Program{
        static Angle[] ReadAnglesArray()
        {
            Console.Write("Введіть кількість кутів (n): ");
            int n = int.Parse(Console.ReadLine());
            Angle[] arr = new Angle[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Кут #{i + 1} ---");
                Console.Write("Введіть градуси: ");
                int d = int.Parse(Console.ReadLine());
                Console.Write("Введіть мінути: ");
                int m = int.Parse(Console.ReadLine());

                arr[i] = new Angle(d, m);
            }

            return arr;
        }
        static void PrintAngle(Angle a)
        {
            Console.WriteLine($"Кут: {a} | Радіани: {a.ToRadians():F4} | Синус: {a.GetSin():F4}");
        }

        static void SortAngles(Angle[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j].IsGreater(arr[j + 1]))
                    {
                        Angle temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        static void ModifyAngle(ref Angle a, int addDegre, int addMinuta)
        {
            a.degre += addDegre;
            a.minuta += addMinuta;
            a.Normalize();
        }

               static void GetMinMaxSin(Angle[] arr, out double minSin, out double maxSin)
        {
            if (arr.Length == 0)
            {
                minSin = 0;
                maxSin = 0;
                return;
            }

            minSin = arr[0].GetSin();
            maxSin = arr[0].GetSin();

            for (int i = 1; i < arr.Length; i++)
            {
                double currentSin = arr[i].GetSin();
                if (currentSin < minSin) minSin = currentSin;
                if (currentSin > maxSin) maxSin = currentSin;
            }
        }

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Тест обробки помилок ===");
            Angle badAngle = new Angle(45, 75);
            PrintAngle(badAngle);

            Console.WriteLine("\n=== Ввід масиву кутів ===");
            Angle[] angles = ReadAnglesArray();

            Console.WriteLine("\n=== Введені кути ===");
            foreach (Angle a in angles)
            {
                PrintAngle(a);
            }

            SortAngles(angles);
            Console.WriteLine("\n=== Відсортовані кути (за зростанням) ===");
            foreach (Angle a in angles)
            {
                PrintAngle(a);
            }

            GetMinMaxSin(angles, out double minS, out double maxS);
            Console.WriteLine($"\nМінімальний синус у масиві: {minS:F4}");
            Console.WriteLine($"Максимальний синус у масиві: {maxS:F4}");

            if (angles.Length > 0)
            {
                Console.WriteLine($"\n=== Модифікація першого кута через ref ===");
                Console.WriteLine($"До зміни: {angles[0]}");
                ModifyAngle(ref angles[0], 15, 20); // додаємо 15° 20'
                Console.WriteLine($"Після додавання 15° 20': {angles[0]}");
            }

            if (angles.Length >= 2)
            {
                Console.WriteLine($"\n=== Операції між першим і другим кутом ===");
                Console.WriteLine($"Перший кут дорівнює другому? {angles[0].IsEqual(angles[1])}");
                Console.WriteLine($"Перший кут дорівнює другому? {angles[0].IsEqual(angles[1])}");
                Console.WriteLine($"Перший кут менший за другий? {angles[0].IsLess(angles[1])}");

                angles[0].Add(angles[1]);
                Console.WriteLine($"Після Add (перший + другий): {angles[0]}");

                angles[0].Subtract(angles[1]);
                Console.WriteLine($"Після Subtract (повернули назад): {angles[0]}");
            }
        }
    }

