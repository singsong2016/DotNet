        /// <summary>
        /// shift数组元素  从index位向前向后
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="Back"></param>
        /// <param name="index"></param>
        public static void ShiftArray<T>(T[] input, bool BackWard = true, int index = 0)
        {
            if (Back)
            {
                for (var i = input.Length - 1; i > index; i--)
                {
                    input[i] = input[i - 1];
                }
                input[0] = default;
            }
            else
            {
                for (var i = index; i < input.Length - 1; i++)
                {
                    input[i] = input[i + 1];
                }
                input[input.Length - 1] = default;
            }
        }
