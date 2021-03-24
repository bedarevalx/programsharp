using System;
namespace prog7sharp
{
    class Program
    {
        class nation
        {
            public void Read()
            {
                Console.WriteLine("Введите название государства:");
                title = Console.ReadLine();
                Console.WriteLine("Введите кол-во населения:");
                population = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите военную мощь (=<2):");
                millitarypow = Convert.ToSingle(Console.ReadLine());
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine($"Введите {i + 1} войско: ");
                    army[i] = Convert.ToInt32(Console.ReadLine());
                }
            }
            public void Init(string a, int b, float c, int one, int two, int three)
            {
                title = a;
                population = b;
                millitarypow = c;
                army[1] = one;
                army[2] = two;
                army[3] = three;
            }
            public void Surrend()
            {
                Console.WriteLine($"Государство {title} сдалось");
                surrender = true;
            }
            public void Endwar()
            {
                score = Convert.ToInt32(population * millitarypow);
            }
            static public void fight(ref int i, peacefull one, peacefull two)
            {
                int score1, score2;
                score1 = 0;
                score2 = 0;
                if (one.army[0] > two.army[0])
                    score1++;
                else score2++;
                if (one.army[1] > two.army[1])
                    score1++;
                else score2++;
                if (one.army[2] > two.army[2])
                    score1++;
                else score2++;
                if (score1 > score2) i = 1;
                else i = 2;

            }
            public string title;
            public int[] army = new int[3];
            public int population;
            public float score;
            public float millitarypow;
            public bool surrender = false;
            public bool win = false;
        };
        class peacefull : nation
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
        };
        static void Main(string[] args)
        {
            peacefull[] peace = new peacefull[2];
            peace[0].Read();
            peace[1].Init("Rome", 11000, (float)1.1, 100, 200, 300);
            peace[0].Display();
            peace[1].Display();
            Console.WriteLine("***********Начало войны***********");
            Console.WriteLine("\nУ государств еще есть возможность этого избежать, если\n одно из государств сдастся");
            Console.WriteLine($"\nГосударство {peace[0].title} вы хотите сдаться? (1-да 2-нет)");
            int num;
            do
            {
                num = Console.ReadKey().KeyChar;
                if (num == 50) break;
                if (num == 49) break;
            } while (true);
            if (num == 49)
            {
                peace[0].Surrend();
            }
            Console.WriteLine($"\nГосударство {peace[1].title} вы хотите сдаться? (1-да 2-нет)");
            do
            {
                num = Console.ReadKey().KeyChar;
                if (num == 50) break;
                if (num == 49) break;
            } while (true);
            if (num == 49)
            {
                peace[1].Surrend();
            }
            if (peace[0].surrender == true && peace[1].surrender == true)
            {
                Console.WriteLine("Был заключен мирный переговор, война закончилась");
            }
            if (peace[0].surrender == true && peace[1].surrender == false)
            {
                Console.WriteLine($"Государство {peace[0].title} сдалось, победу одержало государство {peace[1].title}");
            }
            if (peace[0].surrender == false && peace[1].surrender == true)
            {
                Console.WriteLine($"Государство {peace[1].title} сдалось, победу одержало государство {peace[0].title}");
            }
            if (peace[0].surrender == false && peace[1].surrender == false)
            {
                peace[0].Devpopulation();
                peace[1].Devpopulation();
                int i = 0;
                nation.fight(ref i, peace[0], peace[1]);
                if (i == 1)
                {
                    Console.WriteLine($"\nАрмия {peace[0].title} победила");
                }
                if (i == 2)
                {
                    Console.WriteLine($"\nАрмия {peace[1].title} победила");
                }
                peace[0].Endwar();
                peace[1].Endwar();
                if (peace[0].score > peace[1].score)
                {
                    Console.WriteLine($"\nВ ходе войны государство {peace[1].title} потерпело поражение, победу одержало государство {peace[0].title}");
                }
                if (peace[0].score < peace[1].score)
                {
                    Console.WriteLine($"\nВ ходе войны государство {peace[0].title} потерпело поражение, победу одержало государство {peace[1].title}");
                }
                if (peace[0].score == peace[1].score)
                {
                    Console.WriteLine("В ходе войны силы обоих сторон оказались равными, объявлена ничья!");
                }
            }
        }
    }
}