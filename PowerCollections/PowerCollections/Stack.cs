using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PowerCollections
{
    public class Stack<T> : IEnumerable<T>
    {
        private T[] elements;

        int count = 0;
        public int Capacity { get; }

        public int Count 
        {
            get { return count; } 
        }

        public Stack(int max_size_stack)
        {
            if (max_size_stack <= 0)
            {
                throw new ArgumentOutOfRangeException("Ошибка.Размер стека не может быть равен или меньше нуля");
            }
            Capacity = max_size_stack;
            elements = new T[max_size_stack];
        }

        public void Push(T element)
        {
            if (count == elements.Length)
            {
                throw new InvalidOperationException("Ошибка.Стек переполнен");
            }

            elements[count++] = element;
        }

        public T Pop ()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Ошибка.Стек пуст");
            }

            return elements[--count];
        }

        public T Top()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Ошибка.Стек пуст");
            }

            return elements[count - 1];
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (count == 0)
            {
                yield break;
            }

            for (int i = count; i > 0; i--)
            {
                yield return elements[i - 1];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
