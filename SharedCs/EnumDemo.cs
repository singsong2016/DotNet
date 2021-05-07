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


//周几转中文
var a=new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
var b = a[(int)DateTime.Now.DayOfWeek];
