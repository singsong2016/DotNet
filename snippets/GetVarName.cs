        static void Main(string[] args)
        {
            var hah = "hello";

            var s = GetVarName(() => hah);

            Console.WriteLine(s);

        }

        public static string GetVarName<T>(System.Linq.Expressions.Expression<Func<T>> exp)
        {
            return ((System.Linq.Expressions.MemberExpression)exp.Body).Member.Name;
        }
