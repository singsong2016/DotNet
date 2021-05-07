
dotnet源码： https://referencesource.microsoft.com/
------------------------------------------------元组数组元素查找----------------------------------------------------------------------
private static void ArrayIndex()
    {
        var a = new (string mid, string name)[2];

        a[0] = ("13", "wang");

        a[1] = ("123", "liu");

        var i = Array.FindIndex(a, x => x.mid == "123");

        Console.WriteLine(i);
    }    
----------------------------------------------windows消息弹窗-------------------------------------------------------------------

1. message box
       [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, uint uType);

        static void Main(string[] args)
        {

            MessageBox(IntPtr.Zero, "Command-line message box", "Attention!", 0);

        }

------------------------------------------任意连续整数----------------------------------------------------------------------
2.      var a = Enumerable.Range(10, 20);

            foreach (var i in a)
            {
                Console.WriteLine(i);
            }

-----------------------------------------------------文件大小判断--------------------------------------------------------------------------
3.  File.AppendAllText("a.txt", "hello world");

            var a = new FileInfo("a.txt");

            Console.WriteLine(a.Length);
-------------------------------------------------------------------------------------------------------------------------------

