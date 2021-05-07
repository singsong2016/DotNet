        /// <summary>
        /// shift数组元素  从index位向前向后
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="backWard"></param>
        /// <param name="index"></param>
        /// <param name="t"></param>
        public static void ShiftArray<T>(T[] input,T t = default, bool backWard = true, int index = 0 )
        {
            if (backWard)
            {
                for (var i = input.Length - 1; i > index; i--)
                {
                    input[i] = input[i - 1];
                }
                input[0] = t;
            }
            else
            {
                for (var i = index; i < input.Length - 1; i++)
                {
                    input[i] = input[i + 1];
                }
                input[input.Length - 1] = t;
            }
        }
