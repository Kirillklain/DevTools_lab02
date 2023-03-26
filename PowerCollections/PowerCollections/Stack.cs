using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PowerCollections
{
    public class Stack<T> : IEnumerable<T>
    
            get { return count; } 
        }
        //new in 0.0.2-beta
        public Stack()
        {
            const int defaultCapacity = 100;
            elements = new T[defaultCapacity];
        }
        public Stack(int max_size_stack)
        {
            if (max_size_stack <= 0)
            {
                throw new ArgumentOutOfRangeException("Ошибка.Размер стека не может быть равен или меньше нуля");
            }
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
