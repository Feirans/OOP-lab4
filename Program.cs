class Program
    {
        static void Main()
        {
            Angle a1 = new Angle(45, 30);
            Angle a2 = new Angle(30, 45);

            Console.WriteLine($"Кут 1: {a1.degre}° {a1.minuta}'");
            Console.WriteLine($"Радіани: {a1.ToRadians():F4}");
            Console.WriteLine($"Синус: {a1.GetSin():F4}");

            // Порівняння
            Console.WriteLine($"Кут 1 більший за Кут 2? {a1.IsGreater(a2)}");

            // Збільшення
            a1.Add(a2);
            Console.WriteLine($"Після додавання: {a1.degre}° {a1.minuta}'");

            // Зменшення
            a1.Subtract(new Angle(100, 0));
            Console.WriteLine($"Після віднімання 100°: {a1.degre}° {a1.minuta}'"); 
        }
    }

