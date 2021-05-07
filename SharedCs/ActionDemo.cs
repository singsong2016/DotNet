#region 3. action function 作为方法参数示例
public static void ActionFuncDemo()
{
    DoAction(Writes, "hell");
    void Writes(string s)
    {
        Console.WriteLine(s);
    }

    DoFunc(returnBool);

    void DoAction(Action<string> t, string s)
    {
        t.Invoke("hello");
        Console.WriteLine(s);
    }

    void DoFunc(Func<string, bool> F)
    {
        Console.WriteLine(F("hello"));
    }

    bool returnBool(string s)
    {
        return s.Length > 0;
    }
}
#endregion
