using System;
namespace prog6.sem32
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
            static public void fight (ref int i, peacefull one, enemy two)
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
            peacefull one = new peacefull();
            enemy two = new enemy();
            one.Read();
            two.Init("Rome", 11000, (float)1.1,100,200,300);
            one.Display();
            two.Display();
            Console.WriteLine("***********Начало войны***********");
            Console.WriteLine("\nУ государств еще есть возможность этого избежать, если\n одно из государств сдастся");
            Console.WriteLine($"\nГосударство {one.title} вы хотите сдаться? (1-да 2-нет)");
            int num;
            do
            {
                num = Console.ReadKey().KeyChar;
                if (num == 50) break;
                if (num == 49) break;
            } while (true);
            if (num == 49)
            {
                one.Surrend();
            }
            Console.WriteLine($"\nГосударство {two.title} вы хотите сдаться? (1-да 2-нет)");
            do
            {
                num = Console.ReadKey().KeyChar;
                if (num == 50) break;
                if (num == 49) break;
            } while (true);
            if (num == 49)
            {
                two.Surrend();
            }
            if (one.surrender == true && two.surrender == true)
            {
                Console.WriteLine("Был заключен мирный переговор, война закончилась");
            }
            if (one.surrender == true && two.surrender == false)
            {
                Console.WriteLine($"Государство {one.title} сдалось, победу одержало государство {two.title}");
            }
            if (one.surrender == false && two.surrender == true)
            {
                Console.WriteLine($"Государство {two.title} сдалось, победу одержало государство {one.title}");
            }
            if (one.surrender == false && two.surrender == false)
            {
                one.Devpopulation();
                two.devmilitar();
                int i=0;
                nation.fight(ref i, one, two);
                if (i == 1)
                {
                    Console.WriteLine($"\nАрмия {one.title} победила");
                }
                if (i == 2)
                {
                    Console.WriteLine($"\nАрмия {two.title} победила");
                }
                one.Endwar();
                two.Endwar();
                if (one.score > two.score)
                {
                    Console.WriteLine($"\nВ ходе войны государство {two.title} потерпело поражение, победу одержало государство {one.title}");
                }
                if (one.score < two.score)
                {
                    Console.WriteLine($"\nВ ходе войны государство {one.title} потерпело поражение, победу одержало государство {two.title}");
                }
                if (one.score == two.score)
                {
                    Console.WriteLine("В ходе войны силы обоих сторон оказались равными, объявлена ничья!");
                }
            }
        }
    }
}