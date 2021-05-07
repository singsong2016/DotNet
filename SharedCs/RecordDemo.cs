 #region 25 record 
        public static void RecordDemo()
        {
            var a = new RecordDe("wang", "zhang");

            var b = a with { city = "gz" };

            Console.WriteLine(a == b);
        }

        private record RecordDe(string name, string city);
        #endregion
