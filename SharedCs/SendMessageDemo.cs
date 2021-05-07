        #region 程序发消息给notepad
        public static void SendMsgToWindow()
        {
            Process[] notepads = Process.GetProcessesByName("notepad");

            var a = FindWindow(notepads[0].MainWindowHandle, new IntPtr(0), "Edit", null);

            SendMessage(a, 0x000C, 0, "this is from c#");

            Console.WriteLine(a);
        }

        //protected override void WndProc(ref Message m)   //override form的接收消息方法

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr intptr, int msg, int p1, string lparam);  //此参数也可以是 int lparam

        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindow(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        #endregion
