

#region 数组转字符串   可用于保存程序数据到硬盘
var a = new int[3] { 2, 3, 4 };
var b = string.Join(",", a);
Console.WriteLine(b);
#endregion


 public static void ToStringDemo()
{
    var a = 100;

    Console.WriteLine(a.ToString("P") + " P");
    Console.WriteLine(a.ToString("C") + " C");
    Console.WriteLine(a.ToString("F1") + " F1");
    Console.WriteLine(a.ToString("x2") + " x2");
    Console.WriteLine(a.ToString("N1") + " N1");
    Console.WriteLine(a.ToString("0000") + " 0000");
}
