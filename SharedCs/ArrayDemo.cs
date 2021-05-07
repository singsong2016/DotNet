
---------------------array的截取---------------------

public static void ArraySkipCopyDemo()
{
    var a = new int[4] { 1, 2, 3, 4 };

    var b = a.Skip(1).Take(2).ToArray();

    Console.WriteLine("a.Skip(1).Take(2).ToArray():");
    foreach (var i in b)
    {
        Console.WriteLine(i);
    }

    Console.WriteLine(" c.CopyTo(a, 0)");
    var c = new int[2] { 5, 6 };
    c.CopyTo(a, 0);
    foreach (var i in a)
    {
        Console.WriteLine(i);
    }

}

------------------------------查找array元素-------------
    private static void ArrayIndex()
    {
        var a = new (string mid, string name)[2];

        a[0] = ("13", "wang");

        a[1] = ("123", "liu");

        var i = Array.FindIndex(a, x => x.mid == "123");

        Console.WriteLine(i);
    }    
