//@author Lisoferma

using DynamicArray;
using System;
using System.Linq;
using System.Windows;

namespace DynamicArrayGUIExample;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private DynamicArray<int> intNumberArray = new();
    private Random random = new();


    public MainWindow()
    {
        InitializeComponent();

        TextBlock_numbers.Inlines.Add("");
        TextBlock_numbers.Inlines.Remove(TextBlock_numbers.Inlines.LastInline);
    }


    /// <summary>
    /// Добавляет случайное число в конец массива. Обновляет TextBlock_numbers и Label_size_capacity.
    /// </summary>
    private void button_push_back_Click(object sender, RoutedEventArgs e)
    {
        intNumberArray.PushBack( random.Next(100) );

        TextBlock_numbers.Inlines.Add( intNumberArray[intNumberArray.Size - 1].ToString() + " " );
        Label_size_capacity.Content = intNumberArray.ToString();
    }


    /// <summary>
    /// Удаляет последний элемент массива. Обновляет TextBlock_numbers и Label_size_capacity.
    /// </summary>
    private void button_pop_back_Click(object sender, RoutedEventArgs e)
    {
        if (intNumberArray.Size == 0) return;

        intNumberArray.PopBack();

        TextBlock_numbers.Inlines.Remove( TextBlock_numbers.Inlines.LastInline );
        Label_size_capacity.Content = intNumberArray.ToString();
    }
}

