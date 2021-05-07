        #region 13 Delegate Demo
        private delegate void DoSomething(string s);
        private static event DoSomething DoIt;
        public static void DelegateDemo()
        {

            DoIt += AnotherThingsA;  //block to execute
            DoIt += AnotherThingsB;
            OnDoIt("hi");

            void AnotherThingsA(string s)
            {
                Thread.Sleep(200);
                Console.WriteLine("this is  thingsA");
            }
            void AnotherThingsB(string s)
            {
                Thread.Sleep(100);
                Console.WriteLine("this is thingsB");
            }
            void OnDoIt(string s)
            {
                while (true)
                {
                    DoIt?.Invoke(s);
                    Thread.Sleep(1000);
                }

            }
        }

        #endregion
