public partial class RunCimMessageMonitor : Form
    {
        SynchronizationContext m_SyncContext = null;

        public RunCimMessageMonitor()
        {
            InitializeComponent();
            Task.Factory.StartNew(MonitorCimMessage);
            m_SyncContext = SynchronizationContext.Current;
        }

        private void MonitorCimMessage()
        {
            while (true)
            {
                m_SyncContext.Post(CIM_Message.Init.AddCimMessage, "hello");   这是执行UI中的方法更新UI内容

                Thread.Sleep(2000);
            }
        }
    }
