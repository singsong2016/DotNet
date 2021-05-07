 #region  Set PC Time
        /// <summary>
        /// 设置PC时间需要管理员权限下运行软件
        /// </summary>
        /// <param name="t"></param>
        public static void SetPcTime(DateTime t)
        {
            var s = new SYSTEMTIME();
            s.FromDateTime(t);
            SetLocalTime(ref s);
        }

        [DllImport("Kernel32.dll")]
        private static extern bool SetLocalTime(ref SYSTEMTIME Time);

        private struct SYSTEMTIME
        {
            private ushort wYear;
            private ushort wMonth;
            private ushort wDayOfWeek;
            private ushort wDay;
            private ushort wHour;
            private ushort wMinute;
            private ushort wSecond;
            private ushort wMilliseconds;

            /// <summary>
            /// 从System.DateTime转换。
            /// </summary>
            /// <param name="time">System.DateTime类型的时间。</param>
            public void FromDateTime(DateTime time)
            {
                wYear = (ushort)time.Year;
                wMonth = (ushort)time.Month;
                wDayOfWeek = (ushort)time.DayOfWeek;
                wDay = (ushort)time.Day;
                wHour = (ushort)time.Hour;
                wMinute = (ushort)time.Minute;
                wSecond = (ushort)time.Second;
                wMilliseconds = (ushort)time.Millisecond;
            }

        }

        #endregion
