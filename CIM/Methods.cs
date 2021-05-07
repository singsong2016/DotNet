public class Methods
    {
        #region 1.send message to winform

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int la);

        #endregion

        #region 2.date time string
        public static string GetDateTimeString()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        #endregion

        #region 3. Set PC Time 设置PC时间需要管理员权限下运行软件

        public static void SetPcTime(DateTime t)
        {
            var s = new SYSTEMTIME();
            if (t.Year == 2020)
            {
                return;
            }
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

        #region 4. 数组移位 默认填补值t  向后backWard  从index开始

        public static void ShiftArray<T>(T[] input, T t = default, bool backWard = true, int index = 0)
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
        #endregion

        #region 5.short bytes transfer
        public static string AscToString(ushort[] inputShorts)
        {
            var re = new byte[inputShorts.Length * 2];

            for (var i = 0; i < inputShorts.Length; i++)
            {
                re[i * 2] = (byte)inputShorts[i];
                re[i * 2 + 1] = (byte)(inputShorts[i] >> 8);
            }
            var s = Encoding.ASCII.GetString(re);
            return s;
        }

        public static UInt16[] StringToAscArray(string inputString, int length)
        {
            var len = 0;
            ushort[] a = new ushort[length];
            for (var i = 0; i < a.Length; i++)
            {
                a[i] = 0x2020;
            }

            if (inputString is null || inputString.Length > 2 * length)
            {
                return a;
            }
            var inputBytes = Encoding.ASCII.GetBytes(inputString);
            if (inputBytes.Length % 2 == 0)
            {
                len = inputBytes.Length / 2;

                for (var i = 0; i < len; i++)
                {
                    a[i] = Convert.ToUInt16(inputBytes[i * 2 + 1] << 8);
                    a[i] += inputBytes[i * 2];
                }
            }
            else
            {
                len = inputBytes.Length / 2 + 1;

                for (int i = 0; i < len - 1; i++)
                {
                    a[i] = Convert.ToUInt16(inputBytes[i * 2 + 1] << 8);
                    a[i] += inputBytes[i * 2];
                }

                a[len - 1] = Convert.ToUInt16((0x20 << 8) + inputBytes[inputBytes.Length - 1]);
            }

            return a;
        }
        #endregion

        #region 6. datatable xml transfer

        /// <summary>
        /// 将DataTable的内容写入到XML文件中
        /// </summary>
        /// <param name="dt">数据源</param>
        /// <param name="address">XML文件地址</param>
        public static bool SaveDatatableToXml(DataTable dt, string address)
        {
            try
            {
                //如果文件DataTable.xml存在则直接删除
                if (File.Exists(address))
                {
                    File.Delete(address);
                }

                dt.TableName = "a table";

                dt.WriteXml(address, XmlWriteMode.WriteSchema);
                //XML文档创建结束
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }


        /// <summary>
        /// 从XML文件中读取一个DataTable
        /// </summary>
        /// <param name="dt">数据源</param>
        /// <param name="address">XML文件地址</param>
        /// <returns></returns>
        public static DataTable ReadXmlToDataTable(string address)
        {

            try
            {
                if (!File.Exists(address))
                {
                    throw new Exception("文件不存在!");
                }
                else
                {
                    var s = new DataTable();
                    s.ReadXml(address);
                    return s;
                }

            }
            catch (Exception e)
            {
                return new DataTable();
            }

        }


        #endregion

        #region 7.datatable remove first

        /// <summary>
        /// add a new row to data table and keep rows smaller than 1000
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="row"></param>
        public static void AddRow(DataTable dt, DataRow row)
        {
            if (dt.Rows.Count > 1000)
            {
                dt.Rows.RemoveAt(0);
            }

            dt.Rows.Add(row);
        }
        #endregion

        #region 8.Get BCD date time array
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static UInt16[] GetBcdDateTimeArray()
        {
            var a = new UInt16[3];
            var y = (DateTime.Now.Year - 2000) / 10 << 12;
            var ys = (DateTime.Now.Year - 2000) % 10 << 8;
            var m = DateTime.Now.Month / 10 << 4;
            var ms = DateTime.Now.Month % 10;
            a[0] = Convert.ToUInt16(y + ys + m + ms);
            var day = DateTime.Now.Day / 10 << 12;
            var days = DateTime.Now.Day % 10 << 8;
            var h = DateTime.Now.Hour / 10 << 4;
            var hs = DateTime.Now.Hour % 10;
            a[1] = Convert.ToUInt16(day + days + h + hs);
            var Min = DateTime.Now.Minute / 10 << 12;
            var Mins = DateTime.Now.Minute % 10 << 8;
            var Second = DateTime.Now.Second / 10 << 4;
            var Seconds = DateTime.Now.Second % 10;
            a[2] = Convert.ToUInt16(Min + Mins + Second + Seconds);

            return a;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static UInt16[] GetBcdDateTimeWithDayOfWeekArray()
        {
            var a = new UInt16[4];
            var y = (DateTime.Now.Year - 2000) / 10 << 12;
            var ys = (DateTime.Now.Year - 2000) % 10 << 8;
            var m = DateTime.Now.Month / 10 << 4;
            var ms = DateTime.Now.Month % 10;
            a[0] = Convert.ToUInt16(y + ys + m + ms);
            var day = DateTime.Now.Day / 10 << 12;
            var days = DateTime.Now.Day % 10 << 8;
            var h = DateTime.Now.Hour / 10 << 4;
            var hs = DateTime.Now.Hour % 10;
            a[1] = Convert.ToUInt16(day + days + h + hs);
            var Min = DateTime.Now.Minute / 10 << 12;
            var Mins = DateTime.Now.Minute % 10 << 8;
            var Second = DateTime.Now.Second / 10 << 4;
            var Seconds = DateTime.Now.Second % 10;
            a[2] = Convert.ToUInt16(Min + Mins + Second + Seconds);

            a[3] = Convert.ToUInt16((int)DateTime.Now.DayOfWeek);
            return a;
        }
        #endregion


        #region 10 Wait Time T
        public static void WaitIntervalTime(Stopwatch s, int t)
        {
            if (s.Elapsed < TimeSpan.FromSeconds(t))
            {
                Thread.Sleep(TimeSpan.FromSeconds(t) - s.Elapsed);
            }
            s.Restart();
        }

        #endregion

        #region 11.data table add columns

        public static void AddColums(DataTable dt, params string[] s)
        {
            if (dt.Rows.Count != 0) return;
            foreach (var s1 in s)
            {
                dt.Columns.Add(s1);
            }

        }

        #endregion

        #region 12 file to data array
        public static T[] ReadFileToDataArray<T>(string address)
        {
            if (File.Exists(address))
            {
                var s = File.ReadAllLines(address);

                var data = new T[s.Length];
                for (var i = 0; i < s.Length; i++)
                {
                    data[i] = (T)Convert.ChangeType(s[i], typeof(T));
                }

                return data;

            }
            else
            {
                return null;
            }
        }

        public static void WriteDataArrayToFile(string adress, int[] data)
        {
            var s = new string[data.Length];
            for (var i = 0; i < data.Length; i++)
            {
                s[i] = data[i].ToString();
            }
            File.WriteAllLines(adress, s);
        }
        #endregion
    }
