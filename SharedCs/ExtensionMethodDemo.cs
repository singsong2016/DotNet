 static class ExtensionMethod
    {
        public static string Hi(this int a, string s)
        {
            return "h" + a + s;
        }

        public static void go(this string a)
        {
            Console.WriteLine(a);
        }
    }
