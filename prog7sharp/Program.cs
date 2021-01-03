using System;
namespace prog6.sem32
{
    class Program
    {
        struct nation
        {
            public void Read()
            {
                Console.WriteLine("Введите название государства:");
                title = Console.ReadLine();
                Console.WriteLine("Введите кол-во населения:");
                population = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите военную мощь (=<2):");
                millitarypow = Convert.ToSingle(Console.ReadLine());
            }
            public void Init(string a, int b, float c)
            {
                title = a;
                population = b;
                millitarypow = c;
            }
            /*public void Surrend()
            {
                Console.WriteLine($"Государство {title} сдалось");
                surrender = true;
            }*/
            public void Display()
            {
                Console.WriteLine($"Информация о государстве {title}");
                Console.WriteLine($"Популяция - {population}");
                Console.WriteLine($"Военная мощь - {millitarypow}");
            }
            /*public void Endwar()
            {
                score = Convert.ToInt32(population * millitarypow);
            }*/
            public string title;
            public int population;
            public float score;
            public float millitarypow;
            /*public bool surrender;
            public bool win;*/
        };
        /*struct peacefull : nation
        {
            public void Devpopulation()
            {
                Console.WriteLine($"\nУ государства {title} выросла популяция, военная сила уменьшена");
                population = (int)(population * 1.5);
                millitarypow = (int)(millitarypow - 0.1);
            }
            public void Display()
            {
                Console.WriteLine($"Информация о государстве {title}");
                Console.WriteLine($"Популяция - {population}");
                Console.WriteLine($"Военная мощь - {millitarypow}");
                Console.WriteLine($"Тип государства - Дружелюбное");
            }
        };
        class enemy : nation
        {
            public void devmilitar()
            {
                Console.WriteLine($"\nУ государства {title} увеличилась военная мощь, популяция уменьшена");
                millitarypow += 1;
                population = (int)(population * 0.7);
            }
            public void Display()
            {
                Console.WriteLine($"Информация о государстве {title}");
                Console.WriteLine($"Популяция - {population}");
                Console.WriteLine($"Военная мощь - {millitarypow}");
                Console.WriteLine($"Тип государства - Военное");
            }
        };*/
        static void Main(string[] args)
        {
            nation italy = new nation();
            italy.Read();
            italy.Display();
            nation rome = new nation();
            rome.Init("rome", 10000, (float)1.1);
            rome.Display();
        }
    }
}