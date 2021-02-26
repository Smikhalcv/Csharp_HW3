using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_03
{
    class Program
    {
        static void Main(string[] args)
        {
            // Просматривая сайты по поиску работы, у вас вызывает интерес следующая вакансия:

            // Требуемый опыт работы: без опыта
            // Частичная занятость, удалённая работа
            //
            // Описание 
            //
            // Стартап «Micarosppoftle» занимающийся разработкой
            // многопользовательских игр ищет разработчиков в свою команду.
            // Компания готова рассмотреть C#-программистов не имеющих опыта в разработке, 
            // но желающих развиваться в сфере разработки игр на платформе .NET.
            //
            // Должность Интерн C#/
            //
            // Основные требования:
            // C#, операторы ввода и вывода данных, управляющие конструкции 
            // 
            // Конкурентным преимуществом будет знание процедурного программирования.
            //
            // Не технические требования: 
            // английский на уровне понимания документации и справочных материалов
            //
            // В качестве тестового задания предлагается решить следующую задачу.
            //
            // Написать игру, в которою могут играть два игрока.
            // При старте, игрокам предлагается ввести свои никнеймы.
            // Никнеймы хранятся до конца игры.
            // Программа загадывает случайное число gameNumber от 12 до 120 сообщая это число игрокам.
            // Игроки ходят по очереди(игра сообщает о ходе текущего игрока)
            // Игрок, ход которого указан вводит число userTry, которое может принимать значения 1, 2, 3 или 4,
            // введенное число вычитается из gameNumber
            // Новое значение gameNumber показывается игрокам на экране.
            // Выигрывает тот игрок, после чьего хода gameNumber обратилась в ноль.
            // Игра поздравляет победителя, предлагая сыграть реванш
            // 
            // * Бонус:
            // Подумать над возможностью реализации разных уровней сложности.
            // В качестве уровней сложности может выступать настраиваемое, в начале игры,
            // значение userTry, изменение диапазона gameNumber, или указание большего количества игроков (3, 4, 5...)

            // *** Сложный бонус
            // Подумать над возможностью реализации однопользовательской игры
            // т е игрок должен играть с компьютером


            // Демонстрация
            // Число: 12,
            // Ход User1: 3
            //
            // Число: 9
            // Ход User2: 4
            //
            // Число: 5
            // Ход User1: 2
            //
            // Число: 3
            // Ход User2: 3
            //
            // User2 победил!

            // Функция центрирования текста
            void WriteLineCentered(string text)
            {
                int width = Console.WindowWidth;
                if (text.Length < width)
                {
                    Console.CursorLeft = (width - text.Length) / 2;
                }

                Console.WriteLine(text);
            };

           
            // Приветствие и правила игры
            WriteLineCentered("Добро пожаловать в игру Пазак!");
            WriteLineCentered("Правила игры!");
            WriteLineCentered("===========================================================");
            WriteLineCentered("Случайным образом генерируется число,");
            WriteLineCentered("в зависимости от количества игроков и костей выбранных в начале.");
            WriteLineCentered("Каждый игрок по очереди кидает кости.");
            WriteLineCentered("Из числа вычитается количество очков выпавших на костях.");
            WriteLineCentered("Побеждает игрок, после хода которого останется 0.");
            WriteLineCentered("===========================================================");

            // Задание начальных условий
            // Определяем количество игроков
            Console.WriteLine("Выберете режим игры: введите 1 если желаете Player vs Player; 2 если Player vs Computer.");
            int gameMode;
            int stupidPlayer = 0;
            while (true)
            {
                try
                {
                    gameMode = Convert.ToInt32(Console.ReadLine());
                    if (gameMode == 1 || gameMode == 2)
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                catch (Exception)
                {
                    
                    if (stupidPlayer < 3)
                    {
                        Console.WriteLine("Не верно выбран режим!");
                        stupidPlayer++;
                    }
                    else
                    {
                        Console.WriteLine("Ты идиот? Просто нажми цифру 1 или 2 и всё!!!!");
                    }
                    
                }
            }

            

            // Имя игрока и тело игры для режима против компьютера
            Random randomize = new Random();
            int brakenPoints;
            bool game = true;
            int sumPointBonds = 0; // сюда складываем очки выброшенные на костях, если их несколько
            if (gameMode == 2)
            {
                Console.WriteLine("Укажите имя игрока :");
                string player1 = Console.ReadLine();

                while (game)
                {

                    // Выбор количества костей
                    Console.WriteLine("Выберете количество игральных костей.");
                    Console.WriteLine("Значение по умолчанию 1, но можно выбрать до 3.");
                    Console.WriteLine("В зависимости от этого будет различаться значение уменшаемого числа.");
                    Console.WriteLine("1 кость - 50 (быстрая игра), 2 - 70, 3 - 120 (ОЧЕНЬ долгая игра - шанс на победу 1 к 216).");
                    Console.WriteLine("В случай если значение числа меньше количества костей,");
                    Console.WriteLine("игровое значение примит значение количества игровых костей.");

                    int countGameBonds = 1;
                    stupidPlayer = 0;
                    while (true)
                    {
                        try
                        {
                            countGameBonds = Convert.ToInt32(Console.ReadLine());
                            if (countGameBonds == 1 || countGameBonds == 2 || countGameBonds == 3)
                            {
                                break;
                            }
                            else
                            {
                                stupidPlayer++;
                                Console.WriteLine("Не верно указано количество игральных костей!");
                                Console.WriteLine($"Осталось попыток - {3 - stupidPlayer}.");
                                if (stupidPlayer == 3)
                                {
                                    countGameBonds = 1;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Укажите количество костей, иначе будет принято значение по умолчанию.");
                                }
                                continue;
                            }
                        }
                        catch (Exception)
                        {
                            stupidPlayer++;
                            Console.WriteLine("Не верно указано количество игральных костей!");
                            Console.WriteLine($"Осталось попыток - {3 - stupidPlayer}.");
                            if (stupidPlayer == 3)
                            {
                                countGameBonds = 1;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Укажите количество костей, иначе будет принято значение по умолчанию.");
                            }
                        }
                    }

                    int gameCounter;
                    if (countGameBonds == 1)
                    {
                        gameCounter = 50;
                    }
                    else if (countGameBonds == 2)
                    {
                        gameCounter = 70;
                    }
                    else
                    {
                        gameCounter = 120;
                    }

                    // тело игры
                    while (true)
                    {
                        // ходит игрок в игре против компа
                        Console.WriteLine("Ход игрока (нажмите Enter)");
                        Console.ReadKey();
                        for (int i = 0; i < countGameBonds; i++) // суммирует поличество выброшенных очков
                        {
                            brakenPoints = randomize.Next(1, 7);
                            Console.WriteLine(brakenPoints);
                            sumPointBonds += brakenPoints;
                        }

                        // основной алгоритм
                        if (gameCounter == sumPointBonds) // если игровое значение равно сумме брошенных костей игрок победил
                        {
                            gameCounter = 0;
                            WriteLineCentered("===========================================================");
                            WriteLineCentered("Поздравляем!!!");
                            WriteLineCentered($"Победил игрок {player1}!!!");
                            WriteLineCentered("===========================================================");
                            Console.ReadKey();
                            break;
                        }
                        else if (gameCounter < countGameBonds) // если игровое значение меньше количества, то игровое значение 
                        {                                       //приравнивает к количеству костей
                            gameCounter = countGameBonds;
                        }
                        else if (gameCounter < sumPointBonds) // если игровое значение меньше выброшенного количество очков, то ничего не делать
                        {

                        }
                        else
                        {
                            gameCounter -= sumPointBonds;
                        }
                        Console.WriteLine($"Осталось очков - {gameCounter}!");
                        sumPointBonds = 0; // обнуляем сумму брошенных костей

                        // ходит компьютер
                        Console.WriteLine("Ход компьютера (нажмите Enter)");
                        Console.ReadKey();
                        for (int i = 0; i < countGameBonds; i++) // суммирует поличество выброшенных очков
                        {
                            brakenPoints = randomize.Next(1, 7);
                            Console.WriteLine(brakenPoints);
                            sumPointBonds += brakenPoints;
                        }

                        // основной алгоритм
                        if (gameCounter == sumPointBonds) // если игровое значение равно сумме брошенных костей игрок победил
                        {
                            gameCounter = 0;
                            WriteLineCentered("===========================================================");
                            WriteLineCentered($"Победил компьютер!!!");
                            WriteLineCentered("===========================================================");
                            Console.ReadKey();
                            break;
                        }
                        else if (gameCounter < countGameBonds) // если игровое значение меньше количества, то игровое значение 
                        {                                       //приравнивает к количеству костей
                            gameCounter = countGameBonds;
                        }
                        else if (gameCounter < sumPointBonds) // если игровое значение меньше выброшенного количество очков, то ничего не делать
                        {

                        }
                        else
                        {
                            gameCounter -= sumPointBonds;
                        }
                        Console.WriteLine($"Осталось очков - {gameCounter}!");
                        sumPointBonds = 0; // обнуляем сумму брошенных костей
                    }

                    // запрос на повтор
                    Console.WriteLine("Желаете сыграть ещё раз? (Да/Нет)");
                    string answerRepeatGame = Console.ReadLine();
                    if (answerRepeatGame.StartsWith("Y") || 
                        answerRepeatGame.StartsWith("y") || 
                        answerRepeatGame.StartsWith("Д") ||
                        answerRepeatGame.StartsWith("д"))
                    {

                    }
                    else
                    {
                        game = false;
                    }
                }
                
            }
            else
            {
                Console.WriteLine("Укажите имя первого игрока :");
                string player1 = Console.ReadLine();
                Console.WriteLine("Укажите имя второго игрока :");
                string player2 = Console.ReadLine();

                while (game)
                {
                    // Выбор количества костей
                    Console.WriteLine("Выберете количество игральных костей.");
                    Console.WriteLine("Значение по умолчанию 1, но можно выбрать до 3.");
                    Console.WriteLine("В зависимости от этого будет различаться значение уменшаемого числа.");
                    Console.WriteLine("1 кость - 50 (быстрая игра), 2 - 70, 3 - 120 (ОЧЕНЬ долгая игра - шанс на победу 1 к 216).");
                    Console.WriteLine("В случай если значение числа меньше количества костей,");
                    Console.WriteLine("игровое значение примит значение количества игровых костей.");

                    int countGameBonds = 1;
                    stupidPlayer = 0;
                    while (true)
                    {
                        try
                        {
                            countGameBonds = Convert.ToInt32(Console.ReadLine());
                            if (countGameBonds == 1 || countGameBonds == 2 || countGameBonds == 3)
                            {
                                break;
                            }
                            else
                            {
                                stupidPlayer++;
                                Console.WriteLine("Не верно указано количество игральных костей!");
                                Console.WriteLine($"Осталось попыток - {3 - stupidPlayer}.");
                                if (stupidPlayer == 3)
                                {
                                    countGameBonds = 1;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Укажите количество костей, иначе будет принято значение по умолчанию.");
                                }
                                continue;
                            }
                        }
                        catch (Exception)
                        {
                            stupidPlayer++;
                            Console.WriteLine("Не верно указано количество игральных костей!");
                            Console.WriteLine($"Осталось попыток - {3 - stupidPlayer}.");
                            if (stupidPlayer == 3)
                            {
                                countGameBonds = 1;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Укажите количество костей, иначе будет принято значение по умолчанию.");
                            }
                        }
                    }

                    int gameCounter;
                    if (countGameBonds == 1)
                    {
                        gameCounter = 50;
                    }
                    else if (countGameBonds == 2)
                    {
                        gameCounter = 70;
                    }
                    else
                    {
                        gameCounter = 120;
                    }

                    // тело игры
                    while (true)
                    {
                        // ходит игрок 1
                        Console.WriteLine($"Ход игрока {player1} (нажмите Enter)");
                        Console.ReadKey();
                        for (int i = 0; i < countGameBonds; i++) // суммирует поличество выброшенных очков
                        {
                            brakenPoints = randomize.Next(1, 7);
                            Console.WriteLine(brakenPoints);
                            sumPointBonds += brakenPoints;
                        }

                        // основной алгоритм
                        if (gameCounter == sumPointBonds) // если игровое значение равно сумме брошенных костей игрок победил
                        {
                            gameCounter = 0;
                            WriteLineCentered("===========================================================");
                            WriteLineCentered("Поздравляем!!!");
                            WriteLineCentered($"Победил игрок {player1}!!!");
                            WriteLineCentered("===========================================================");
                            Console.ReadKey();
                            break;
                        }
                        else if (gameCounter < countGameBonds) // если игровое значение меньше количества, то игровое значение 
                        {                                       //приравнивает к количеству костей
                            gameCounter = countGameBonds;
                        }
                        else if (gameCounter < sumPointBonds) // если игровое значение меньше выброшенного количество очков, то ничего не делать
                        {

                        }
                        else
                        {
                            gameCounter -= sumPointBonds;
                        }
                        Console.WriteLine($"Осталось очков - {gameCounter}!");
                        sumPointBonds = 0; // обнуляем сумму брошенных костей

                        // ходит игрок 2
                        Console.WriteLine($"Ход игрока {player2} (нажмите Enter)");
                        Console.ReadKey();
                        for (int i = 0; i < countGameBonds; i++) // суммирует поличество выброшенных очков
                        {
                            brakenPoints = randomize.Next(1, 7);
                            Console.WriteLine(brakenPoints);
                            sumPointBonds += brakenPoints;
                        }

                        // основной алгоритм
                        if (gameCounter == sumPointBonds) // если игровое значение равно сумме брошенных костей игрок победил
                        {
                            gameCounter = 0;
                            WriteLineCentered("===========================================================");
                            WriteLineCentered("Поздравляем!!!");
                            WriteLineCentered($"Победил игрок {player2}!!!");
                            WriteLineCentered("===========================================================");
                            Console.ReadKey();
                            break;
                        }
                        else if (gameCounter < countGameBonds) // если игровое значение меньше количества, то игровое значение 
                        {                                       //приравнивает к количеству костей
                            gameCounter = countGameBonds;
                        }
                        else if (gameCounter < sumPointBonds) // если игровое значение меньше выброшенного количество очков, то ничего не делать
                        {

                        }
                        else
                        {
                            gameCounter -= sumPointBonds;
                        }
                        Console.WriteLine($"Осталось очков - {gameCounter}!");
                        sumPointBonds = 0;

                    }

                    // запрос на повтор
                    Console.WriteLine("Желаете сыграть ещё раз? (Да/Нет)");
                    string answerRepeatGame = Console.ReadLine();
                    if (answerRepeatGame.StartsWith("Y") ||
                        answerRepeatGame.StartsWith("y") ||
                        answerRepeatGame.StartsWith("Д") ||
                        answerRepeatGame.StartsWith("д"))
                    {

                    }
                    else
                    {
                        game = false;
                    }
                }
                

            }
        }
    }
}
