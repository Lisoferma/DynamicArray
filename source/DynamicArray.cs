//@author Lisoferma

using System.Collections;

namespace DynamicArray;

/// <summary>
/// Вспомогательный тип для избежания перераспределений памяти при построении массивов.
/// </summary>
/// <typeparam name="T">Тип элементов массива.</typeparam>
public class DynamicArray<T> : IEnumerable
{
    private T[] _items;                        // Внутренний массив. Число элементов, которое может содержаться без выделения дополнительного пространства.         
    private int _itemsInUse;                   // Количество элементов которое используется.

    private const int _increaseFactor = 2;     // Во сколько раз от текущего размера увеличится внутренний массив, при перераспределении памяти.
    private const int _reductionFactor = 3;    // Во сколько раз новый размер должен быть меньше текущей ёмкости, чтобы память перераспределилась.
                                                

    /// <summary>
    /// Инициализирует <see cref="DynamicArray{T}"/> пустым массивом и нулевым размером.
    /// </summary>
    public DynamicArray() : this(0, 0) { }


    /// <summary>
    /// Инициализирует <see cref="DynamicArray{T}"/> с заданным размером.
    /// </summary>
    /// <param name="size">Размер динамического массива.</param>
    public DynamicArray(int size) : this(size, 0) { }


    /// <summary>
    /// Инициализирует <see cref="DynamicArray{T}"/> с заданным размером и ёмкостью.
    /// </summary>
    /// <param name="size">Размер динамического массива.</param>
    /// <param name="capacity">Ёмкость динамического массива.</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public DynamicArray(int size = 0, int capacity = 0)
    {
        if (size < 0)
            throw new ArgumentOutOfRangeException(nameof(size), "Size must be >= 0");
        if (capacity < 0)
            throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be >= 0");
        if (size > 0 && capacity > 0 && size > capacity)
            throw new ArgumentException("Size must be <= capacity", nameof(size) + "; " + nameof(capacity));
        
        if (capacity > 0)
        {
            _items = new T[capacity];
        }
        else if (size > 0)
        {
            _items = new T[size * _increaseFactor];
        }
        else
        {
            _items = Array.Empty<T>();
        }

        _itemsInUse = size;
    }


    /// <value>
    /// Размер динамического массива.
    /// </value>
    public int Size
    {
        get
        {
            return _itemsInUse;
        }
    }


    /// <value>
    /// Число элементов, которое может содержаться без выделения дополнительного пространства.
    /// </value>
    public int Capacity 
    {
        get
        {
            return _items.Length;
        }
    }


    /// <value>
    /// Возвращает или устанавливает элемент по заданному индексу в массиве.
    /// </value>
    /// <param name="index">Индекс в массиве.</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public T this[int index]
    {
        get
        {
            if (index >= _itemsInUse)
                throw new ArgumentOutOfRangeException(nameof(index), "Index is larger than the array size");
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), "Index must be >= 0");

