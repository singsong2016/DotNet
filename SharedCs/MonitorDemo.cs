 #region 21 data monitor 
        public static void DataMonitorDemo()
        {
            int a = default;
            while (true)
            {
                Thread.Sleep(1000);
                var t = 2;
                if (a.Equals(t))  //change conditions
                {
                    Console.WriteLine("no changes");
                }
                else
                {
                    Console.WriteLine("changed");
                }
            }
        }
#endregion
