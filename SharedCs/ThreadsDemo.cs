  #region  async await task<T> 带返回类型task 
public static async void AsyncWaitDemo()
{
    Console.WriteLine("waiting");
    var b = await Task.Run(dosome);
    Console.WriteLine(b.ToString());
    Console.WriteLine("done");

    Task<bool> dosome()
    {
        Thread.Sleep(3000);
        return Task.FromResult(true);
    }
}
#endregion

#region 5. 控制线程暂停 运行
public static void AutoResetManualResetEventDemo()
{
    var objAutoResetEvent = new AutoResetEvent(false);
    Task.Factory.StartNew(domso);

    //var s = new ManualResetEvent(false); // 打开所有等待
    //s.Set();
    Thread.Sleep(1000);
    objAutoResetEvent.Set();//释放一个

    void domso()
    {
        Console.WriteLine("start");
        objAutoResetEvent.WaitOne();//等待释放
        Console.WriteLine("finish");
    }
}
#endregion
