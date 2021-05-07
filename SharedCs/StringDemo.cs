

#region 数组转字符串   可用于保存程序数据到硬盘
var a = new int[3] { 2, 3, 4 };
var b = string.Join(",", a);
Console.WriteLine(b);
#endregion
