//@author Lisoferma

using DynamicArray;
using System.Collections;

namespace DynamicArrayConsoleExample;

/// <summary>
/// Пример использования DynamicArray.
/// </summary>
internal class Program
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("             DynamicArray example             ");
        Console.WriteLine("----------------------------------------------");
        Console.ResetColor();


        // Динамический массив с размером 2.
        DynamicArray<int> myArray = new(2);

        Console.WriteLine(myArray.ToString() + "\n");

        // Можно пользоваться библиотеками для операций с массивами используя DynamicArray,
        // но нужно явно передавать размер.
        Array.Fill(myArray.GetInternalArray(), 7, 0, myArray.Size);

        // Вывести DynamicArray и его внутренний массив.
        PrintArraysForExample(myArray);


        // Добавление элементов в конец динамического массива.
        const int additions = 6;

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Push back {additions} times:\n");
        Console.ResetColor();

        for (int i = 0; i < additions; i++)
        {
            myArray.PushBack(i);
            PrintArraysForExample(myArray);
        }


        // Удаление последних элементов динамического массива.
        const int deletions = 6;

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Pop back {deletions} times:\n");
        Console.ResetColor();

        for (int i = 0; i < deletions; i++)
        {
            myArray.PopBack();
            PrintArraysForExample(myArray);
        }


        // Изменение размера.
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Set size = 10:\n");
        Console.ResetColor();

        myArray.Resize(10);
        PrintArraysForExample(myArray);

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Set size = 3:\n");
        Console.ResetColor();

        myArray.Resize(3);
        PrintArraysForExample(myArray);

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Set size = 2:\n");
        Console.ResetColor();

        myArray.Resize(2);
        PrintArraysForExample(myArray);


        // Вставить -8 по индексу 1.
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Insert -8 at index 1:\n");
        Console.ResetColor();

        myArray.Insert(1, -8);
        PrintArraysForExample(myArray);
    }


    // Вывести DynamicArray и его внутренний массив с подписями в консоль.
    static void PrintArraysForExample<T>(DynamicArray<T> array)
    {
        Console.Write($" Dynamic array [{array.Size:00}]: ");
        PrintArrayToConsole(array);
        Console.WriteLine();

        Console.Write($"Internal array [{array.Capacity:00}]: ");
        PrintArrayToConsole(array.GetInternalArray());
        Console.WriteLine("\n");
    }


    // Вывести массив в консоль.
    static void PrintArrayToConsole(IEnumerable array)
    {
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
    }
}