            return _items[index];
        }

        set
        {
            if (index >= _itemsInUse)
                throw new ArgumentOutOfRangeException(nameof(index), "Index is larger than the array size");
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), "Index must be >= 0");

            _items[index] = value;
        }
    }


    /// <summary>
    /// Изменяет размер массива до указанного.
    /// </summary>
    /// <param name="newSize">Новый размер массива</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public void Resize(int newSize)
    {
        if (newSize < 0)
            throw new ArgumentOutOfRangeException(nameof(newSize), "Array size must be >= 0");

        if (newSize != Size)
        {
            EnsureCapacity(newSize);
            _itemsInUse = newSize;
        }
    } 


    /// <summary>
    /// Добавляет элемент в конец массива.
    /// </summary>
    /// <param name="value">Значение элемента.</param>
    public void PushBack(T value)
    {
        Resize(Size + 1);
        _items[Size - 1] = value;      
    }


    /// <summary>
    /// Удаляет последний элемент массива.
    /// </summary>
    /// <returns>Значение последнего элемента массива.</returns>
    /// <exception cref="IndexOutOfRangeException"></exception>
    public T PopBack()
    {
        if (Size == 0)
            throw new IndexOutOfRangeException("Array is empty");

        T returnItem;

        returnItem = _items[Size - 1];
        Resize(Size - 1);
        return returnItem;
    }


    /// <summary>
    /// Вставляет элемент в массив на заданный индекс, сдвигая все остальные элементы на 1, начиная с заданного индекса.
    /// </summary>
    /// <param name="index">Индекс куда нужно вставить элемент.</param>
    /// <param name="item">Значение элемента.</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public void Insert(int index, T item)
    {
        if (index > Size)
            throw new ArgumentOutOfRangeException(nameof(index), "Index is larger than the array size");
        if (index < 0)
            throw new ArgumentOutOfRangeException(nameof(index), "Index must be >= 0");

        Resize(Size + 1);
        Array.Copy(_items, index, _items, index + 1, Size - index);
        _items[index] = item;
    }


    /// <summary>
    /// Возвращает внутренний массив.
    /// </summary>
    /// <returns>Внутренний массив.</returns>
    /// <example> 
    /// Пример, как можно использовать этот метод для работы с классом Array.
    /// <code>
    /// Array.Sort(myDynamicArray.GetInternalArray(), 0, myDynamicArray.Size);
    /// </code>
    /// </example>
    public T[] GetInternalArray()
    {
        return _items;
    }


    /// <summary>
    /// Возвращает размер и ёмкость динамического массива в виде строки.
    /// </summary>
    /// <returns>Строка с размером и ёмкостью массива.</returns>
    public override string ToString()
    {
        return $"Size: {Size}, capacity: {Capacity}";
    }


    /// <summary>
    /// Реализует метод интерфейса <see cref="IEnumerable"/>.
    /// </summary>
    /// <returns>Перечислитель <see cref="IEnumerator"/>, который используется для прохода по коллекции.</returns>
    public IEnumerator GetEnumerator()
    {
        return new DynamicArrayEnumerator<T>(this);
    }


    /// <summary>
    /// Обеспечивает ёмкость массива относительно заданного размера.
    /// </summary>
    /// <param name="minimum">Минимальный размер массива, который необходимо обеспечить.</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    private void EnsureCapacity(int minimum)
    {
        if (minimum < 0)
            throw new ArgumentOutOfRangeException(nameof(minimum), "Array size must be >= 0");

        if (minimum == 0)
        {
            _items = Array.Empty<T>();
        }
        else if (minimum >= Capacity)
        {
            Array.Resize(ref _items, minimum * _increaseFactor);
        }
        else if (minimum < Capacity / _reductionFactor)
        {
            Reduce(minimum, minimum * _increaseFactor);
        }
        else if (minimum < Size)
        {
            // Установить значение default неиспользуемым ячейкам внутреннего массива.
            Array.Fill(_items, default, minimum, Capacity - minimum);
        }
    }


    /// <summary>
    /// Уменьшить динамическтй массив до заданной ёмкости и размера.
    /// </summary>
    /// <param name="newCapacity">Новая ёмкость массива.</param>
    /// <param name="newSize">Новый размер массива.</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="ArgumentException"></exception>
    private void Reduce(int newSize, int newCapacity)
    {
        if (newSize < 0)
            throw new ArgumentOutOfRangeException(nameof(newSize), "The new array size must be >= 0");
        if (newCapacity < 0)
            throw new ArgumentOutOfRangeException(nameof(newCapacity), "The new array capacity must be >= 0");
        if (newCapacity < newSize)
            throw new ArgumentException("Array capacity cannot be less than array size", nameof(newCapacity) + "; " + nameof(newSize));

        T[] temp = new T[newCapacity];
        Array.Copy(_items, temp, newSize);
        _items = temp;
    }
}

