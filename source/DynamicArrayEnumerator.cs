//@author Lisoferma

using System.Collections;

namespace DynamicArray;

/// <summary>
/// Реализация интерфейса <see cref="IEnumerator"/> для класса <see cref="DynamicArray{T}"/>.
/// </summary>
/// <typeparam name="T">Тип элементов массива <see cref="DynamicArray{T}"/>.</typeparam>
public class DynamicArrayEnumerator<T> : IEnumerator
{
    private readonly DynamicArray<T> _array;
    private int _position = -1;                 // Позиция итератора.


    /// <summary>
    /// Инициализирует <see cref="DynamicArrayEnumerator{T}"/> для реализации интерфейса <see cref="IEnumerator"/>.
    /// </summary>
    /// <param name="array">Динамический массива по которому будет осуществляться проход итератора.</param>
    public DynamicArrayEnumerator(DynamicArray<T> array)
    {
        _array = array;
    }


    /// <value>
    /// Возвращает объект в последовательности, на который указывает <see cref="_position"/>.
    /// </value>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public object Current
    {
        get
        {
            if (_position >= _array.Size)
                throw new ArgumentOutOfRangeException(nameof(_position), "Position is larger than the array size");
            if (_position < 0)
                throw new ArgumentOutOfRangeException(nameof(_position), "Position should be >= 0");

            return _array[_position]!;
        }
    }


    /// <summary>
    /// Перемещает указатель позиции на текущий элемент <see cref="_position"/> на следующую позицию в последовательности.
    /// </summary>
    /// <returns>true если последовательность не закончилась, иначе false.</returns>
    bool IEnumerator.MoveNext()
    {
        if (_position < _array.Size - 1)
        {
            ++_position;
            return true;
        }
        else
        {
            return false;
        }
    }


    /// <summary>
    /// Cбрасывает указатель позиции <see cref="_position"/> в начальное положение.
    /// </summary>
    void IEnumerator.Reset()
    {
        _position = -1;
    }
}
