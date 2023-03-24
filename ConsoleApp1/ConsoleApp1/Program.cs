PowerCollections.Stack<int> stack = new();
Console.WriteLine(stack.Capacity);
stack.Push(1);
stack.Push(2);
stack.Push(3);
Console.WriteLine(stack.Pop());
Console.WriteLine(stack.Pop());
Console.WriteLine(stack.Pop());
