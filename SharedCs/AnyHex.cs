  #region 任意进制转换
        class AnyHex
        {
            //数字加大小写英文字母， 最大可表示62进制
            private static readonly string[] Array = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "S", "Y", "Z" };

            private static string _result = string.Empty;
            public static string Change(int number, int hex)
            {
                var remainder = number % hex;
                _result = Array[remainder] + _result;
                var a = number / hex;
                if (a >= hex)
                {
                    _result = Change(a, hex);
                }
                else if (a > 0)
                {
                    _result = Array[a] + _result;
                }

                return _result;
            }
        }
        #endregion
