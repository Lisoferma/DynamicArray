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
    public void PushBack_Call100Times_AddedElementsSameAsInResultingArray()
    {
        int additions = 100;
        DynamicArray<int> array = new();

        for (int i = 0; i < additions; i++)
            array.PushBack(i);

        for (int i = 0; i < additions; i++)
            Assert.AreEqual(i, array[i], "Значения элементов массива не совпадают с добавленными");
    }


    [TestMethod]
    public void PopBack_Call100Times_ReturnedElementsAreSameAsTheyWereInArray()
    {
        int calls = 100;
        DynamicArray<int> array = new(calls);

        for (int i = 0; i < calls; i++)
            array[i] = i;

        for (int i = calls - 1; i > 0; i--)
        {
            int expectedElement = array[i];
            int actualElement = array.PopBack();

            Assert.AreEqual(expectedElement, actualElement, "Возвращённый элемент из метода PopBack, не совпадает с тем который был в массиве");
        }
    }


    [TestMethod]
    public void Insert_Call100Times_AddedElementsSameAsInResultingArray()
    {
        int calls = 100;
        int insertIndex = 10;
        DynamicArray<int> array = new(20);

        for (int i = calls - 1; i >= 0; i--)
            array.Insert(insertIndex, i);

        for (int i = 0; i < calls; i++)
        {
            int expectedElement = i;
            int actualElement = array[insertIndex + i];

            Assert.AreEqual(expectedElement, actualElement, "Вставленный элемент не совпадают с фактическим элементом массива");
        }     
    }
}