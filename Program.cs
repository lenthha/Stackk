using System;

namespace ConsoleApp1
{
    public class Stack<T> where T : new()
    {
        private T[] _stack;
        private int _top;

        public Stack(int size)
        {
            _stack = new T[size];
            _top = 0;
        }

        public int Push(T item)
        {
            if (_top == _stack.Length)
            {
                return -1; // Stack is full
            }
            _stack[_top++] = item;
            return _top;
        }

        public T Pop()
        {
            if (_top == 0)
            {
                return default(T); // Stack is empty
            }
            return _stack[--_top];
        }

        public bool IsFull()
        {
            return _top == _stack.Length;
        }

        public bool IsEmpty()
        {
            return _top == 0;
        }

        public int Capacity()
        {
            return _stack.Length;
        }

        public int Count()
        {
            return _top;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            const int StackSize = 10;
            Stack<int> stack1 = new Stack<int>(StackSize);

            for (int i = 0; !stack1.IsFull(); i++)
            {
                stack1.Push(i + 1);
            }

            if (stack1.IsFull())
            {
                Console.WriteLine("Stack1 is full.");
            }

            Console.Write("Contents of stack1: ");
            while (!stack1.IsEmpty())
            {
                Console.Write($"{stack1.Pop()} ");
            }
            Console.WriteLine();

            if (stack1.IsEmpty())
            {
                Console.WriteLine("Stack1 is empty.\n");
            }

            Console.WriteLine("Refilling stack1.");
            for (int i = 0; !stack1.IsFull(); i++)
            {
                stack1.Push(StackSize - i);
            }

            Console.WriteLine("Transferring elements from stack1 to stack2 with fractional part.");
            Stack<double> stack2 = new Stack<double>(StackSize);
            while (!stack1.IsEmpty())
            {
                stack2.Push(stack1.Pop() + 0.5);
            }

            Console.Write("Contents of stack2: ");
            while (!stack2.IsEmpty())
            {
                Console.Write($"{stack2.Pop():F1} ");
            }
            Console.WriteLine();

            Console.WriteLine($"Capacity of stack2: {stack2.Capacity()}");
            Console.WriteLine($"Number of elements in stack2: {stack2.Count()}");

            Console.ReadKey();
        }
    }
}
