 #region 用反射遍历枚举元素
        public static void EnumDemo()
        {
            var a = typeof(MyEnum).GetEnumNames(); //iterator enum elements
            foreach (var s in a)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine((MyEnum)1); //int to enum
        }

        private enum MyEnum
        {
            aa, bb, cc
        }
 #endregion
