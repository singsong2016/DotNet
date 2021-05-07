  public static string ExecuteCmd(String command)               //向cmd（）传入命令行，传入"exit"则退出cmd.exe。
{
    Process p = new Process
    {
        StartInfo =
        {
            FileName = "cmd.exe",
            UseShellExecute = false,
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            CreateNoWindow = true
        }
    };
    p.Start();
    p.StandardInput.WriteLine(command);// 向cmd.exe输入command
    p.StandardInput.WriteLine("exit");
    string s = p.StandardOutput.ReadToEnd();// 得到cmd.exe的输出
    p.Close();
    return s;
}
