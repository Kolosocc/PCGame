using System;
using System.Collections.Generic;
using System.Xml.Linq;
using GameApp.Models;

namespace GameApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<IPCGame> games = new List<IPCGame>();
            Console.WriteLine("Добро пожаловать в менеджер игр!");

            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Добавить новую игру");
                Console.WriteLine("2. Показать список игр");
                Console.WriteLine("3. Выход");
                string choice = Console.ReadLine();

                if (choice == "3") break;

                switch (choice)
                {
                    case "1":
                        AddNewGame(games);
                        break;
                    case "2":
                        DisplayGames(games);
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                        break;
                }
            }

            Console.WriteLine("Спасибо за использование менеджера игр!");
        }

        private static void AddNewGame(List<IPCGame> games)
        {
            Console.WriteLine("Введите название игры:");
            string name = GetNormalString();

            PegiAgeRating pegiAgeRating;
            while (true)
            {
                Console.WriteLine("Введите возрастной рейтинг (0:P3, 1:P7, 2:P12, 3:P16, 4:P18):");
                string ratingInput = Console.ReadLine();
                if (Enum.TryParse(ratingInput, out pegiAgeRating))
                    break;
                Console.WriteLine("Некорректный возрастной рейтинг. Попробуйте снова.");
            }

            Console.WriteLine("Введите бюджет игры в миллионах долларов:");
            double budget = GetPositiveDouble();

            Console.WriteLine("Введите минимальную память GPU в мегабайтах:");
            int gpuMemory = GetPositiveInt();

            Console.WriteLine("Введите необходимое дисковое пространство в гигабитах:");
            int diskSpace = GetPositiveInt();

            Console.WriteLine("Введите необходимое количество RAM в гигабайтах:");
            int ram = GetPositiveInt();

            Console.WriteLine("Введите необходимое количество ядер процессора:");
            int cores = GetPositiveInt();

            Console.WriteLine("Введите тактовую частоту процессора в гигагерцах:");
            double coreSpeed = GetPositiveDouble();

            var game = new ComputerGame(
                name,
                pegiAgeRating,
                budget,
                gpuMemory,
                diskSpace,
                ram,
                cores,
                coreSpeed
            );

            IPCGame adaptedGame = new ComputerGameAdapter(game);
            games.Add(adaptedGame);

            Console.WriteLine("Игра добавлена.");
        }

        private static void DisplayGames(List<IPCGame> games)
        {
            if (games.Count == 0)
            {
                Console.WriteLine("Нет доступных игр.");
                return;
            }

            Console.WriteLine("\nСписок доступных игр:");
            foreach (var adaptedGame in games)
            {
                Console.WriteLine($"Название игры: {adaptedGame.GetTitle()}");
                Console.WriteLine($"Допустимый возраст: {adaptedGame.GetPegiAllowedAge()}");

                if (adaptedGame is ComputerGameAdapter adapter && adapter.IsTripleAGame())
                {
                    Console.WriteLine("Игра: Трипл-А (AAA)");
                }
                else
                {
                    Console.WriteLine("Игра: Не является Трипл-А");
                }

                Requirements requirements = adaptedGame.GetRequirements();
                Console.WriteLine($"Требуемая память GPU (ГБ): {requirements.GetGpuGB()}");
                Console.WriteLine($"Требуемый объем HDD (ГБ): {requirements.GetHddGB()}");
                Console.WriteLine($"Требуемый объем RAM (ГБ): {requirements.GetRamGB()}");
                Console.WriteLine($"Тактовая частота CPU (ГГц): {requirements.GetCpuGhz()}");
                Console.WriteLine($"Количество ядер CPU: {requirements.GetCoresNum()}");
                Console.WriteLine();
            }
        }


        private static double GetPositiveDouble()
        {
            double value;
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out value) && value > 0)
                    return value;
                Console.WriteLine("Введите положительное число:");
            }
        }

        private static int GetPositiveInt()
        {
            int value;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out value) && value > 0)
                    return value;
                Console.WriteLine("Введите положительное целое число:");
            }
        }

        private static string GetNormalString()
        {
            string name;
            while (true)
            {
                name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name))
                    return name;
                Console.WriteLine("Название не может быть пустым. Попробуйте снова.");
            }
        }
    }
}
