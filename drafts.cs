
dotnet源码： https://referencesource.microsoft.com/
----------------------------------------------------------------------------------------------------------------------
private static void ArrayIndex()
    {
        var a = new (string mid, string name)[2];

        a[0] = ("13", "wang");

        a[1] = ("123", "liu");

        var i = Array.FindIndex(a, x => x.mid == "123");

        Console.WriteLine(i);
    }    
-----------------------------------------------------------------------------------------------------------------

1. message box
       [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, uint uType);

        static void Main(string[] args)
        {

            MessageBox(IntPtr.Zero, "Command-line message box", "Attention!", 0);

        }

----------------------------------------------------------------------------------------------------------------
2.      var a = Enumerable.Range(10, 20);

            foreach (var i in a)
            {
                Console.WriteLine(i);
            }

-------------------------------------------------------------------------------------------------------------------------------
3.  File.AppendAllText("a.txt", "hello world");

            var a = new FileInfo("a.txt");

            Console.WriteLine(a.Length);
-------------------------------------------------------------------------------------------------------------------------------

4.  private static void Practice()
        {
            var s = "hello,world";

            var n = new char[s.Length];

            var len = s.Length / 3;

            for (var i = 0; i < len; i++)
            {
                n[3 * i] = s[3 * i + 2];
                n[3 * i + 1] = s[3 * i + 1];
                n[3 * i + 2] = s[3 * i];
            }

            var substr = s.Length - 3 * len;

            for (int i = 0; i < substr; i++)
            {
                n[3 * len + i] = s[s.Length - substr + i];
            }

            Console.WriteLine(new string(n));
        }

-------------------------------------------------------------------------------------------------------------------------------
5.  private static void Practice()
        {
            var s = "hello,world";

            var n = new char[s.Length];

            var len = s.Length / 2;

            for (var i = 0; i < len; i++)
            {
                n[2 * i] = s[2 * i + 1];
                n[2 * i + 1] = s[2 * i];
            }

            if (s.Length > 2 * len)
            {
                n[2 * len] = s[s.Length - 1];
            }

            Console.WriteLine(new string(n));
        }

-------------------------------------------------------------------------------------------------------------------------------
6.   private static void Practice()
        {
            var s = "hello,world";

            var n = new char[s.Length];
            var n2 = new char[s.Length];


            for (var i = 0; i < s.Length; i++)
            {
                if (i % 2 == 0)
                {
                    n[i] = s[i];
                }
                else
                {
                    n2[i] = s[i];
                }

            }

            Console.WriteLine(new string(n));
            Console.WriteLine(new string(n2));
        }

-------------------------------------------------------------------------------------------------------------------------------

7.  private static void Practice()
        {
            var s = "hello,world";

            var n = new StringBuilder();
            var n2 = new StringBuilder();


            for (var i = 0; i < s.Length; i++)
            {
                if (i % 2 == 0)
                {
                    n.Append(s[i]);
                }
                else
                {
                    n2.Append(s[i]);
                }

            }

            Console.WriteLine(n);
            Console.WriteLine(n2);
        }

-------------------------------------------------------------------------------------------------------------------------------
8.  private static void Practice()
        {
            var s = "hello,world";

            var n = new StringBuilder();
            var n2 = new StringBuilder();


            for (var i = 0; i < s.Length; i++)
            {
                var nn = i % 2;
                switch (nn)
                {
                    case 0:
                        n.Append(s[i]);
                        break;
                    case 1:
                        n2.Append(s[i]);
                        break;
                }

            }

            Console.WriteLine(n);
            Console.WriteLine(n2);
        }
