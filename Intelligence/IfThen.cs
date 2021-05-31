
//If Then 类问题推理
static void Main(string[] args)
{
    var inputStr = "g:if firewall then visit down," +  //输入格式：g代表given条件，if then/reflect 代表知识
                   "if server down then visit down," +
                   "if switch or any other middleware prevent then visit down," +
                   "now visit down;" +  //知识加条件 自动得到结论
                   "f:today rain or not";  //f:代表find求

    Console.WriteLine(IfThen(inputStr));

}

private static string IfThen(string input)
{
    //把输入字符串分离为已知条件的dictionary 和 求
    var given = input.Substring(2, input.IndexOf("f:", StringComparison.Ordinal)).Split(',');

    var knowledge = new Dictionary<string, string>();//知识部分 if then/reflect
    int ifProblem = 0;
    foreach (var s in given)
    {
        if (s.StartsWith("if"))//knowledge
        {
            ifProblem = 1;//代表这是if then类推理问题
            AddKnowledge("then", s, knowledge);

            AddKnowledge("reflect", s, knowledge);
        }
        else//condition
        {
            if (ifProblem == 1)//如果是if then类问题
            {
                foreach (var keyValuePair in knowledge) //找确定性结果
                {
                    if (s.Contains(keyValuePair.Key))//如果condition中有if中的条件，自动得到if中的结果
                    {
                        return keyValuePair.Value;
                    }
                }

                foreach (var keyValuePair in knowledge) //由结论逆推原因可能性 枚举所有
                {
                    if (s.Contains(keyValuePair.Value))
                    {
                        Console.WriteLine("maybe " + keyValuePair.Key);
                    }
                }
            }

        }
    }

    //var find = input.Substring(input.IndexOf("f:", StringComparison.Ordinal) + 2);//求

    return "no definite result find";
}

private static void AddKnowledge(string c, string s, Dictionary<string, string> knowledge)
{
    if (s.Contains(c))
    {
        var a = s.Substring(3, s.IndexOf(c) - 3).Trim();
        var b = s.Substring(s.IndexOf(c) + c.Length).Trim();
        knowledge.Add(a, b);
    }
}
