
-----------------------对输入的类型T的n个元素进行任意组合，返回组合的list结果

        public static Dictionary<int, List<List<T>>> Combination<T>(params T[] s)
        {
            var re = new Dictionary<int, List<List<T>>>();

            var init = s.Select(t => new List<T> { t }).ToList();

            re.Add(0, init);

            for (int i = 1; i < s.Length; i++)
            {
                var ad = new List<List<T>>();

                foreach (var list in re[i - 1])
                {
                    var n = new List<T>();
                    list.ForEach(n.Add);

                    foreach (var v in s)
                    {
                        if (list.Contains(v)) continue;
                        n.Add(v);
                        break;
                    }
                    ad.Add(n);
                }
                re.Add(i, ad);
            }
            return re;
        }
    

       static void Main(string[] args)
        {
            var s = new string[] { "a", "b", "c" };

            var b =Combination(s);

            foreach (var keyValuePair in b)
            {
                Console.WriteLine(keyValuePair.Key);
                foreach (var list in keyValuePair.Value)
                {
                    Console.WriteLine(string.Join("",list));
                }
            }

        }
