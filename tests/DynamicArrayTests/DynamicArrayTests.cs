//@author Lisoferma

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DynamicArray.Tests;

[TestClass]
public class DynamicArrayTests
{
    [TestMethod]
    public void Resize_ValidNewSize_UpdatesSize()
    {
        int newSize = 10;
        DynamicArray<int> array = new();

        array.Resize(newSize);

        int actualSize = array.Size;
        Assert.AreEqual(newSize, actualSize, "Изменение размера массива выполнилось некорректно");
    }


    [TestMethod]
    public void Resize_NewSizeIsLessThanZero_ShouldThrowArgumentOutOfRange()
    {
        int newSize = -10;
        DynamicArray<int> array = new(5);

        Assert.ThrowsException<ArgumentOutOfRangeException>(() => array.Resize(newSize), "Ожидалось исключение");
    }


    [TestMethod]
    public void Resize_ReallocationMemoryWhenIncreasingSize_ArrayDataSaved()
    {
        int initializedItems = 10;
        DynamicArray<int> array = new(initializedItems);

        for (int i = 0; i < initializedItems; i++)
            array[i] = i;

        array.Resize(100);

        for (int i = 0; i < initializedItems; i++)
            Assert.AreEqual(i, array[i], "Значения элементов массива не были сохранены, после перераспределения памяти при увеличении размера");
    }


    [TestMethod]
    public void Resize_ReallocationMemoryWhenReducingSize_ArrayDataSaved()
    {
        int initializedItems = 100;
        int newSize = 10;
        DynamicArray<int> array = new(initializedItems);

        for (int i = 0; i < initializedItems; i++)
            array[i] = i;

        array.Resize(newSize);

        for (int i = 0; i < newSize; i++)
            Assert.AreEqual(i, array[i], "Значения элементов массива не были сохранены, после перераспределения памяти при уменьшении размера");
    }


    [TestMethod]
    public void PushBack_AfterPushBack_SizeIsOneMore()
    {
        int initialSize = 5;
        int expectedSize = initialSize + 1;
        DynamicArray<int> array = new(initialSize);

        array.PushBack(21);

        int actualSize = array.Size;
        Assert.AreEqual(expectedSize, actualSize, "Неожиданный размер массива после добавления одного элемента");
    }


    [TestMethod]
    public void PushBack_AddElement_AddedElementIsSameAsLastInArray()
    {
        double element = 99.99;
        DynamicArray<double> array = new(5);

        array.PushBack(element);

        double actualLastElement = array[array.Size - 1];
        Assert.AreEqual(element, actualLastElement, "Добавленный элемент не совпадает с последним в массиве");
    }
}