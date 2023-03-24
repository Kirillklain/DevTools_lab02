using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PowerCollections.Tests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void Creation_of_an_empty_stack_by_the_constructor_and_see_capacity()
        {
            Stack<string> stack = new Stack<string>(1);
            Assert.AreEqual(1, stack.Capacity);
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Ошибка.Размер стека не может быть равен или меньше нуля")]
        public void Verify_exception_that_create_stack_with_size_is_less_than_zero()
            
        {
            Stack<int> stack = new Stack<int>(-5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Ошибка.Размер стека не может быть равен или меньше нуля")]
        public void Verify_exceptiont_that_create_stack_with_size_is_zero()
        {
            Stack<int> stack = new Stack<int>(0);
        }

        [TestMethod]
        public void Verify_that_count_equals_one_when_adding_an_element()
        {
            Stack<string> stack = new Stack<string>(1);
            stack.Push("test");
            Assert.AreEqual(1, stack.Count);
        }

        [TestMethod]
        public void Verify_that_count_is_zero_if_push_elements_next_pop_all_elements()
        {
            Stack<string> stack = new Stack<string>(3);
            stack.Push("test");
            stack.Pop();
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void Push_element_verify_that_top_element_equals_the_added_element()
        {
            Stack<string> stack = new Stack<string>(3);
            stack.Push("test");
            Assert.AreEqual(1, stack.Count);
            Assert.AreEqual("test", stack.Top());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Ошибка.Размер стека не может быть равен или меньше нуля")]
        public void Verify_that_exception_push_elemens_greater_than_size_stack()
        {
            Stack<int> stack = new Stack<int>(2);
            stack.Push(1);
            stack.Push(1);
            stack.Push(2);
        }

        [TestMethod]
        public void Pop_element_verify_that_pop_element_equals_the_added_elemen_and_count_is_zero()
        {
            Stack<string> stack = new Stack<string>(3);
            stack.Push("test");
            Assert.AreEqual("test", stack.Pop());
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Ошибка.Стек пуст")]
        public void Verify_that_exception_pop_elemens_than_count_is_zero()
        {
            Stack<int> stack = new Stack<int>(2);
            stack.Pop();
        }

        [TestMethod]
        public void Top_element_verify_that_Top_element_equals_the_added_elemen_and_count_no_changes()
        {
            Stack<string> stack = new Stack<string>(3);
            stack.Push("test");
            Assert.AreEqual("test", stack.Top());
            Assert.AreEqual(1, stack.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Ошибка.Стек пуст")]
        public void Verify_that_exception_top_elemens_than_count_is_zero()
        {
            Stack<int> stack = new Stack<int>(2);
            stack.Top();
        }

        [TestMethod]
        public void Get_enumerator_go_from_top_to_bottom()
        {
            Stack<string> stack = new Stack<string>(5);
            string[] duplicatedStack = new string[] { "Hello", "Good", "Job", "My", "friend" };
            foreach (string item in duplicatedStack)
            {
                stack.Push(item);
            }
            string[] stackItems = stack.ToArray();
            Array.Reverse(stackItems);
            CollectionAssert.AreEqual(stackItems, duplicatedStack);
        }

        [TestMethod]
        public void Get_enumerator_from_stack_is_empty()
        {
            Stack<string> stack = new Stack<string>(5);
            IEnumerator numerator = stack.GetEnumerator();
            Assert.AreEqual(false, numerator.MoveNext());
        }

        [TestMethod]
        public void Get_enumerator_from_stack_is_not_empty()
        {
            Stack<int> stack = new Stack<int>(1);
            IEnumerator enumerator = stack.GetEnumerator();
            stack.Push(1);
            enumerator.MoveNext();
            Assert.AreEqual(false, enumerator.MoveNext());
        }
    }
}
