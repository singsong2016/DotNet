        #region 设置程序使用的CPU哪几个线程，默认全使用，如果是8线程，ProcessorAffinity 值为8个1=255
        public static void ProcessorAffinityDemo()
        {
            var a = Process.GetCurrentProcess();

            var b = new IntPtr(3);

            a.ProcessorAffinity = IntPtr.Add(b, 0);

            Console.WriteLine(a.ProcessorAffinity);

            Task.Factory.StartNew(() =>                            //让本程序占100%CPU
            {
                while (true)
                {

                }
            });

            SetAffinity();

            while (true)                                       //不退出
            {

            }

            void SetAffinity()
            {
                var a = Process.GetProcessesByName("ConsoleApp5"); //本程序名称
                var b = new IntPtr(1);

                a[0].ProcessorAffinity = b;

                Console.WriteLine(a[0].ProcessorAffinity);
            }
        }
        #endregion
