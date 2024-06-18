
using DatabaseFirst.Entities;


Order order1 =new Order() { Test = 1 };
Console.WriteLine($"order1.Test: {order1.Test}");
order1.Test = 2;
Console.WriteLine($"order1.Test: {order1.Test}");