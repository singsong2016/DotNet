  #region 泛型数据类型转变   也就是将输入 object 转换为任意数据类型通用方法
        public static void GenericDemo()
        {
            Console.WriteLine(GetData<int>("123"));

            Console.WriteLine(GetData<string>("abcd"));

            static T GetData<T>(string s)
            {
                var re = (T)Convert.ChangeType(s, typeof(T));
                return re;
            }
        }
 #endregion
