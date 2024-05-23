using LibraryClass;
using System.Collections.Generic;

namespace BinatyTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyTree<BankCard> tree = null;
            MyTree<BankCard> searchTree = null;
            int answer = 1;
            while (answer != 7)
            {
                try
                {
                    Console.WriteLine("1. Создать идеально сбалансированное дерево");
                    Console.WriteLine("2. Напечатать идеально сбалансированное дерево");
                    Console.WriteLine("3. Вычислить среднее арифметическое по датам");
                    Console.WriteLine("4. Преобразовать идеально сбалансированное дерево в дерево поиска");
                    Console.WriteLine("5. Демонстрация сбалалансированного дерева и дерева поиска");
                    Console.WriteLine("6. Удалить сбалансированное дерево из памяти");
                    Console.WriteLine("7. Выйти");
                    answer = int.Parse(Console.ReadLine());
                    switch (answer)
                    {
                        case 1:
                            Console.Write("Задайте размер идеально сбалансированного дерева: ");
                            int length = int.Parse(Console.ReadLine());
                            tree = new MyTree<BankCard>(length);
                            Console.WriteLine("Идеально сбалансированное дерево создано.");
                            break;
                        case 2:
                            Console.WriteLine("Идеально сбалансированное дерево:");
                            tree.ShowTree(); 
                            break;
                        case 3:
                            double averageDate = tree.CalculateAverageDate();
                            Console.WriteLine($"Среднее арифметическое по датам: {averageDate}");
                            break;
                        case 4:
                            searchTree = tree.Clone();
                            searchTree.TransformToFindTree();
                            Console.WriteLine("Преобразование в дерево поиска выполнено.");
                            break;
                        case 5:
                            Console.WriteLine("Дерево поиска:");
                            searchTree.ShowTree();
                            Console.WriteLine("Сбалансированное дерево:");
                            tree.ShowTree();
                            break;
                        case 6:
                            Console.WriteLine("Удаление идеально сбалансированного дерева из памяти...");
                            tree.DeleteTree();
                            tree = null;
                            Console.WriteLine("Идеально сбалансированное дерево успешно удалено из памяти.");
                            break;
                        case 7:
                            Console.WriteLine("Программа завершена.");
                            break;
                        default:
                            Console.WriteLine("Некорректный ввод. Попробуйте еще раз.");
                            break;
                    }
                }
                catch (Exception ex)
                { Console.WriteLine(ex.Message); }
            }
        }
    }
}